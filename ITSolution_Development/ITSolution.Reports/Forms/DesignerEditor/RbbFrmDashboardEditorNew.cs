using System;
using System.Threading.Tasks;
using DevExpress.XtraBars;
using ITSolution.Reports.DaoManager;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using ITSolution.Framework.Common.BaseClasses.Reports;

namespace ITSolution.Reports.Forms.DesignerEditor
{
    public partial class RbbFrmDashboardEditorNew : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DashboardImage dashboardImageAnt;

        public RbbFrmDashboardEditorNew()
        {
            InitializeComponent();
            //Permitir a edição do Query SQL
            this.dashboardDesigner1.DataSourceWizardSettings.EnableCustomSql = true;
        }

        /// <summary>
        /// Alterar um dashboard existente
        /// </summary>
        /// <param name="dashboardImage"></param>
        public RbbFrmDashboardEditorNew(DashboardImage dashboardImage) : this()
        {
            this.dashboardImageAnt = dashboardImage;
        }


        private async void loadDashboard()
        {
            if (dashboardImageAnt.ReportImageData != null)
            {
                
                Task<string> path = Task.Run(() => new DashboardDaoManager().LoadToChache(dashboardImageAnt, true));

                try
                {
                    //Abre o DashboardImage para edição
                    //DashboardDesigner onde será exibido o dashboardImage
                    dashboardDesigner1.Name = dashboardImageAnt.ReportName;
                    dashboardDesigner1.LoadDashboard(await path);
                }
                catch (Exception ex)
                {
                    LoggerUtilIts.GenerateLogs(ex);
                    XMessageIts.Erro("Dashboard não pode ser carregado!");
                }
            }
        }

        private void RbbFrmDashboardEditorNew_Shown(object sender, EventArgs e)
        {
            Task.Run(() => loadDashboard());
        }

        private void barBtnSaveDashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dbManager = new DashboardDaoManager();
            //salve o dashboard
            if (dashboardImageAnt.IdReport == 0)
            {
                dashboardImageAnt = dbManager.SaveDashboard(this.dashboardDesigner1, this.dashboardImageAnt);
                //se o objeto passar a ser diferente de null então foi salvo
                //e agora passarei a editar
                if (dashboardImageAnt != null)
                {
                    XMessageIts.Mensagem("Dashboard salvo com sucesso!");
                }

            }//atualize o dashboard
            else
            {
                if (dbManager.UpdateDashboard(dashboardDesigner1, dashboardImageAnt))
                    XMessageIts.Mensagem("Dashboard atualizado com sucesso!");
            }
        }

    }
}