using ITSolution.Framework.Common.BaseClasses;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Mensagem;
using ITSolution.Scheduler.Manager;
using ITSolution.Scheduler.Repositorio;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Windows.Forms;

namespace ITSolution.Scheduler.Forms
{
    public partial class XFrmAddNewTask : DevExpress.XtraEditors.XtraForm
    {
        private CancellationTokenSource cts;
        private ItsControl control;
        private ITSolution.Scheduler.EntidadesBd.TaskIts task;

        public XFrmAddNewTask()
        {
            InitializeComponent();
            var ctx = SchedulerContextGeneric<ITSolution.Scheduler.EntidadesBd.ProcessIts>.Instance;
            cbProcesso.Properties.Items.AddRange(ctx.Dao.FindAll());
            //FillCbGrupoEventos();
        }
        public XFrmAddNewTask(ItsControl control, string codProcesso) : this()
        {
            try
            {
                this.control = control;
                this.panelParams.Controls.Add(control);
                this.panelParams.Controls[0].Dock = DockStyle.Fill;
                var lst = cbProcesso.Properties.Items.Cast<ITSolution.Scheduler.EntidadesBd.ProcessIts>().AsQueryable().Where("CodigoProcesso == @0", codProcesso).First();
                cbProcesso.SelectedItem = lst;

                if (cbProcesso.SelectedItem != null) cbProcesso.ReadOnly = true;

            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
            }

        }

        public XFrmAddNewTask(CancellationTokenSource cts) : this()
        {
            this.cts = cts;
        }
        private ITSolution.Scheduler.EntidadesBd.TaskIts indexarTarefa()
        {
            var proccessSelected = cbProcesso.SelectedItem as ITSolution.Scheduler.EntidadesBd.ProcessIts;
            if (proccessSelected != null)
            {
                memDescProcess.Text = proccessSelected.DescricaoProcesso;

                if (proccessSelected.CodigoProcesso == "INS_TSTE")
                {

                }
                else if (proccessSelected.CodigoProcesso == "FEC_FOLHA")
                {
                    try
                    {
                        //var schedulerControl = new Scheduler.Manager.SchedulerControl();
                        ISchedulerControl scd = ITSActivator.OpenConnection<ISchedulerControl>(Consts.FrameworkSchedulerClass);
                        scd.CreateTask(this.control.SchedulerJob, cts);
                        return this.control.SchedulerJob;
                    }
                    catch (Exception ex)
                    {
                        XMessageIts.ExceptionMessage(ex);
                    }

                }
                return null;
            }
            return null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.task = indexarTarefa();
            this.Close();
        }

        private void cbProcesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadProcesso();
        }

        private void loadProcesso()
        {
            var proccessSelected = cbProcesso.SelectedItem as ITSolution.Scheduler.EntidadesBd.ProcessIts;
            if (proccessSelected != null)
            {
                memDescProcess.Text = proccessSelected.DescricaoProcesso;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void XFrmAddNewTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (chkExecuteImediate.Checked && this.task != null)
            {
                try
                {
                    ISchedulerControl sc = ITSActivator.OpenConnection<ISchedulerControl>(Consts.FrameworkSchedulerClass);
                    this.cts = new CancellationTokenSource();
                    sc.Execute(this.task.IdTask, cts);
                    //using (var scdc = new SchedulerControl())
                    //{
                    //    this.cts = new CancellationTokenSource();
                    //    await scdc.Execute(this.task.IdTask, cts);
                    //}
                }
                catch (Exception ex)
                {
                    XMessageIts.ExceptionMessageDetails(ex, "Erro ao iniciar a tarefa!");
                }
            }
        }
    }
}