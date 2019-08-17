using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseClasses.Trace
{
    public abstract class TraceServerListener : TraceListener
    {
        public TraceServerListener()
        {

        }
        protected virtual void SecThread(object O, bool flag)
        {

        }

        protected new ConcurrentQueue<TraceClass> TraceData = new ConcurrentQueue<TraceClass>();
        public virtual List<TraceClass> Read()
        {
            List<TraceClass> result = new List<TraceClass>();
            while (TraceData.Count > 0)
            {
                TraceClass info;
                if (TraceData.TryDequeue(out info))
                    result.Add(info);
            }
            return result;
        }

        public string ListenerId { get; set; }
        public void Initialize(string sessionid)
        {
            ListenerId = sessionid;
        }
        public void UnRegister()
        {
            TraceServerListener listener;
            TraceServer.Listeners.TryTake(out listener);
        }
        public static void Register(TraceServerListener listener)
        {
            TraceServer.Register(listener);
        }
        public static TraceServerListener Find(Func<TraceServerListener, bool> predicate)
        {
            return TraceServer.Listeners.Where(predicate).FirstOrDefault();
        }
        protected abstract void Write(TraceClass info);

        public virtual void DoWrite(TraceClass info)
        {
            Write(info);
        }

        public static TraceServerListener Get<T>(string sessionId) where T : TraceServerListener, new()
        {
            TraceServerListener listener = Find(item => item.ListenerId == sessionId);
            if (listener != null)
            {
                if (listener is T)
                    return listener;
                else
                    listener.UnRegister();
            }

            listener = new T();
            listener.Initialize(sessionId);
            Register(listener);
            return listener;
        }
    }
}
