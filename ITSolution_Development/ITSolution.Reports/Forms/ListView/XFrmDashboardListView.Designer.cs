namespace ITSolution.Reports.Forms.ListView
{
    partial class XFrmDashboardListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmDashboardListView));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNovoRelatorio = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditRpt = new DevExpress.XtraBars.BarButtonItem();
            this.barChEditarDashboard = new DevExpress.XtraBars.BarCheckItem();
            this.btnGerarRelatorio = new DevExpress.XtraBars.BarButtonItem();
            this.barUtilReport = new DevExpress.XtraBars.BarSubItem();
            this.btnExportEstrutura = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportEstrutura = new DevExpress.XtraBars.BarButtonItem();
            this.barCopyEstrutura = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnClearCache = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoverEstrutura = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bsDashboardImage = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdDashboard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdGrpReport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDashboardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDashboardDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDashboardImageData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrupo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDashboardImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnRefresh,
            this.btnEditRpt,
            this.btnGerarRelatorio,
            this.btnNovoRelatorio,
            this.btnRemoverEstrutura,
            this.barUtilReport,
            this.btnExportEstrutura,
            this.btnImportEstrutura,
            this.barBtnClearCache,
            this.barChEditarDashboard,
            this.barCopyEstrutura});
            this.barManager1.MaxItemId = 18;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNovoRelatorio),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEditRpt),
            new DevExpress.XtraBars.LinkPersistInfo(this.barChEditarDashboard),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGerarRelatorio),
            new DevExpress.XtraBars.LinkPersistInfo(this.barUtilReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnNovoRelatorio
            // 
            this.btnNovoRelatorio.Caption = "Novo";
            this.btnNovoRelatorio.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNovoRelatorio.Glyph")));
            this.btnNovoRelatorio.Id = 4;
            this.btnNovoRelatorio.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnNovoRelatorio.Name = "btnNovoRelatorio";
            this.btnNovoRelatorio.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnNovoRelatorio.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNovoRelatorio_ItemClick);
            // 
            // btnEditRpt
            // 
            this.btnEditRpt.Caption = "Editar";
            this.btnEditRpt.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEditRpt.Glyph")));
            this.btnEditRpt.Id = 1;
            this.btnEditRpt.Name = "btnEditRpt";
            this.btnEditRpt.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnEditRpt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditDashboard_ItemClick);
            // 
            // barChEditarDashboard
            // 
            this.barChEditarDashboard.BindableChecked = true;
            this.barChEditarDashboard.Caption = "Imediato";
            this.barChEditarDashboard.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.barChEditarDashboard.Checked = true;
            this.barChEditarDashboard.Id = 12;
            this.barChEditarDashboard.Name = "barChEditarDashboard";
            toolTipTitleItem1.Text = "Marcado/Desmarcado\r\n";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Marcado: O editor do relatórios é carregado imediatamente.\r\n\r\nDesmarcado: Permite" +
    " alterar o nome e grupo do relatório antes de iniciar a edição.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.barChEditarDashboard.SuperTip = superToolTip1;
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.Caption = "Visualizar";
            this.btnGerarRelatorio.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGerarRelatorio.Glyph")));
            this.btnGerarRelatorio.Id = 7;
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnGerarRelatorio.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVisualizarDashboard_ItemClick);
            // 
            // barUtilReport
            // 
            this.barUtilReport.Caption = "Utilitários";
            this.barUtilReport.Glyph = ((System.Drawing.Image)(resources.GetObject("barUtilReport.Glyph")));
            this.barUtilReport.Id = 8;
            this.barUtilReport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportEstrutura),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImportEstrutura),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCopyEstrutura),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnClearCache),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRemoverEstrutura, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barUtilReport.Name = "barUtilReport";
            this.barUtilReport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnExportEstrutura
            // 
            this.btnExportEstrutura.Caption = "Exportar estrutura";
            this.btnExportEstrutura.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportEstrutura.Glyph")));
            this.btnExportEstrutura.Id = 9;
            this.btnExportEstrutura.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportEstrutura.LargeGlyph")));
            this.btnExportEstrutura.Name = "btnExportEstrutura";
            this.btnExportEstrutura.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportEstrutura_ItemClick);
            // 
            // btnImportEstrutura
            // 
            this.btnImportEstrutura.Caption = "Importar estrutura";
            this.btnImportEstrutura.Glyph = ((System.Drawing.Image)(resources.GetObject("btnImportEstrutura.Glyph")));
            this.btnImportEstrutura.Id = 10;
            this.btnImportEstrutura.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnImportEstrutura.LargeGlyph")));
            this.btnImportEstrutura.Name = "btnImportEstrutura";
            this.btnImportEstrutura.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportEstrutura_ItemClick);
            // 
            // barCopyEstrutura
            // 
            this.barCopyEstrutura.Caption = "Duplicar estrutura";
            this.barCopyEstrutura.Glyph = ((System.Drawing.Image)(resources.GetObject("barCopyEstrutura.Glyph")));
            this.barCopyEstrutura.Id = 13;
            this.barCopyEstrutura.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barCopyEstrutura.LargeGlyph")));
            this.barCopyEstrutura.Name = "barCopyEstrutura";
            this.barCopyEstrutura.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barCopyEstrutura.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCopyEstrutura_ItemClick);
            // 
            // barBtnClearCache
            // 
            this.barBtnClearCache.Caption = "Limpar Cache";
            this.barBtnClearCache.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnClearCache.Glyph")));
            this.barBtnClearCache.Id = 11;
            this.barBtnClearCache.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnClearCache.LargeGlyph")));
            this.barBtnClearCache.Name = "barBtnClearCache";
            toolTipTitleItem2.Text = "Remove todos os dashboards em disco";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "O dashboard será carregado novamente do banco para o disco antes da exibição ou e" +
    "dição.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.barBtnClearCache.SuperTip = superToolTip2;
            this.barBtnClearCache.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnClearCache_ItemClick);
            // 
            // btnRemoverEstrutura
            // 
            this.btnRemoverEstrutura.Caption = "Remover";
            this.btnRemoverEstrutura.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRemoverEstrutura.Glyph")));
            this.btnRemoverEstrutura.Id = 6;
            this.btnRemoverEstrutura.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRemoverEstrutura.LargeGlyph")));
            this.btnRemoverEstrutura.Name = "btnRemoverEstrutura";
            this.btnRemoverEstrutura.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoverEstrutura_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Atualizar";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 0;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(941, 57);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 531);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(941, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 57);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 474);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(941, 57);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 474);
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.bsDashboardImage;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(0, 57);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(941, 474);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bsDashboardImage
            // 
            this.bsDashboardImage.DataSource = typeof(ITSolution.Framework.Common.BaseClasses.Reports.DashboardImage);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdDashboard,
            this.colIdGrpReport,
            this.colDashboardName,
            this.colDashboardDescription,
            this.colDashboardImageData,
            this.colGrupo});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGrupo, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDashboardDescription, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colIdDashboard
            // 
            this.colIdDashboard.AppearanceCell.Options.UseTextOptions = true;
            this.colIdDashboard.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdDashboard.AppearanceHeader.Options.UseFont = true;
            this.colIdDashboard.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdDashboard.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdDashboard.Caption = "ID Dashboard";
            this.colIdDashboard.FieldName = "IdReport";
            this.colIdDashboard.Name = "colIdDashboard";
            this.colIdDashboard.Width = 130;
            // 
            // colIdGrpReport
            // 
            this.colIdGrpReport.AppearanceCell.Options.UseTextOptions = true;
            this.colIdGrpReport.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdGrpReport.AppearanceHeader.Options.UseFont = true;
            this.colIdGrpReport.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdGrpReport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdGrpReport.FieldName = "IdGrpReport";
            this.colIdGrpReport.Name = "colIdGrpReport";
            // 
            // colDashboardName
            // 
            this.colDashboardName.AppearanceCell.Options.UseTextOptions = true;
            this.colDashboardName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDashboardName.AppearanceHeader.Options.UseFont = true;
            this.colDashboardName.AppearanceHeader.Options.UseTextOptions = true;
            this.colDashboardName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDashboardName.Caption = "Nome do Dashboard";
            this.colDashboardName.FieldName = "ReportName";
            this.colDashboardName.Name = "colDashboardName";
            this.colDashboardName.Width = 212;
            // 
            // colDashboardDescription
            // 
            this.colDashboardDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDashboardDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDashboardDescription.AppearanceHeader.Options.UseFont = true;
            this.colDashboardDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDashboardDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDashboardDescription.FieldName = "ReportDescription";
            this.colDashboardDescription.Name = "colDashboardDescription";
            this.colDashboardDescription.Visible = true;
            this.colDashboardDescription.VisibleIndex = 0;
            this.colDashboardDescription.Width = 420;
            // 
            // colDashboardImageData
            // 
            this.colDashboardImageData.AppearanceCell.Options.UseTextOptions = true;
            this.colDashboardImageData.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDashboardImageData.AppearanceHeader.Options.UseFont = true;
            this.colDashboardImageData.AppearanceHeader.Options.UseTextOptions = true;
            this.colDashboardImageData.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDashboardImageData.FieldName = "ReportImageData";
            this.colDashboardImageData.Name = "colDashboardImageData";
            // 
            // colGrupo
            // 
            this.colGrupo.AppearanceCell.Options.UseTextOptions = true;
            this.colGrupo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colGrupo.AppearanceHeader.Options.UseFont = true;
            this.colGrupo.AppearanceHeader.Options.UseTextOptions = true;
            this.colGrupo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colGrupo.Caption = "Grupo";
            this.colGrupo.FieldName = "Grupo.GroupDescription";
            this.colGrupo.Name = "colGrupo";
            this.colGrupo.Visible = true;
            this.colGrupo.VisibleIndex = 1;
            this.colGrupo.Width = 210;
            // 
            // XFrmDashboardListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 553);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "Office 2010 Blue";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "XFrmDashboardListView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciador de Dashboard";
            this.Shown += new System.EventHandler(this.XFrmDashboardList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDashboardImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnEditRpt;
        private DevExpress.XtraBars.BarButtonItem btnGerarRelatorio;
        private DevExpress.XtraBars.BarButtonItem btnNovoRelatorio;
        private DevExpress.XtraBars.BarButtonItem btnRemoverEstrutura;
        private System.Windows.Forms.BindingSource bsDashboardImage;
        private DevExpress.XtraGrid.Columns.GridColumn colIdDashboard;
        private DevExpress.XtraGrid.Columns.GridColumn colIdGrpReport;
        private DevExpress.XtraGrid.Columns.GridColumn colDashboardName;
        private DevExpress.XtraGrid.Columns.GridColumn colDashboardDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDashboardImageData;
        private DevExpress.XtraGrid.Columns.GridColumn colGrupo;
        private DevExpress.XtraBars.BarSubItem barUtilReport;
        private DevExpress.XtraBars.BarButtonItem btnExportEstrutura;
        private DevExpress.XtraBars.BarButtonItem btnImportEstrutura;
        private DevExpress.XtraBars.BarButtonItem barBtnClearCache;
        private DevExpress.XtraBars.BarCheckItem barChEditarDashboard;
        private DevExpress.XtraBars.BarButtonItem barCopyEstrutura;
    }
}