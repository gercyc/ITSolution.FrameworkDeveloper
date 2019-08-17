using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using System.ServiceModel;
using ITSolution.Framework.BaseInterfaces;
using System.ServiceModel.Dispatcher;
using System.Diagnostics;
using System.ServiceModel.Description;
using ITSolution.Framework.BaseClasses;
using System.Collections.Concurrent;
using ITSolution.Framework.Util;
using System.Runtime.Serialization;
using System.Xml;
using System.Reflection;
using ITSolution.Framework.BaseClasses.Trace;

namespace ITSolution.Framework.Common.BaseClasses
{
    public static class ITSActivator
    {
        public static ConcurrentDictionary<object, object> Instances = new ConcurrentDictionary<object, object>();

        public static T OpenConnection<T>(string Url)
        {
            IWCFConnector connector = (IWCFConnector)Activator.CreateInstance(typeof(WCFConnector<>).MakeGenericType(new Type[] { typeof(T) }), new object[] { Url });
            return (T)connector.GetObject();
        }


    }
    public class WCFConnector<T> : IWCFConnector
    {
        ChannelFactory<T> factory;
        Binding _binding;
        EndpointAddress _endpoint;
        private T _instance = default(T);
        ConnectionInfo _connectionInfo;
        int _counter = 0;

        public ConnectionInfo ConnectionInfo { get { return _connectionInfo; } set { } }

        public WCFConnector()
        {

        }
        public WCFConnector(string Url)
        {
            Init(Url);
        }

        private void Init(string Url)
        {
            var intName = typeof(T).Name;

            var url2 = Url.Split('.');
            var urlNew = string.Format("http://{0}:{1}/{2}", RedeUtil.GetHostName(), EnvironmentInformation.ServerPort, Url);

            if (Url.Contains(".soap"))
            {
                //"Servers.Math.MathController.soap" << vai chegar assim
                //retira o .soap se tiver
                Url = Url.Replace(".soap", "/");
                Url += intName;
                Url += ".soap";
            }
            else
            {
                //"Servers.Math.MathController" << vai chegar assim
                Url += "/";
                Url += intName;
                Url += ".soap";
            }
            ////"Servers.Math.MathController/IMath.soap" << vai sair assim
            _binding = new BasicHttpBinding(BasicHttpSecurityMode.None)
            {
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue
            };
            _endpoint = new EndpointAddress(string.Format("http://{0}:{1}/{2}", RedeUtil.GetHostName(), EnvironmentInformation.ServerPort, Url));
            _connectionInfo = new ConnectionInfo();
        }
        private void Configure(object channel)
        {
            ((IContextChannel)channel).OperationTimeout = new TimeSpan(0, 5, 0);
            ((IContextChannel)channel).Extensions.Add(this.ConnectionInfo);
            ((IContextChannel)channel).Faulted += new EventHandler(Connector_Faulted);
            ((IContextChannel)channel).Opened += new EventHandler(Connector_Opened);
            ((IContextChannel)channel).Closed += new EventHandler(Connector_Closed);
            ITSActivator.Instances.TryAdd(_connectionInfo, channel);
            Console.WriteLine(_counter++);
        }

        private void Connector_Closed(object sender, EventArgs e)
        {
            TraceServer.Trace(new TraceClass()
            {
                Message = string.Format("Connection closed"),
                Action = "Connector_Closed"
            });
        }

        private void Connector_Opened(object sender, EventArgs e)
        {
            TraceServer.Trace(new TraceClass()
            {
                Message = string.Format("Connection opened"),
                Action = "Connector_Opened"
            });
        }
        private static void Connector_Faulted(object sender, EventArgs e)
        {
            ((ChannelFactory)sender).Abort();
        }

        public void CloseConnection()
        {
            Console.WriteLine("Connection opened");
        }

