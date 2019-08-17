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
using ITSolution.Framework.Arquivos;

namespace ITSolution.Framework.SchedulerControl.Forms
{
    public partial class XFrmTaskLogViewer : DevExpress.XtraEditors.XtraForm
    {
        private List<LogIts> log;
        public XFrmTaskLogViewer()
        {
            InitializeComponent();
        }
        public XFrmTaskLogViewer(TaskIts tarefa) : this()
        {
            var ctx = Scheduler.Repositorio.SchedulerContext.Instance;

            gridControl1.DataSource = ctx.LogItsDao.Where(l=>l.IdTask ==  tarefa.IdTask).OrderBy(l => l.DataLog);
            lbTask.Caption = tarefa.DescricaoTarefa + " ID: " + tarefa.IdTask;
            log = tarefa.TaskDetails.ToList();
        }

        private void btnSaveLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files | *.txt";
            saveFileDialog.FileName = "Log de execução";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileManagerIts.CreateFile(saveFileDialog.FileName);

                foreach (var line in log.OrderBy(l=>l.DataLog))
                {
                    var msg = line.DataLog + " - "+ line.Mensagem;
                    FileManagerIts.OverWriteOnFile(saveFileDialog.FileName, msg);
                }
            }

        }
    }
}