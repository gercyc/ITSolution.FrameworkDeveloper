using ITSolution.Framework.BaseClasses;
using ITSolution.Framework.BaseClasses.Trace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseInterfaces
{
    [ServiceContract]
    public interface ITrace
    {
        [OperationContract]
        void Trace(TraceClass Message);

        [OperationContract]
        List<TraceClass> GetTrace();
    }
}
