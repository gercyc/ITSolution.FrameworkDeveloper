using ITSolution.ServiceFramework.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.ServiceFramework.Service
{
    public class ItsFrameService : ServiceBase
    {
        //ReportServer rptServer;
        //JobServer jobServer;

        public ItsFrameService()
        {
            ServiceName = "ITSolutionFrameworkServer";
        }

        protected override void OnStart(string[] args)
        {
            //this.rptServer = new ReportServer(new Uri("http://localhost:9090/reports"));
            //rptServer.Start();

            //this.jobServer = new JobServer(new Uri("http://localhost:9090/scheduler"));
            //jobServer.Start();

            //base.OnStart(args);
            //ItsFrameService<T>.Run();
        }
        protected override void OnStop()
        {
            //rptServer.Close();
            //jobServer.Close();
            //base.OnStop();

        }
    }
}
