using ITSolution.Scheduler.EntidadesBd;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace ITSolution.Scheduler.Manager
{
    [ServiceContract]
    public interface ISchedulerControl
    {
        [OperationContract]
        string CreateTask(TaskIts task, CancellationTokenSource cts);

        [OperationContract]
        void StartTask(string idTask, CancellationTokenSource cts);

        //[OperationContract]
        //Task DoWorkTask(string idTask);

        [OperationContract]
        void SuspendTask(string idTask);

        //[OperationContract]
        //Task InsertLogTask(LogIts log);

        [OperationContract]
        void Execute(string idtask, CancellationTokenSource cancellationToken);

        //[OperationContract]
        //TaskIts GetTaskById(string idTask);

        [OperationContract]
        TaskIts[] GetTaskList();
    }
}
