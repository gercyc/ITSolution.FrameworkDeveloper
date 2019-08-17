using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Common.BaseClasses
{
    [Serializable]
    public class ItsServerInfo
    {
        public ItsServerInfo(Type _typedClass)
        {
            TypedClass = _typedClass;
        }

        public Type TypedClass { get; set; }
        public object Instance { get; set; }
        public bool IsOnline { get; set; }
        public ServiceHost Host { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }

    }
}
