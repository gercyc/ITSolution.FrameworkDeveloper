using ITSolution.Framework.Common.BaseClasses;

namespace ITSolution.Framework.BaseInterfaces
{
    public interface IWCFConnector
    {
        ConnectionInfo ConnectionInfo { get; set; }
        object GetObject();
        void CloseConnection();
    }
}