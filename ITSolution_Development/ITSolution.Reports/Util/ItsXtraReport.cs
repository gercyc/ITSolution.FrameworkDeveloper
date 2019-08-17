using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Reports.Util
{
    
    [CollectionDataContract]
    public class ItsXtraReport : XtraReport
    {
     
        public new XtraReport Report { get; set; }

        public ItsXtraReport()
        {

        }
    }
}
