using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Mensagem;
using ITSolution.Reports.Forms.DesignerEditor;
using ITSolution.Reports.Forms.View;
using ITSolution.Reports.DaoManager;
using ITSolution.Reports.Repositorio;
using ITSolution.Reports.Util;
using ITSolution.Framework.Common.BaseClasses.Reports.Enumeradores;
using ITSolution.Framework.Common.BaseClasses.Reports;

namespace ITSolution.Reports.Forms.ListView
{
    public partial class XFrmDashboardListView : DevExpress.XtraEditors.XtraForm
    {

        private TypeGroupUser _group;

        /// <summary>
        /// Dados do usuário
        /// </summary>
        /// <param name="group"></param>
        public XFrmDashboardListView(TypeGroupUser group)
        {
            this._group = group;
            InitializeComponent();
        }
        private async Task loadDashboards()
        {
            using (var ctx = new ReportContext())
            {
                var result = await ctx.DashboardImageDao.FindAllAsync();

                gridControl1.DataSource = result;
                this.gridView1.ExpandAllGroups();
            }
        }

        //load reports
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XFrmWait.StartTask(loadDashboards(), "Carregando Dashboards");
        }

        //Editar relatorio selecionado
        private void btnEditDashboard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsSelectOneRowWarning())
            {
                //guarda a ref do dash
                var dashboardSelect = gridView1.GetFocusedRow() as DashboardImage;
                
                if (ReportUtil.IsEditReport(dashboardSelect, _group))
                {
                    XFrmAddReport xFrmAddReport = new XFrmAddReport(dashboardSelect);
                    if (barChEditarDashboard.Checked == false)
                    {
                        xFrmAddReport.ShowDialog();

                        //atualiza o nome do relatorio
                        dashboardSelect = xFrmAddReport.DashboardImage;
                    }
                    else
                    { 
                        //chame o relatorio diretamente
                        dashboardSelect = xFrmAddReport.CreateDashboard();

                    }

                    if (!xFrmAddReport.IsCancelado)
                        new RbbFrmDashboardEditorNew(dashboardSelect).Show();

                    gridView1.RefreshData();

                }
                else
                {
                    //senão, exibe mensagem informando da falta de permissao
                    XMessageIts.Erro("Você não possui permissão para editar dashboard do sistema!");
                }

            }
        }


        //Inicia o report designer para criação de novo relatório
        private void btnNovoRelatorio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //informa os dados do usuario e o tipo de relatório a ser chamado
            var xFrmAddReport = new XFrmAddReport(TypeReport.Dashboard);

            xFrmAddReport.ShowDialog();

            if (xFrmAddReport.IsCancelado == false)
            {
                //recupera os dashboard
                var dashboardImage = xFrmAddReport.DashboardImage;

                if (dashboardImage != null)
                    //use os dados do dashboardImage para criar um nome dashboard
                    new RbbFrmDashboardEditorNew(dashboardImage).Show();
                else
                    XMessageIts.Erro("Dashboard não foi carregado corretamente.");
            }
        }

        private void XFrmDashboardList_Shown(object sender, EventArgs e)
        {
            btnRefresh_ItemClick(null, null);
        }

        private void btnRemoverEstrutura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dash = gridView1.GetFocusedRow() as DashboardImage;
            if (dash != null)
            {
                var dialogResult = XMessageIts.Confirmacao("Tem certeza que deseja excluir o Dashboard selecionado ?");

                if (dialogResult == DialogResult.Yes)
                {
                    new DashboardDaoManager().RemoveDashboard(dash);
                    btnRefresh_ItemClick(null, null);
                }
            }

        }

        private void btnVisualizarDashboard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsSelectOneRowWarning())
            {
                var dashSelected = gridView1.GetFocusedRow() as DashboardImage;
                if (dashSelected != null)
                {
                    //se usuario do grupo Administrador e grupo = Sistema
                    new RbbFrmDashboardView(dashSelected).Show();
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnVisualizarDashboard_ItemClick(null, null);
        }

        private void btnExportEstrutura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var reports = gridView1.GetSelectedItens<DashboardImage>();

            if (reports.Count > 1)
            {
                ReportUtil.ExportDashboardList(reports);
            }
            else
            {
                if (gridView1.IsSelectOneRowWarning())
                {
                    var dash = gridView1.GetFocusedRow<DashboardImage>();
                    ReportUtil.ExportDashaboard(dash);
                }

            }


        }

        private void btnImportEstrutura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportUtil.ImportDashboard();
        }

        private void barBtnClearCache_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var op = XMessageIts.Confirmacao("Deseja remover todos os dashboards em disco ?", "Atenção");
            if (op == DialogResult.Yes)
                new DashboardDaoManager().ClearCache();

        }

        private void barCopyEstrutura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsSelectOneRowWarning())
            {
                var dash = gridView1.GetFocusedRow<DashboardImage>();
                ReportUtil.DuplicateDashboard(dash);
            }
        }
    }
}