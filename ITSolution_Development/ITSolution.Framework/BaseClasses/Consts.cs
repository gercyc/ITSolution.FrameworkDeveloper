using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Common.BaseClasses
{
    public static class Consts
    {
        public const string AssemblyServers = "ITSolution.Framework.BaseClasses.RegisterServices.RegisterServices";
        public const string FrameworkServerClass = "ITSolution.Framework.Server.ITSFrameworkServerController.soap"; // /ITSFrameworkServer
        public const string FrameworkSchedulerClass = "ITSolution.Framework.Server.Scheduler.SchedulerController.soap"; // /ISchedulerControl
        public const string InternalFrameworkSession = "ITSINTERNALSESSION";
        public const string TraceServer = "ITSolution.Framework.BaseClasses.TraceMonitor.soap"; // /ITrace
        public const string ReportServerClass = "ITSolution.Framework.Server.ReportServer.ReportController.soap";


    }
    public static class FrameworkVersionConsts
    {
        public const string FrameworkMajorVersion = "1.00.00.0000";
        public const string FrameworkBuildVersion = "1.00.00.0001";
    }
}
