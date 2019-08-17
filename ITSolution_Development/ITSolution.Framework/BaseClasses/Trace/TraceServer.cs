using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseClasses.Trace
{
    public static class TraceServer
    {
        private static void WriteListeners(TraceClass info)
        {
            try
            {
                foreach (TraceServerListener listerner in Listeners)
                    listerner.DoWrite(info);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Trace(TraceClass msg)
        {
            var task = System.Threading.Tasks.Task.Factory.StartNew(() => { WriteListeners(msg); });
        }
        internal static ConcurrentBag<TraceServerListener> Listeners = new ConcurrentBag<TraceServerListener>();
        public static void Register(TraceServerListener listener)
        {
            Listeners.Add(listener);
        }
    }
}
