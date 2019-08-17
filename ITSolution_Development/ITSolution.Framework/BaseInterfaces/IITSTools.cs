using ITSolution.Framework.BaseClasses;
using ITSolution.Framework.BaseClasses.Trace;
using ITSolution.Framework.BaseForms;
using ITSolution.Framework.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseInterfaces
{
    public interface IITSTools : ActionLogin
    {
        void ShowTransaction(IITSTransaction _itsTransaction);
        void ShowTransactionByShortcut(string _traShortcut);
        T OpenConnection<T>(string Url);
        bool LoginUser(string logon, string senha, out string msg);
        string SessionID { get; }
        void Trace(string Message);
        List<TraceClass> TraceList { get; }
    }
    
}
