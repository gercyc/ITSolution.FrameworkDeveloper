namespace ITSolution.Reports.Forms.ListView
{
    partial class XFrmSpoolReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmSpoolReport));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnVisualizarImpressao = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalvarPdf = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalvarXls = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveSpool = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlRelatorios = new DevExpress.XtraGrid.GridControl();
            this.reportSpoolBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewRelatorios = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID_SPOOL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDT_GERACAO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOME_RELATORIO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reportSpoolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRelatorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSpoolBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRelatorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSpoolBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnVisualizarImpressao,
            this.btnSalvarPdf,
            this.btnRefresh,
            this.btnSalvarXls,
            this.btnRemoveSpool});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowCategoryInCaption = false;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(802, 143);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnVisualizarImpressao
            // 
            this.btnVisualizarImpressao.Caption = "Visualizar Impressão";
            this.btnVisualizarImpressao.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVisualizarImpressao.Glyph")));
            this.btnVisualizarImpressao.Id = 1;
            this.btnVisualizarImpressao.Name = "btnVisualizarImpressao";
            this.btnVisualizarImpressao.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnVisualizarImpressao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVisualizarImpressao_ItemClick);
            // 
            // btnSalvarPdf
            // 
            this.btnSalvarPdf.Caption = "Exportar para PDF";
            this.btnSalvarPdf.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSalvarPdf.Glyph")));
            this.btnSalvarPdf.Id = 2;
            this.btnSalvarPdf.Name = "btnSalvarPdf";
            this.btnSalvarPdf.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSalvarPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvarPdf_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Atualizar";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 3;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnSalvarXls
            // 
            this.btnSalvarXls.Caption = "Exportar para Excel";
            this.btnSalvarXls.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSalvarXls.Glyph")));
            this.btnSalvarXls.Id = 4;
            this.btnSalvarXls.Name = "btnSalvarXls";
            this.btnSalvarXls.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSalvarXls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvarXls_ItemClick);
            // 
            // btnRemoveSpool
            // 
            this.btnRemoveSpool.Caption = "Excluir do spool";
            this.btnRemoveSpool.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveSpool.Glyph")));
            this.btnRemoveSpool.Id = 5;
            this.btnRemoveSpool.Name = "btnRemoveSpool";
            this.btnRemoveSpool.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRemoveSpool.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoveSpool_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Impressão";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVisualizarImpressao);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvarPdf);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvarXls);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRemoveSpool);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Opções";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControlRelatorios);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 143);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(802, 287);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Relatórios Gerados:";
            // 
            // gridControlRelatorios
            // 
            this.gridControlRelatorios.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlRelatorios.DataSource = this.reportSpoolBindingSource1;
            this.gridControlRelatorios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlRelatorios.Location = new System.Drawing.Point(2, 20);
            this.gridControlRelatorios.MainView = this.gridViewRelatorios;
            this.gridControlRelatorios.MenuManager = this.ribbonControl1;
            this.gridControlRelatorios.Name = "gridControlRelatorios";
            this.gridControlRelatorios.Size = new System.Drawing.Size(798, 265);
            this.gridControlRelatorios.TabIndex = 2;
            this.gridControlRelatorios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRelatorios});
            // 
            // reportSpoolBindingSource1
            // 
            this.reportSpoolBindingSource1.DataSource = typeof(ITSolution.Framework.Common.BaseClasses.Reports.ReportSpool);
            // 
            // gridViewRelatorios
            // 
            this.gridViewRelatorios.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID_SPOOL,
            this.colDT_GERACAO,
            this.colNOME_RELATORIO});
            this.gridViewRelatorios.GridControl = this.gridControlRelatorios;
            this.gridViewRelatorios.Name = "gridViewRelatorios";
            this.gridViewRelatorios.OptionsBehavior.Editable = false;
            this.gridViewRelatorios.OptionsView.ShowGroupPanel = false;
            this.gridViewRelatorios.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewRelatorios_FocusedRowChanged);
            // 
            // colID_SPOOL
            // 
            this.colID_SPOOL.AppearanceCell.Options.UseTextOptions = true;
            this.colID_SPOOL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colID_SPOOL.AppearanceHeader.Options.UseTextOptions = true;
            this.colID_SPOOL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colID_SPOOL.Caption = "ID";
            this.colID_SPOOL.FieldName = "IdSpool";
            this.colID_SPOOL.Name = "colID_SPOOL";
            this.colID_SPOOL.Visible = true;
            this.colID_SPOOL.VisibleIndex = 0;
            this.colID_SPOOL.Width = 65;
            // 
            // colDT_GERACAO
            // 
            this.colDT_GERACAO.Caption = "Data";
            this.colDT_GERACAO.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.colDT_GERACAO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDT_GERACAO.FieldName = "GenerateTime";
            this.colDT_GERACAO.Name = "colDT_GERACAO";
            this.colDT_GERACAO.Visible = true;
            this.colDT_GERACAO.VisibleIndex = 1;
            this.colDT_GERACAO.Width = 155;
            // 
            // colNOME_RELATORIO
            // 
            this.colNOME_RELATORIO.Caption = "Nome";
            this.colNOME_RELATORIO.FieldName = "ReportName";
            this.colNOME_RELATORIO.Name = "colNOME_RELATORIO";
            this.colNOME_RELATORIO.Visible = true;
            this.colNOME_RELATORIO.VisibleIndex = 2;
            this.colNOME_RELATORIO.Width = 476;
            // 
            // XFrmSpoolReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 430);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "XFrmSpoolReport";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spool de Relatórios gerados";
            this.Shown += new System.EventHandler(this.XFrmSpoolRel_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRelatorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSpoolBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRelatorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportSpoolBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnVisualizarImpressao;
        private DevExpress.XtraBars.BarButtonItem btnSalvarPdf;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControlRelatorios;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRelatorios;
        private System.Windows.Forms.BindingSource reportSpoolBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnSalvarXls;
        private DevExpress.XtraBars.BarButtonItem btnRemoveSpool;
        private System.Windows.Forms.BindingSource reportSpoolBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colID_SPOOL;
        private DevExpress.XtraGrid.Columns.GridColumn colDT_GERACAO;
        private DevExpress.XtraGrid.Columns.GridColumn colNOME_RELATORIO;
    }
}