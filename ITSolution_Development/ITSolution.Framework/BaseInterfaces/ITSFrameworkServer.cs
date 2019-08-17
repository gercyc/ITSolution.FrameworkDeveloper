using ITSolution.Framework.BaseClasses;
using ITSolution.Framework.Common.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseInterfaces
{
    /// <summary>
    /// Servidor de aplicação ITS Framework
    /// </summary>
    [ServiceContract]
    public interface ITSFrameworkServer
    {
        string FrameworkHost { get; }

        [ITSolutionStartup]
        void StartServer(string Url);

        [OperationContract]
        List<ItsServerInfo> GetOnlineServers();

        [OperationContract]
        bool RegisterSession(string sessionID);
        [OperationContract]
        bool UnRegisterSession(string sessionID);
    }
}
