#pragma warning disable 4014
using ITSolution.Framework.BaseClasses;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using ITSolution.Scheduler.EntidadesBd;
using ITSolution.Scheduler.Enumeradores;
using ITSolution.Scheduler.Manager;
using ITSolution.Scheduler.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LogIts = ITSolution.Scheduler.EntidadesBd.LogIts;

namespace ITSolution.Framework.Server.Scheduler
{
    [ITSolutionServer(typeof(SchedulerController))]
    public partial class SchedulerController : DefaultServer<SchedulerController>, ISchedulerControl
    {
        public SchedulerController() : base("ITSAchedulerkServer")
        {
            InitializeComponent();
        }

        public SchedulerController(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public string CreateTask(TaskIts task, CancellationTokenSource cts)
        {
            try
            {
                var ctx = SchedulerContextGeneric<TaskIts>.Instance;
                ctx.Dao.Save(task);
                return task.IdTask;
            }
            catch (SerializationException se)
            {
                XMessageIts.ExceptionMessageDetails(se, "Erro");
                return "Ocorreu um erro!\n" + se.Message;

            }
            catch (Exception ex)
            {
                return "Ocorreu um erro!\n" + ex.Message;
            }
        }

        private void DoWorkTask(string idTask)
        {
            Task _result = null;
            try
            {
                var ctx = SchedulerContextGeneric<TaskIts>.Instance;
                var taskBd = ctx.Dao.Find(idTask);
                var msg = "Tarefa finalizada.";

                InsertLogTask(new LogIts(idTask, Thread.CurrentThread.ManagedThreadId.ToString(), msg, string.Empty));
                //Muda o status da tarefa, data de execucao e salva
                taskBd.StatusTask = TaskStatusIts.Finalizada;
                taskBd.DtTermino = DateTime.Now;
                _result = Task.Factory.StartNew(() => { ctx.Dao.Update(taskBd); });
            }
            catch (Exception ex)
            {
                InsertLogTask(new LogIts(idTask, Thread.CurrentThread.ManagedThreadId.ToString(), string.Empty, ex.Message));
            }
        }

        public async void Execute(string idtask, CancellationTokenSource cancellationToken)
        {
            var task = GetTaskById(idtask);

            if (task != null)
            {
                LogIts log;
                try
                {
                    var lst = SerializeIts.DeserializeObject<List<TaskParamIts>>(task.Tarefa);
                    //inicia
                    StartTask(task.IdTask, cancellationToken);

                    InsertLogTask(new LogIts(task.IdTask, "Obtendo o tipo..."));
                    // Execute the task
                    //var cl = Assembly.LoadFile(@"C:\Users\Gercy\Documents\TFS_ITsolution\ITE\ITE.Entidades\bin\Debug\ITE.Entidades.dll");
                    //var qname = typeof(cl.Assembly);
                    var typeName = Type.GetType(task.Classe);

                    object instance = Activator.CreateInstance(typeName, task.IdTask);

                    InsertLogTask(new LogIts(task.IdTask, "Classe: " + task.Classe));
                    InsertLogTask(new LogIts(task.IdTask, "Metodo: " + task.Metodo));

                    var methodInfo = typeName.GetMethod(task.Metodo);
                    var param = methodInfo.GetParameters();
                    int i = 0;

                    List<TaskParamIts> parametrosTask = SerializeIts.DeserializeObject<List<TaskParamIts>>(task.Tarefa);
                    dynamic[] parmOrigs22 = new dynamic[parametrosTask.Count];

                    InsertLogTask(new LogIts(task.IdTask, "Parametros:"));


                    foreach (var item in parametrosTask)
                    {
                        if (item.ParameterValue.ToString() == "System.Threading.CancellationTokenSource")
                        {
                            parmOrigs22[i] = cancellationToken;
                        }
                        else
                        {
                            log = new LogIts(task.IdTask, Thread.CurrentThread.ManagedThreadId.ToString(),
                                            item.ParameterName.ToString()
                                            + ": " + item.ParameterValue.ToString(), String.Empty);

                            //insere log
                            InsertLogTask(log);
                            var stp = item.ParameterType.AssemblyQualifiedName;
                            var tp = Type.GetType(stp);
                            parmOrigs22[i] = item.ParameterValue;
                            //parmOrigs22[i] = Convert.ChangeType(item.ParameterValue,
                            //     tp);
                        }
                        i++;
                    }
                    //object[] parmOrigs = new object[] { 1000, task.IdTask, cts };
                    try
                    {
                        Task t1 = new Task(() =>
                        {
                            methodInfo.Invoke(instance, parmOrigs22);
                        });

                        await Task.Factory.StartNew(() => t1.Start());

                        Task ok = await Task.WhenAny(t1);
                        if ((ok.IsCompleted && ok.Exception == null) && !cancellationToken.IsCancellationRequested)
                        {
                            //Work task
                            DoWorkTask(task.IdTask);
                        }
                        if (ok.Exception != null)
                        {
                            var msg = ok.Exception.InnerExceptions.First();

                            throw new Exception(msg.InnerException.Message);
                        }

                        if (cancellationToken.IsCancellationRequested)
                            throw new OperationCanceledException("Operação cancelada.");
                    }
                    catch (OperationCanceledException exCancel)
                    {
                        log = new LogIts(task.IdTask,
                        Thread.CurrentThread.ManagedThreadId.ToString(),
                        exCancel.Message
                        , "Operacao cancelada");
                        InsertLogTask(log);
                        SuspendTask(task.IdTask);

                    }
                    catch (TargetInvocationException tex)
                    {
                        log = new LogIts(task.IdTask,
                        Thread.CurrentThread.ManagedThreadId.ToString(),
                        tex.Message
                        , tex.Message);
                        InsertLogTask(log);
                        StoppedTaskException(task.IdTask);
                    }
                    catch (Exception ex)
                    {
                        log = new LogIts(task.IdTask,
                        Thread.CurrentThread.ManagedThreadId.ToString(),
                        ex.Message
                        , ex.Message);
                        InsertLogTask(log);
                        StoppedTaskException(task.IdTask);
                    }

                }//fim try
                catch (Exception ex)
                {
                    log = new LogIts(task.IdTask,
                        Thread.CurrentThread.ManagedThreadId.ToString(),
                        ex.Message
                        , ex.Message);
                    InsertLogTask(log);
                    StoppedTaskException(task.IdTask);
                }
            }

        }

        private TaskIts GetTaskById(string idTask)
        {
            try
            {
                var ctx = SchedulerContextGeneric<TaskIts>.Instance;
                //ctx.ProxyCreation(false);
                var taskBd = ctx.Dao.Find(idTask);
                return taskBd;
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Falha ao obter a tarefa pelo ID");
                return null;
            }
        }

        private Task InsertLogTask(LogIts log)
        {
            var ctx = SchedulerContextGeneric<LogIts>.Instance;
            return ctx.Dao.SaveAsync(log);
        }

        public void StartTask(string idTask, CancellationTokenSource cts)
        {
            try
            {
                var ctx = SchedulerContextGeneric<TaskIts>.Instance;
                var taskBd = ctx.Dao.Find(idTask);
                var msg = "Obtendo paramentros da tarefa, aguarde..";
                InsertLogTask(new LogIts(idTask, Thread.CurrentThread.ManagedThreadId.ToString(), msg, String.Empty));
                ScheduleTask(idTask);
                ctx.Dao.Update(taskBd);

                var result = Task.Delay(5000);
                if (result != null)
                {
                    msg = "Iniciando tarefa..";
                    InsertLogTask(new LogIts(idTask, Thread.CurrentThread.ManagedThreadId.ToString(), msg, String.Empty));

                    //Muda o status da tarefa, data de execucao e salva
                    taskBd.StatusTask = TaskStatusIts.Executando;
                    taskBd.DtInicio = DateTime.Now;
                    taskBd.DtTermino = null;
                    ctx.Dao.Update(taskBd);
                }
            }
            catch (OperationCanceledException)
            {
                SuspendTask(idTask);
            }
            catch (Exception ex)
            {
                InsertLogTask(new LogIts(idTask, "", string.Empty, ex.Message));
            }
        }

        public void SuspendTask(string idTask)
        {
            try
            {
                var ctx = SchedulerContextGeneric<TaskIts>.Instance;
                var taskBd = ctx.Dao.Find(idTask);
                var msgCancel = "Tarefa cancelada pelo usuário.";
                InsertLogTask(new LogIts(idTask, Task.CurrentId.ToString(), msgCancel, ""));

                //Muda o status da tarefa, data de execucao e salva
                taskBd.StatusTask = TaskStatusIts.Suspensa;
                taskBd.DtTermino = DateTime.Now;
                ctx.Dao.Update(taskBd);
            }
            catch (Exception ex)
            {
                InsertLogTask(new LogIts(idTask, Task.CurrentId.ToString(), string.Empty, ex.Message));
            }
        }

        private void StoppedTaskException(string idTask)
        {
            Task _result = null;
            try
            {
                var ctx = SchedulerContextGeneric<TaskIts>.Instance;
                var taskBd = ctx.Dao.Find(idTask);
                var msg = "Não foi possível concluír a tarefa escolhida. Verifique com o administrador!";

                InsertLogTask(new LogIts(idTask, Thread.CurrentThread.ManagedThreadId.ToString(), msg, string.Empty));
                //Muda o status da tarefa, data de execucao e salva
                taskBd.StatusTask = TaskStatusIts.Erro;
                taskBd.DtTermino = DateTime.Now;
                _result = Task.Factory.StartNew(() => ctx.Dao.UpdateAsync(taskBd));
            }
            catch (Exception ex)
            {
                InsertLogTask(new LogIts(idTask, Thread.CurrentThread.ManagedThreadId.ToString(), string.Empty, ex.Message));
            }
        }
        private void ScheduleTask(string idTask)
        {
            Task result = null;
            try
            {
                var ctx = SchedulerContextGeneric<TaskIts>.Instance;
                var taskBd = ctx.Dao.Find(idTask);
                //Muda o status da tarefa, data de execucao e salva
                taskBd.StatusTask = TaskStatusIts.Agendada;
                result = Task.Factory.StartNew(() => ctx.Dao.UpdateAsync(taskBd));
            }
            catch (Exception ex)
            {
                InsertLogTask(new LogIts(idTask, Task.CurrentId.ToString(), "Ocorreu um erro na tentativa de agendar a tarefa!", ex.Message));
            }
        }

        public TaskIts[] GetTaskList()
        {
            var ctx = SchedulerContext.Instance;
            ctx.ProxyCreation(false);

            return ctx.TasksIts.AsNoTracking().ToArray();
        }
    }
}
