using ITSolution.Framework.BaseClasses.Trace;
using ITSolution.Framework.Common.BaseClasses;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseClasses
{
    public static class StaticInfo
    {
        static MemoryTraceListener memoryTraceListener;
        static ConcurrentDictionary<string, string> _Onlinesessions;

        public static void StartStatic()
        {
            if (memoryTraceListener == null)
            {
                memoryTraceListener = (MemoryTraceListener)Activator.CreateInstance(typeof(MemoryTraceListener));
            }
            memoryTraceListener.CreateThread(memoryTraceListener);
            TraceServerListener.Get<MemoryTraceListener>(Consts.InternalFrameworkSession);
            //TraceServer.Listeners.Add(memoryTraceListener);
            if (_Onlinesessions == null)
                _Onlinesessions = new ConcurrentDictionary<string, string>();

            CheckSessions();
        }
        public static void CheckSessions()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Factory.StartNew(() =>
                    {
                        Check();

                    });
                    //aguarda 1min
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                }
            });

        }
        private static void Check()
        {
            Thread.CurrentThread.Name = "Check WCF connections!";
            TraceServer.Trace(new TraceClass()
            {
                Message = "Checking WCF channels greater equal to 59 seconds...",
                Action = "Check channels",
                ExecutingAssembly = Assembly.GetExecutingAssembly().FullName
            });

            foreach (var obj in ITSActivator.Instances)
            {
                ConnectionInfo conn = ((ConnectionInfo)obj.Key);
                TimeSpan dif = DateTime.Now - conn.ConnectionDate;

                if (dif.Seconds >= 59)
                {
                    object outremove;
                    ((IContextChannel)obj.Value).Close();
                    ITSActivator.Instances.TryRemove(obj.Key, out outremove);
                }
            }

        }
        public static bool RegisterSession(string sessionID)
        {
            return _Onlinesessions.TryAdd(sessionID, Guid.NewGuid().ToString());
        }
        public static bool UnRegisterSession(string sessionID)
        {
            string removed = string.Empty;
            return _Onlinesessions.TryRemove(sessionID, out removed);
        }
    }
}
