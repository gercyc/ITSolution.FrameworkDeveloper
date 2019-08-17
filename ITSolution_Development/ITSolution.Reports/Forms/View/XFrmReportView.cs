using DevExpress.XtraReports.UI;

namespace ITSolution.Reports.Forms.View
{
    public partial class XFrmReportView: DevExpress.XtraEditors.XtraForm
	{
        public XFrmReportView()
		{
            InitializeComponent();
		}

        public XFrmReportView(XtraReport report)
         : this()
        {
            //Seta a source do viewer
            this.documentViewer1.DocumentSource = report;

        }
        /// <summary>
        ///Metodo para disparar o gerador de relatório ou usar com a Thread
        /// </summary>
        public void Run()
        {
            this.Show();
        }

    }
}