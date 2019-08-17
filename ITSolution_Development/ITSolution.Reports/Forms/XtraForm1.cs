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
using ITSolution.Reports.Entidades;
using ITSolution.Reports.Managers;
using DevExpress.XtraReports.UserDesigner;
using ITSolution.Framework.Mensagem;

namespace ITSolution.Reports.Forms
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        private ReportImage reportImageAnt;
        private String descricaoRelatorio;
        private ReportGroup grupo;

        public XtraForm1()
        {
            InitializeComponent();
            this.grupo = null;
        }

        /// <summary>
        /// Editar relatorio carregado para o cache
        /// <param name="reportImage"></param>Objeto de relatório
        public XtraForm1(ReportImage reportImage)
            : this()
        {
            this.reportImageAnt = reportImage;
            //abri o relatório selecionado
            //Abre o relatorio que foi armazenado no cache
            var path = new ReportDaoManager().LoadToCache(reportImageAnt);
            reportDesigner1.OpenReport(path);
        }

        /// <summary>
        /// Criar novo relatorio
        /// </summary>
        /// <param name="formTypeAction"></param>
        public XtraForm1(String descricaoRelatorio, ReportGroup grupo)
            : this()
        {
            this.grupo = grupo;
            this.descricaoRelatorio = descricaoRelatorio;
            reportDesigner1.CreateNewReport();
            reportDesigner1.ActiveDesignPanel.Report.DisplayName = descricaoRelatorio;
        }

        //private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    var newReport = new ReportImage(descricaoRelatorio, grupo);

        //    if (reportImageAnt == null)
        //    {
        //        //prevent "Report has been changed"
        //        reportDesigner1.ActiveDesignPanel.ReportState = ReportState.Saved;
        //        //atualiza o relatorio no banco
        //        if (new ReportDaoManager().UpdateReport(reportDesigner1, newReport))
        //        {
        //            XMessageIts.Mensagem("Relatorio atualizado com sucesso!");
        //        }
        //    }
        //    else
        //    {
        //        //persiste o objeto no banco
        //        this.reportImageAnt = new ReportDaoManager().SaveReport(reportDesigner1, newReport);
        //        //se o objeto passar a ser diferente de null então foi salvo
        //        //e agora passarei a editar
        //        if (reportImageAnt != null)
        //        {
        //            XMessageIts.Mensagem("Relatório salvo com sucesso!");
        //        }
        //    }

        //}

        private void RbbFrmReportEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reportImageAnt != null)
            {
                new ReportDaoManager().ClearCache(reportImageAnt);
            }

        }

        private void reportDesigner1_DesignPanelLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        {
            //this.btnSalvar.Enabled = true;
        }

        private void reportDesigner1_AnyDocumentActivated(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            //btnSalvar.Enabled = true;
        }

        private void RbbFrmReportEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control && e.Modifiers == Keys.S)
            {
                //btnSalvar_ItemClick(null, null);
            }
        }
    }
}