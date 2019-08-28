using ITSolution.Framework.BaseClasses.Trace;
using ITSolution.Framework.Common.BaseClasses;
using ITSolution.Framework.Dao.Contexto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseClasses
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any, ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall, IncludeExceptionDetailInFaults = true)]
    public partial class DefaultServer<T> : Component, IItsServer<T> where T : class
    {
        private ConnectionFactory.ConnectionFactoryIts connection;
        public ConnectionFactory.ConnectionFactoryIts DataAccess { get
            {
                if(connection== null)
                    connection = new Dao.Contexto.GenericContextIts<T>(AppConfigManager.Configuration.ConnectionString).ConnectionSql;
                return connection;
            }
            set { connection = new Dao.Contexto.GenericContextIts<T>(AppConfigManager.Configuration.ConnectionString).ConnectionSql; } }
        public DefaultServer()
        {
            InitializeComponent();
            TraceServer.Register(new MemoryTraceListener());
        }

        public DefaultServer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public string ServerName { get; private set; }
        public bool IsServerOnline => throw new NotImplementedException();
        public string Addres()
        {
            throw new NotImplementedException();
        }
        public DefaultServer(string ServerName)
        {
            this.ServerName = ServerName;
        }
        public T Open(string Url)
        {

            return ITSActivator.OpenConnection<T>(Url);

        }
    }
    public interface IItsServer<T> where T : class
    {
        string Addres();
        bool IsServerOnline { get; }
        T Open(string Url);
    }

}
