using ITSolution.Framework.Dao.Contexto;
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
    }
}
