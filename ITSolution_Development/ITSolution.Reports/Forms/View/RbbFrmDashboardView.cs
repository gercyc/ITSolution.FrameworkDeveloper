using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using ITSolution.Reports.DaoManager;
using ITSolution.Framework.Util;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Common.BaseClasses.Reports;

namespace ITSolution.Reports.Forms.View
{
    public partial class RbbFrmDashboardView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DashboardImage _dashboardImage;

        public RbbFrmDashboardView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Exibe um dashboard
        /// </summary>
        /// <param name="dashBoardImage"></param>Dashboard a ser visualizado
        public RbbFrmDashboardView(DashboardImage dashBoardImage) : this()
        {
            this._dashboardImage = dashBoardImage;
            showDashboard();

        }

        private bool showDashboard()
        {
            if (this._dashboardImage != null)
            {
                try {

                    new DashboardDaoManager().LoadDashboard(_dashboardImage, dashboardViewer1);
                }
                catch (Exception ex)
                {
                    LoggerUtilIts.GenerateLogs(ex);
                    XMessageIts.Erro("Dashboard não pode ser carregado!");
                }
            }
            return true;

        }

        private async Task<bool> showDashboardAsync()
        {
            return await Task.Run(() => showDashboard());
        }

        private void RbbFrmDashboardView_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

    }
}