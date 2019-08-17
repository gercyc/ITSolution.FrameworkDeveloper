using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ITSolution.Reports.Forms;
using ITSolution.Admin.Entidades.EntidadesBd;
using System.Collections.Generic;
using ITSolution.Reports.Forms.View;

namespace ITSolution.Admin.Reports
{
    public partial class RptPackageInfo : DevExpress.XtraReports.UI.XtraReport
    {
        private XFrmReportView xFrmReportView;
        public RptPackageInfo(Package pacote)
        {
            InitializeComponent();
            List<Package> pacotes = new List<Package>();
            pacotes.Add(pacote);
            this.DataSource = pacotes;

            //cria o documento em background
            this.CreateDocument(true);
            this.xrLabelAnexosCount.Text = "Anexos: " + pacote.CountPackages;
            this.xFrmReportView = new XFrmReportView(this);
        }
        /// <summary>
        ///Invoka o relatório da proposta
        /// </summary>
        public void Run()
        {
            this.xFrmReportView.Show();
        }

    }
}
