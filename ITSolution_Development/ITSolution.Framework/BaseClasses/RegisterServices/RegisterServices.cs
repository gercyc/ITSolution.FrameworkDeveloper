using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using ITSolution.Framework.BaseClasses;
using ITSolution.Framework.BaseInterfaces;
using ITSolution.Framework.Common.BaseClasses;

namespace ITSolution.Framework.BaseClasses.RegisterServices
{
    public class RegisterServices
    {
        private readonly List<ItsServerInfo> _onlineServers;

        public List<ItsServerInfo> OnlineServers
        {
            get
            {
                if (_onlineServers == null)
                    return new List<ItsServerInfo>();
                else
                    return _onlineServers;
            }
        }
        public RegisterServices()
        {
            _onlineServers = new List<ItsServerInfo>();
            //StaticInfo.StartStatic();
            //StaticInfo.CheckSessions();
        }
        public void StartApplicationServices()
        {
            List<Assembly> serverAssemblies = new List<Assembly>();
            var pathsAssembly = System.IO.Directory.GetFiles("C:\\ITSolution").Where(a => a.Contains("dll") && a.Contains("Servers"));

            foreach (var asm in pathsAssembly)
            {
                serverAssemblies.Add(Assembly.LoadFrom(asm));
            }

            foreach (var asmServer in serverAssemblies)
            {
                foreach (Type server in asmServer.GetTypes())
                {
                    ItsServerInfo sinfo = new ItsServerInfo(server);
                    try
                    {
                        sinfo.Instance = Activator.CreateInstance(server);
                        RegisterWCFHost(server, sinfo);
                    }
                    catch (Exception ex)
                    {
                        sinfo.Message = ex.Message;
                    }

                    OnlineServers.Add(sinfo);
                }
            }
        }
        public void StartFrameworkServices()
        {

            List<Assembly> serverAssemblies = new List<Assembly>();
            var pathsAssembly = System.IO.Directory.GetFiles("C:\\ITSolution\\Framework").Where(a => a.Contains("ITSolution.Framework.Server") && a.EndsWith(".dll"));

            foreach (var asm in pathsAssembly)
            {
                serverAssemblies.Add(Assembly.LoadFrom(asm));
            }

            foreach (var asmServer in serverAssemblies)
            {
                AppDomain.CurrentDomain.Load(asmServer.GetName());
                foreach (Type server in asmServer.GetTypes().Where(t =>
                !t.IsDefined(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), false) &&
                t.Attributes.HasFlag(TypeAttributes.Public | TypeAttributes.BeforeFieldInit)
                && t.GetCustomAttribute(typeof(ITSolutionServerAttribute)) != null))
                {
                    ItsServerInfo sinfo = new ItsServerInfo(server);
                    try
                    {
                        sinfo.Instance = Activator.CreateInstance(server);

                        MethodInfo startupMethod = sinfo.Instance.GetType().GetMethods().Where(m => m.GetCustomAttributes(typeof(ITSolutionStartupAttribute)).Count() > 0).FirstOrDefault();

                        if (startupMethod != null)
                        {
                            startupMethod.Invoke(sinfo.Instance, new object[] { GetUri(server.Name).AbsoluteUri });
                        }

                        RegisterWCFHost(server, sinfo);
                    }
                    catch (Exception ex)
                    {
                        sinfo.Message = ex.Message;
                    }

                    OnlineServers.Add(sinfo);
                }
            }
        }

        private void AddBehaviors(ServiceHost serviceHost, Type type)
        {
            serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });

            //contratos visiveis para os clientes.. expondo os contratos disponiveis no endpoint abaixo
            //contrato, forma de binding (http), endereco.. tipo: lochst..:9090/
            foreach (Type _interface in type.GetInterfaces()
                .Where(ti => ti.GetCustomAttributes(false)
                            .Where(atr => atr.GetType() == typeof(ServiceContractAttribute)).Count() > 0))
            {
                ServiceEndpoint serviceEndpoint = serviceHost.AddServiceEndpoint(_interface,
                    new BasicHttpBinding()
                    {
                        MaxBufferSize = int.MaxValue,
                        MaxReceivedMessageSize = int.MaxValue
                    },
                    string.Format("{0}.soap", _interface.Name));
                serviceEndpoint.EndpointBehaviors.Add(new ServiceMonitorBehavior());

                foreach (var op in serviceEndpoint.Contract.Operations)
                {
                    //DataContractSerializerOperationBehavior serializer = op.Behaviors.Find<DataContractSerializerOperationBehavior>();

                    op.OperationBehaviors.Add(new ITSOperationBehavior());

                    //if (serializer != null)
                    //{
                    //    serializer.DataContractResolver = new ITSContractResolver(type.Assembly);
                    //}
                }

                //expondo o WSDL do contrato a partir de um ponto http.. esta acessivel em lochst..:9090/
                //sh.AddServiceEndpoint(_interface, MetadataExchangeBindings.CreateMexHttpBinding(), _interface.Name + "_WSDL");
            }
        }
        private Uri GetUri(string serverName)
        {
            return new Uri(string.Format("http://{0}:{1}/{2}", System.Net.Dns.GetHostName(), EnvironmentInformation.ServerPort, serverName));
        }
        private ServiceHost RegisterWCFHost(Type server, ItsServerInfo sinfo)
        {
            ServiceHost sh = new ServiceHost(server, GetUri(server.FullName));
            AddBehaviors(sh, server);
            //abrindo o host.. deixando o servico pronto para receber requests..
            sh.Open(new TimeSpan(0, 5, 0));
            sinfo.Host = sh;
            sinfo.Url = sh.BaseAddresses.FirstOrDefault().AbsoluteUri;
            sinfo.IsOnline = sh.State == CommunicationState.Opened;
            return sh;
        }

    }
    public static class RemoteService
    {
        private static RegisterServices _registerServices = null;
        public static RegisterServices RegisterService
        {
            get
            {
                if (_registerServices == null)
                {
                    var t = Type.GetType(Consts.AssemblyServers);
                    if (t != null)
                    {
                        _registerServices = Activator.CreateInstance(t) as RegisterServices;

                    }
                }

                return _registerServices;
            }
        }
    }
}
