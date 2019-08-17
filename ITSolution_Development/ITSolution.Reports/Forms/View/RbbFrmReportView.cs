using DevExpress.XtraReports.UI;

namespace ITSolution.Reports.Forms.View
{
    public partial class RbbFrmReportView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RbbFrmReportView()
        {
            InitializeComponent();
        }

        public RbbFrmReportView(XtraReport report):this()
        {
            this.documentViewer1.DocumentSource = report;
        }
    }
}