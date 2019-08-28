using DevExpress.XtraEditors;
using ITSolution.Scheduler.EntidadesBd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSolution.Framework.GuiUtil
{
    public class ItsControl : XtraUserControl
    {
        public TaskIts SchedulerJob { get; set; }
        public virtual TaskIts IndexScheduleJob() { return null; }
    }

}
