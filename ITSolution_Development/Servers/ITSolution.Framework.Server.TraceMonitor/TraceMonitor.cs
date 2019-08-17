using ITSolution.Framework.BaseClasses.Trace;
using ITSolution.Framework.BaseInterfaces;
using ITSolution.Framework.Common.BaseClasses;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseClasses
{
    public class TraceMonitor 
    {
        public static ConcurrentBag<TraceClass> TraceList = new ConcurrentBag<TraceClass>();

        public  List<TraceClass> GetTrace()
        {
            var listener = TraceServerListener.Get<MemoryTraceListener>(Consts.InternalFrameworkSession);
            return listener.Read();
        }

        public  void Trace(TraceClass _Message)
        {
            //Message = _Message.Message;
            //Action = _Message.Action;
            //TraceList.Add(this);
        }
    }
}
