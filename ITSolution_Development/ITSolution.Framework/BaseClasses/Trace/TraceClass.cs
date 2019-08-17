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

namespace ITSolution.Framework.BaseClasses.Trace
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class TraceClass
    {
        public string Message { get; set; }
        public string Action { get; set; }
        public string ExecutingAssembly { get; set; }
        public DateTime TraceDate { get { return DateTime.Now; } }
        public override string ToString()
        {
            return string.Format("{0} | Message: '{1}' | Action: '{2}' | Assembly: '{3}'", TraceDate, Message, Action, ExecutingAssembly);
        }
    }
}
