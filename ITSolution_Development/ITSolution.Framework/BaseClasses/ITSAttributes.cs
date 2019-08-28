using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseClasses
{
    public class ITSolutionServerAttribute : Attribute
    {
        public Type TypeServer { get; private set; }
        public ITSolutionServerAttribute(Type _typeServer)
        {
            this.TypeServer = _typeServer;
        }
    }
    public class ITSolutionStartupAttribute : Attribute
    {

    }
    public class TransactionITSAttribute : Attribute
    {
        public string TransactionID { get; private set; }
        public TransactionITSAttribute(string TransactionId)
        {
            TransactionID = TransactionId;
        }
    }
}
