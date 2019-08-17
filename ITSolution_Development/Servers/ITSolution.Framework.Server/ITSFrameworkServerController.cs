using ITSolution.Framework.BaseClasses;
using ITSolution.Framework.BaseInterfaces;
using ITSolution.Framework.Common.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Server
{
    [ITSolutionServer(typeof(ITSFrameworkServerController))]
    public partial class ITSFrameworkServerController : DefaultServer<ITSFrameworkServerController>, ITSFrameworkServer
    {
        string _frameworkHost;
        public ITSFrameworkServerController():base("ITSFrameworkServer")
        {
            InitializeComponent();
        }

        public ITSFrameworkServerController(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public string FrameworkHost { get { return _frameworkHost; } }

        public List<ItsServerInfo> GetOnlineServers()
        {
            throw new NotImplementedException();
        }

        public bool RegisterSession(string sessionID)
        {
            return StaticInfo.RegisterSession(sessionID);
        }

        [ITSolutionStartup]
        public void StartServer(string Url)
        {
            _frameworkHost = Url;
            StaticInfo.StartStatic();
        }

        public bool UnRegisterSession(string sessionID)
        {
            return StaticInfo.UnRegisterSession(sessionID);
        }
    }
}
