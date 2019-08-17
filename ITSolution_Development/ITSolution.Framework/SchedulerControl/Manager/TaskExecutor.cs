using System;

namespace ITSolution.Scheduler.Manager
{
    public class TaskExecutor<T>  
    {
        public string Name { get; set; }
        public Action<T> Action { get; set; }

        public void Execute(T t)
        {
            Action(t);

        }
    }
}
