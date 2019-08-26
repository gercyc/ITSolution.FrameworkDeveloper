using ITSolution.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseClasses.License.POCO
{
    [Serializable]
    public class ItsLicenseData
    {
        public AbstractClient Cliente { get; set; }
        public DateTime DataInicioLic { get; set; }
        public DateTime DataFimLic { get; set; }
        public List<ItsMenu> ActiveMenus { get; set; }
    }
}
