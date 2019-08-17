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
using System.ServiceModel;
using DevExpress.XtraReports.UI;
using ITSolution.Framework.Common.BaseClasses.Reports.Enumeradores;
using ITSolution.Framework.Common.BaseClasses.Reports;

namespace ITSolution.Reports.Forms.ListView
{
    public partial class XFrmReportList : DevExpress.XtraEditors.XtraForm
    {

        private TypeGroupUser _group;
        public XFrmReportList(TypeGroupUser group)
        {
            this._group = group;
            InitializeComponent();

        }

        private async Task loadReports()
        {
            using (var ctx = new ReportContext())
            {
                var result = await ctx.ReportImageDao.FindAllAsync();

                gridControl1.DataSource = result;

                this.gridView1.ExpandAllGroups();

            }
        }

        //load reports
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XFrmWait.StartTask(loadReports(), "Carregando Relatórios");
        }

        //Editar relatorio selecionado
        private void btnEditReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsSelectOneRowWarning())
            {
                ReportImage reportSelect = gridView1.GetFocusedRow<ReportImage>();

                if (ReportUtil.IsEditReport(reportSelect, _group))
                {
                    XFrmAddReport xFrmAddReport = new XFrmAddReport(reportSelect);

                    if (barChEditarReport.Checked == false)
                    {
                        xFrmAddReport.ShowDialog();

                        //atualiza o nome do relatorio
                        reportSelect = xFrmAddReport.ReportImage;
                    }
                    else
                    {
                        //chame o relatorio diretamente
                        reportSelect = xFrmAddReport.CreateReport();
                    }

                    if (!xFrmAddReport.IsCancelado && reportSelect != null)
                    {
                        new RbbFrmReportEditorNew(reportSelect).Show();

                        //atualiza na tabela
                        reportSelect.ReportDescription = xFrmAddReport.ReportImage.ReportDescription;

                        gridView1.RefreshData();
                    }
                }
                else
                {
                    //senão, exibe mensagem informando da falta de permissao
                    XMessageIts.Erro("Você não possue permissão para editar relatórios do sistema!");
                }
            }
        }

        //Gerar o relatorio selecionado
        private void btnGerarRelatorio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.IsSelectOneRowWarning())
            {
                try
                {
                    var rptSelected = gridView1.GetFocusedRow() as ReportImage;
                    //Gercy:06/04/2017. classe static para leitura do parametro no banco e exibir conforme opcao escolhida.
                    //Filipe: 11/04/17 - Utiliza classe que ja existe
                    //Obs: Classes estaticas são custosas
                    ReportUtil.PrintReportAndGenerateSpool(rptSelected);

                    //var rptServer = new ReportServer.ReportContractClient();
                    //rptServer.PrintReport(rptSelected.IdReport);
                    //var rpt = rptServer.GetReport(rptSelected.IdReport);

                    //Console.WriteLine("Para");

                }
                catch (Exception ex)
                {
                    XMessageIts.ExceptionMessageDetails(ex, "Erro ao gerar o relatório");
                }
            }

        }

        //Inicia o report designer para criação de novo relatório
        private void btnNovoRelatorio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XFrmAddReport xFrmAddReport = new XFrmAddReport(TypeReport.Report);

            xFrmAddReport.ShowDialog();

            if (xFrmAddReport.IsCancelado == false)
            {

                //atualiza o dashboard
                var reportImage = xFrmAddReport.ReportImage;

                if (reportImage != null)
                {
                    //se usuario do grupo Administrador e grupo = Sistema
                    new RbbFrmReportEditorNew(reportImage).Show();
                }
                else
                {
                    XMessageIts.Erro("Relatório não foi carregado corretamente.");
                }
            }
        }

        private void XFrmReportList_Shown(object sender, EventArgs e)
        {
            btnRefresh_ItemClick(null, null);
        }

        private void btnRemoverEstrutura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var relat = gridView1.GetFocusedRow() as ReportImage;
            if (relat != null)
            {
                var message = "Tem certeza que deseja excluir a estrutura selecionada?";
                var dialogResult = XMessageIts.Confirmacao(message);
                if (dialogResult == DialogResult.Yes)
                {
                    new ReportDaoManager().RemoveReport(relat);
                    btnRefresh_ItemClick(null, null);
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnGerarRelatorio_ItemClick(null, null);
        }

        private void btnExportEstrutura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var reports = gridView1.GetSelectedItens<ReportImage>();

            if (reports.Count > 1)
            {
                ReportUtil.ExportReportList(reports);
            }
            else
            {
                if (gridView1.IsSelectOneRowWarning())
                {
                    var rpt = gridView1.GetFocusedRow<ReportImage>();
                    //encapsulado
                    ReportUtil.ExportReport(rpt);
                }
            }
        }

        private void btnImportEstrutura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportUtil.ImportReport();
        }

        private void barBtnClearCache_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var op = XMessageIts.Confirmacao("Deseja remover todos os relátorios em disco ?", "Atenção");
            if (op == DialogResult.Yes)
                new ReportDaoManager().ClearCache();
        }

        private void btnCopyEstrutura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (gridView1.IsSelectOneRowWarning())
            {
                var rpt = gridView1.GetFocusedRow<ReportImage>();
                //encapsulado
                ReportUtil.DuplicateReport(rpt);
            }

        }
    }
}