        public object GetObject()
        {
            if (_instance == null)
            {
                factory = new ChannelFactory<T>(_binding, _endpoint);
                factory.Endpoint.EndpointBehaviors.Add(new EndpointInspector());
                _instance = factory.CreateChannel();
                Configure(_instance);
            }

            return _instance;
        }

    }
    public class ConnectionInfo : IExtension<IContextChannel>
    {
        public ConnectionInfo()
        {
            ConnectionGuid = Guid.NewGuid().ToString();
            ConnectionDate = DateTime.Now;
        }
        public string ConnectionGuid { get; set; }
        public DateTime ConnectionDate { get; set; }

        public void Attach(IContextChannel owner)
        {
        }

        public void Detach(IContextChannel owner)
        {
        }
        public override string ToString()
        {
            return ConnectionGuid;
        }
    }
    public class WCFClientInspector : IClientMessageInspector
    {
        private static WCFInspectorHelper helper = new WCFInspectorHelper();

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            if (correlationState == null)
                return;
            else
            {
                Stopwatch elapsed = (Stopwatch)correlationState;
                elapsed.Stop();
                helper.Trace(new TraceClass()
                {
                    Message = "Executed in: " + elapsed.Elapsed + " miliseconds.",
                    Action = "AfterReceiveReply",
                    ExecutingAssembly = Assembly.GetCallingAssembly().FullName
                });
            }
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            helper.Trace(new TraceClass()
            {
                Message = "Sending request...",
                Action = "BeforeSendRequest",
                ExecutingAssembly = Assembly.GetCallingAssembly().FullName
            });

