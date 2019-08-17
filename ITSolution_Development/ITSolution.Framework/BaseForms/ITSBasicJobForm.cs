using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ITSolution.Scheduler.EntidadesBd;
using ITSolution.Scheduler.Manager;
using ITSolution.Framework.Common.BaseClasses;
using System.Threading;
using ITSolution.Framework.BaseInterfaces;
using ITSolution.Framework.GuiUtil;

namespace ITSolution.Framework.BaseForms
{
    public partial class ITSBasicJobForm : ITSTransaction, IJobCreator
    {
        private ItsControl itsControl;

        public ITSBasicJobForm(ItsControl control)
        {
            InitializeComponent();
            this.itsControl = control;

            Init();
        }

        private void Init()
        {
            pnlParameters.Controls.Add(GetUserControlParameters());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ISchedulerControl scd = ITSActivator.OpenConnection<ISchedulerControl>(Consts.FrameworkSchedulerClass);
            scd.CreateTask(GetUserControlParameters().IndexScheduleJob(), new CancellationTokenSource());
            this.Close();
        }

        public virtual ItsControl GetUserControlParameters()
        {
            if (itsControl == null)
                itsControl = new ItsControl();

            return itsControl;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}