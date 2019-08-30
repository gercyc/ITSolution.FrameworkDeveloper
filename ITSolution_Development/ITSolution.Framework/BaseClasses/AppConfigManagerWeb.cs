using ITSolution.Framework.Dao.Contexto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseClasses
{
    public class AppConfigManagerWeb : AppConfigManager
    {
        public override string ConnectionConfigPath
        {
            get
            {
                string xmlPath = Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "Config", ITSolution.Framework.Properties.Settings.Default.DefaultConnectionFile);
                return xmlPath;
            }
        }
        public AppConfigManagerWeb() : base()
        {
         
    }
}
}
