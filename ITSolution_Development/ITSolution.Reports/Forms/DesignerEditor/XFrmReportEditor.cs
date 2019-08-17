using DevExpress.XtraReports.UserDesigner;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using ITSolution.Reports.DaoManager;
using System;
using System.Windows.Forms;
using ITSolution.Framework.Common.BaseClasses.Reports;

namespace ITSolution.Reports.Forms.DesignerEditor
{
    public partial class XFrmReportEditor : DevExpress.XtraEditors.XtraForm
    {
        private ReportImage _reportImageAnt;
        private string _descricaoRelatorio;
        private int _idGrupoRelatorio;

        private XFrmReportEditor()
        {
            InitializeComponent();
            itsReportDesign.SqlWizardSettings.EnableCustomSql = true;
        }

        /// <summary>
        /// Criar novo relatorio
        /// </summary>
        /// <param name="formTypeAction"></param>
        public XFrmReportEditor(string descricaoRelatorio, int idGrupoRelatorio)
            : this()
        {
            this._idGrupoRelatorio = idGrupoRelatorio;
            this._descricaoRelatorio = descricaoRelatorio;
            itsReportDesign.CreateNewReport();
            itsReportDesign.ActiveDesignPanel.Report.DisplayName = descricaoRelatorio;
        }


        /// <summary>
        /// Editar relatorio carregado para o cache
        /// <param name="reportImage"></param>Objeto de relatório
        public XFrmReportEditor(ReportImage reportImage)
                : this()
        {
            this._reportImageAnt = reportImage;

        }


        private void XFrmReportEditor_Load(object sender, EventArgs e)
        {
            if (_reportImageAnt != null)
            {

                //roda em segundo plano
                // Task.Factory.StartNew(wait.Run).RunSynchronously();

                //new Thread(wait.Run).Start();

                try
                {
                    /// Abrir o relatório selecionado            
                    //Abre o relatorio que foi armazenado no cache
                    var path = new ReportDaoManager().LoadToCache(_reportImageAnt);
                    itsReportDesign.OpenReport(path);
                }
                catch (Exception ex)
                {
                    LoggerUtilIts.GenerateLogs(ex);
                }
            }

        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_reportImageAnt == null)
            {
                
                var newReport = new ReportImage(_descricaoRelatorio, _idGrupoRelatorio);

                //persiste o objeto no banco
                this._reportImageAnt = new ReportDaoManager().SaveReport(itsReportDesign, newReport);

                //se o objeto passar a ser diferente de null então foi salvo
                //e agora passarei a editar
                if (_reportImageAnt != null)
                {
                    XMessageIts.Mensagem("Relatório salvo com sucesso!");
                }

            }
            else
            {
                //esse comando nao funciona
                itsReportDesign.ActiveDesignPanel.Report.Name = _reportImageAnt.ReportName;

                //prevent "Report has been changed"
                itsReportDesign.ActiveDesignPanel.ReportState = ReportState.Saved;

                //atualiza o relatorio no banco
                if (new ReportDaoManager().UpdateReport(itsReportDesign, _reportImageAnt))
                {
                    XMessageIts.Mensagem("Relatório atualizado com sucesso!");
                }
            }
        }

        private void XFrmReportEditor_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void commandBarSaveAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnSalvar_ItemClick(null, null);
        }

    }
}