using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Scheduler.EntidadesBd
{
    [Serializable]
    public class TaskParamIts
    {
        public int IdParam { get; set; }
        public Type ParameterType { get; set; }
        public string ParameterName { get; set; }
        public dynamic ParameterValue { get; set; }
        
        public TaskParamIts()
        {

        }
        public TaskParamIts(Type ParameterType, string ParameterName, object ParameterValue)
        {
            this.ParameterType = ParameterType;
            this.ParameterName = ParameterName;
            this.ParameterValue = ParameterValue;
        }
    }
}