            return stopwatch;
        }
    }
    public class WCFIServicenspector : IDispatchMessageInspector
    {
        private static WCFInspectorHelper helper = new WCFInspectorHelper();
        public WCFIServicenspector()
        {
            if (helper.TraceHandle == null)
                helper.TraceHandle += TraceServer.Trace;
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            helper.Trace(new TraceClass()
            {
                Message = "AfterReceiveRequest",
                Action = request.Headers.Action,
                ExecutingAssembly = Assembly.GetCallingAssembly().FullName
            });
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            return stopwatch;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            Stopwatch stopwatch = (Stopwatch)correlationState;
            stopwatch.Stop();

            helper.Trace(new TraceClass()
            {
                Message = string.Format("BeforeSendReply > ElapsedTime: {0}", stopwatch.Elapsed),
                Action = reply.Headers.Action,
                ExecutingAssembly = Assembly.GetCallingAssembly().FullName
            });
        }
    }
    public class WCFInspectorHelper
    {
        public ServiceTraceHandle TraceHandle;
        public delegate void ServiceTraceHandle(TraceClass msg);
        public void Trace(TraceClass msg)
        {
            TraceServer.Trace(msg);
        }

        public WCFInspectorHelper()
        {
        }
    }
    /// <summary>
    /// Tip 5: 
    /// https://www.codeproject.com/Articles/27308/WCF-A-few-tips
    /// </summary>
    class ReferencePreservingDataContractSerializerOperationBehavior : DataContractSerializerOperationBehavior
    {
        public ReferencePreservingDataContractSerializerOperationBehavior(OperationDescription operation) : base(operation)
        {
        }
        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes,
                0x7FFF, //maxItemsInObjectGraph
                false,  //ignoreExtensionDataObject
                true,   //preserveObjectReferences
                null    //dataContractSurrogate
                );
        }

        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes,
                0x7FFF, //maxItemsInObjectGraph
                false,  //ignoreExtensionDataObject
                true,   //preserveObjectReferences
                null    //dataContractSurrogate
                );
        }
    }
    /// <summary>
    /// Tip 5: 
    /// https://www.codeproject.com/Articles/27308/WCF-A-few-tips
    /// </summary>
    public class ITSOperationBehavior : IOperationBehavior
    {
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            IOperationBehavior innerBehavior = new ReferencePreservingDataContractSerializerOperationBehavior(operationDescription);
            innerBehavior.ApplyClientBehavior(operationDescription, clientOperation);
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            IOperationBehavior innerBehavior = new ReferencePreservingDataContractSerializerOperationBehavior(operationDescription);
            innerBehavior.ApplyDispatchBehavior(operationDescription, dispatchOperation);
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
    }
    public class ITSContractResolver : DataContractResolver
    {
        private Assembly assembly;
        public static Dictionary<string, XmlDictionaryString> dictionary = new Dictionary<string, XmlDictionaryString>();


        public ITSContractResolver(Assembly asm)
        {
            this.assembly = asm;
        }
        public ITSContractResolver()
        {

        }

        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            Type ResolvedType = null;

            if (knownTypeResolver != null)
                ResolvedType = knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null);

            if (ResolvedType == null)
            {
                XmlDictionaryString tName;
                XmlDictionaryString tNamespace;

                if (dictionary.TryGetValue(typeName, out tName) && dictionary.TryGetValue(typeNamespace.Split('/').Last(), out tNamespace))
                {
                    ResolvedType = Type.GetType(tNamespace.Value + "." + tName.Value);
                }
            }

            return ResolvedType;
            //return knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, knownTypeResolver);
            //throw new NotImplementedException();
        }

        public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            string name = type.Name;
            string namesp = type.Namespace;
            typeName = new XmlDictionaryString(XmlDictionary.Empty, name, 0);
            typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, namesp, 0);

            if (type.Name.Contains("HashSet"))
            {
                name = type.GenericTypeArguments[0].Name;
                namesp = type.GenericTypeArguments[0].Namespace;
            }

            if (!knownTypeResolver.TryResolveType(type.GenericTypeArguments[0], type.GenericTypeArguments[0], null, out typeName, out typeNamespace))
            {
                typeName = new XmlDictionaryString(XmlDictionary.Empty, name, 0);
                typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, namesp, 0);
            }

            if (!dictionary.ContainsKey(name))
                dictionary.Add(name, typeName);

            if (!dictionary.ContainsKey(namesp))
                dictionary.Add(namesp, typeNamespace);

            return true;

        }
    }
    public class ServiceMonitorBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new WCFIServicenspector());
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
    public class EndpointInspector : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new WCFClientInspector());
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
    public class PipeHost<T>
    {
        private string _servicename;
        private ServiceHost _host;


        public Uri Address { get; set; }

        public PipeHost(string ServiceName, T Intance)
        {
            try
            {
                string pipeurl = @"net.pipe://localhost/{0}";
                Address = new Uri(string.Format(pipeurl, ServiceName));
                NetNamedPipeBinding pipeBinding = new NetNamedPipeBinding();
                pipeBinding.MaxReceivedMessageSize = 50000000;
                pipeBinding.ReaderQuotas.MaxStringContentLength = 2147483647;
                pipeBinding.ReaderQuotas.MaxDepth = 2147483647;
                pipeBinding.ReaderQuotas.MaxArrayLength = 2147483647;
                pipeBinding.ReaderQuotas.MaxBytesPerRead = 2147483647;
                pipeBinding.ReaderQuotas.MaxNameTableCharCount = 2147483647;

                _servicename = ServiceName;
                _host = new ServiceHost(Intance, Address);
                foreach (var interfaceType in Intance.GetType().GetInterfaces())
                {
                    var attrib = interfaceType.GetCustomAttributes(typeof(ServiceContractAttribute), true);
                    if (attrib.Length != 0)
                        _host.AddServiceEndpoint(interfaceType, pipeBinding, Address);
                }
            }
            catch
            {
                throw;
            }
        }

        public void StartListen()
        {
            try
            {
                _host.Closed += new EventHandler(_host_Closed);
                _host.Open();
            }
            catch
            {
                throw;
            }
        }

        void _host_Closed(object sender, EventArgs e)
        {

        }
        public void StopListen()
        {
            _host.Close();
        }
    }
}
