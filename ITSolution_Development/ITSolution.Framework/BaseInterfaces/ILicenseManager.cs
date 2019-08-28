using ITSolution.Framework.BaseClasses.License.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseInterfaces
{
    public interface ILicenseManager
    {
         bool SaveOrUpdateLicense(ItsLicense license);
        ItsLicense GetValidLicense();

    }
}
