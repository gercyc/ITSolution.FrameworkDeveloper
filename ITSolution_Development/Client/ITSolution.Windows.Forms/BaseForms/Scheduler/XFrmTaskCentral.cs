using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraBars;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Beans.Forms;
using System.Threading;
using ITSolution.Scheduler.Manager;
using ITSolution.Scheduler.EntidadesBd;
using ITSolution.Scheduler.Repositorio;
using ITSolution.Framework.Util;
using System.Collections.Generic;
using System.Reflection;
//using ITE.Entidades.DaoManager.RHDaoManager;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.Eventos.GridViewEvents;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.SchedulerControl.Forms;
using ITSolution.Framework.Common.BaseClasses;
using ITSolution.Framework.BaseInterfaces;
using ITSolution.Framework.BaseClasses;

/// <summary>
/// Utiliza invocação de metódos por reflexão
/// 
/// Perda significativa de performace
///
/// </summary>
namespace ITSolution.Scheduler.Forms
{
    [TransactionITS("SchedulerTaskList")]
    public partial class XFrmTaskCentral : DevExpress.XtraBars.Ribbon.RibbonForm, IITSTransaction
    {
        CancellationTokenSource cts;
        private readonly FocusRowChangedEvent _gridFocusUtil;

        public IITSTools ITSTools { get; set; }

        public string TransactionShortcut { get { return "TaskList"; } }

        public TransactionInfo TransactionInfo { get { return new TransactionInfo(); } set { } }

        public XFrmTaskCentral()
        {
            InitializeComponent();
            this._gridFocusUtil = new FocusRowChangedEvent(gridViewTasks);

            btnNewTask.Visibility = BarItemVisibility.Never;
        }
        private async Task carregarTarefas()
        {

            var ctx = SchedulerContextGeneric<ITSolution.Scheduler.EntidadesBd.TaskIts>.Instance;
            var result = await ctx.Dao.FindAllAsync();

            if (result != null)
            {

                gridControlTasks.DataSource = result.OrderByDescending(t => t.DtCriacao);
                this._gridFocusUtil.KeepFocusedRowChanged();
            }

        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ISchedulerControl control = ITSActivator.OpenConnection<ISchedulerControl>(Consts.FrameworkSchedulerClass);
                gridControlTasks.DataSource = control.GetTaskList();

                //var ctx = SchedulerContextGeneric<ITSolution.Scheduler.EntidadesBd.TaskIts>.Instance;

                ////gridControlTasks.DataSource = ctx.Dao.FindAll().OrderByDescending(t => t.DtCriacao);
                //XFrmWait.StartTask(carregarTarefas());
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
            }


        }

        private void btnNewTask_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.cts = new CancellationTokenSource();
            new XFrmAddNewTask(cts).ShowDialog();
            btnRefresh_ItemClick(null, null);
        }

        private void btnRemoverTarefa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var taskSel = GridViewUtil.GetFocusedRow<ITSolution.Scheduler.EntidadesBd.TaskIts>(gridViewTasks);
            var ctx = SchedulerContextGeneric<ITSolution.Scheduler.EntidadesBd.TaskIts>.Instance;
            if (taskSel != null)
            {
                var taskRem = ctx.Dao.Find(taskSel.IdTask);
                ctx.Dao.Delete(taskRem);
                btnRefresh_ItemClick(null, null);
            }
        }

        private void btnDetTarefa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var taskSel = GridViewUtil.GetFocusedRow<ITSolution.Scheduler.EntidadesBd.TaskIts>(gridViewTasks);
            if (taskSel != null)
            {
                new XFrmTaskLogViewer(taskSel).ShowDialog();
            }
        }

        private void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
        }

        private void btnStartExec_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var taskSel = GridViewUtil.GetFocusedRow<ITSolution.Scheduler.EntidadesBd.TaskIts>(gridViewTasks);

                ISchedulerControl sc = ITSActivator.OpenConnection<ISchedulerControl>(Consts.FrameworkSchedulerClass);
                this.cts = new CancellationTokenSource();
                sc.Execute(taskSel.IdTask, cts);
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Erro ao iniciar a tarefa!");
            }
        }

        private void XFrmTaskCentral_Shown(object sender, EventArgs e)
        {
            btnRefresh_ItemClick(null, null);
        }

        public string GetTransactionText()
        {
            return this.Text;
        }
    }
}