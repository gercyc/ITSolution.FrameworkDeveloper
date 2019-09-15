using ITSolution.Framework.Core.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseClasses
{
    public static class EnvironmentInformation
    {
        public static int ServerPort { get { return AppConfigManager.Configuration.ServerPort; } }
        public static string AssemblyRegisterServices { get { return AppConfigManager.Configuration.AsmRegisterServices; } }
        public static string APIAssemblyFolder { get { return AppConfigManager.Configuration.APIAssemblyFolder; } }
        public static string CoreAssemblyFolder { get { return AppConfigManager.Configuration.CoreAssemblyFolder; } }
    }
}
