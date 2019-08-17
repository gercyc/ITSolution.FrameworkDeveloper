using System;
using DevExpress.XtraBars;
using DevExpress.DataAccess.Sql;
using ITSolution.Reports.Util;
using DevExpress.XtraReports.UserDesigner;
using ITSolution.Reports.DaoManager;
using ITSolution.Framework.Util;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Common.BaseClasses.Reports;

namespace ITSolution.Reports.Forms.DesignerEditor
{
    public partial class RbbFrmReportEditorNew : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private ReportImage reportImageAnt;
        private SqlDataSource sqlDataSource;

        private RbbFrmReportEditorNew()
        {
            InitializeComponent();
            reportDesigner1.SqlWizardSettings.EnableCustomSql = true;
        }

        /// <summary>
        /// Criar/Alterar relatorio carregado para o cache
        /// </summary>
        /// <param name="reportImageAnt"></param>
        public RbbFrmReportEditorNew(ReportImage reportImageAnt)
            : this()
        {

            this.reportImageAnt = reportImageAnt;

            try
            {
                if (reportImageAnt.IdReport == 0)
                {
                    reportDesigner1.CreateNewReport();
                    reportDesigner1.ActiveDesignPanel.Report.DisplayName = reportImageAnt.ReportDescription;

                }
                else
                {
                    //abri o relatório selecionado
                    var path = new ReportDaoManager().LoadToCache(this.reportImageAnt);
                    reportDesigner1.OpenReport(path);
                    reportDesigner1.ActiveDesignPanel.Name = this.reportImageAnt.ReportName;
                    reportDesigner1.ActiveDesignPanel.Report.Name = this.reportImageAnt.ReportName;

                }
                this.sqlDataSource = new SqlDataSource(ReportUtil.GetParamDataSource());
                reportDesigner1.ActiveDesignPanel.Report.DataSource = sqlDataSource;

            }
            catch (Exception ex)
            {
                LoggerUtilIts.GenerateLogs(ex);
            }
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (reportImageAnt == null || reportImageAnt.IdReport == 0)
            {
                //persiste o objeto no banco
                this.reportImageAnt = new ReportDaoManager().SaveReport(reportDesigner1, reportImageAnt);

                //se o objeto passar a ser diferente de null então foi salvo
                //e agora passarei a editar
                if (reportImageAnt != null)
                {
                    XMessageIts.Mensagem("Relatório salvo com sucesso!");
                }
            }
            else
            {
                //seta o nome do relatorio no design
                reportDesigner1.ActiveDesignPanel.Report.Name = reportImageAnt.ReportName ;
                //prevent "Report has been changed"
                reportDesigner1.ActiveDesignPanel.ReportState = ReportState.Saved;

                //atualiza o relatorio no banco
                if (new ReportDaoManager().UpdateReport(reportDesigner1, reportImageAnt))
                {
                    XMessageIts.Mensagem("Relatório atualizado com sucesso!");
                }
            }

        }

        private void btnSaveDisco_ItemClick(object sender, ItemClickEventArgs e)
        {
            reportDesigner1.ActiveDesignPanel.SaveReportAs();
        }
    }
}