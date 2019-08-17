using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseClasses.Trace
{
    public class MemoryTraceListener : TraceServerListener
    {
        public MemoryTraceListener() : base()
        {
        }
        protected override void Write(TraceClass info)
        {
            TraceData.Enqueue(info);
        }
        protected override void SecThread(object O, bool flag)
        {
            lock (this)
            {
                ;
            }
        }
        public void CreateThread(MemoryTraceListener SecClass)
        {
            AutoResetEvent arev = new AutoResetEvent(false);
            ThreadPool.RegisterWaitForSingleObject(arev, new WaitOrTimerCallback(SecThread), SecClass, 1000, false);
            arev.Set();
        }

        public override void Write(string message)
        {
            InternalWrite(message);
        }

        public override void WriteLine(string message)
        {
            InternalWrite(message);
        }
        internal void InternalWrite(string message)
        {
            TraceData.Enqueue(new TraceClass() { Message = message });
        }
        public override string ToString()
        {
            return string.Format("MemoryTraceListener: ListenerId: '{0}'", ListenerId);
        }
    }
}
