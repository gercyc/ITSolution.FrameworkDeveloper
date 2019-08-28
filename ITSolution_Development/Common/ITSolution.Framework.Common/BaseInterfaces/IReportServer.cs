using ITSolution.Framework.Common.BaseClasses.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseInterfaces
{
    [ServiceContract]
    public interface IReportServer
    {
        [OperationContract]
        void PrintReportCustomById(int idReport);

        [OperationContract]
        void PrintReport(int idreport);

        [OperationContract]
        void ShowReportList();

        [OperationContract]
        List<ReportImage> GetAllReports();

        [OperationContract]
        object GetReport(int idReport);
    }
}
