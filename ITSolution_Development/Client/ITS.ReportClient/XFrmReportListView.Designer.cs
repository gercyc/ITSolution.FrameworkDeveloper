namespace ITSolution.Framework.Client.Reports
{
    partial class XFrmReportList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmReportList));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNovoRelatorio = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditRpt = new DevExpress.XtraBars.BarButtonItem();
            this.barChEditarReport = new DevExpress.XtraBars.BarCheckItem();
            this.btnGerarRelatorio = new DevExpress.XtraBars.BarButtonItem();
            this.barSubImpExp = new DevExpress.XtraBars.BarSubItem();
            this.btnExportEstrutura = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportEstrutura = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopyEstrutura = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoverEstrutura = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnClearCache = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bsReportImage = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdReport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdGrpReport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportImageData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrupo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsReportImage)).BeginInit();
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
            this.barChEditarReport,
            this.barSubImpExp,
            this.btnExportEstrutura,
            this.btnImportEstrutura,
            this.barBtnClearCache,
            this.btnCopyEstrutura});
            this.barManager1.MaxItemId = 14;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barChEditarReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGerarRelatorio),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubImpExp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
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
            this.btnEditRpt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditReport_ItemClick);
            // 
            // barChEditarReport
            // 
            this.barChEditarReport.BindableChecked = true;
            this.barChEditarReport.Caption = "Imediato";
            this.barChEditarReport.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.barChEditarReport.Checked = true;
            this.barChEditarReport.Id = 7;
            this.barChEditarReport.Name = "barChEditarReport";
            toolTipTitleItem1.Text = "Marcado/Desmarcado";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Marcado: O editor do relatórios é carregado imediatamente.\r\n\r\nDesmarcado: Permite" +
    " alterar o nome e grupo do relatório antes de iniciar a edição.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.barChEditarReport.SuperTip = superToolTip1;
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.Caption = "Gerar Relatorio";
            this.btnGerarRelatorio.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGerarRelatorio.Glyph")));
            this.btnGerarRelatorio.Id = 2;
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnGerarRelatorio.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGerarRelatorio_ItemClick);
            // 
            // barSubImpExp
            // 
            this.barSubImpExp.Caption = "Import/Export";
            this.barSubImpExp.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubImpExp.Glyph")));
            this.barSubImpExp.Id = 8;
            this.barSubImpExp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportEstrutura),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImportEstrutura),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCopyEstrutura),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnClearCache),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRemoverEstrutura, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barSubImpExp.Name = "barSubImpExp";
            this.barSubImpExp.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            // btnCopyEstrutura
            // 
            this.btnCopyEstrutura.Caption = "Duplicar estrutura";
            this.btnCopyEstrutura.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCopyEstrutura.Glyph")));
            this.btnCopyEstrutura.Id = 12;
            this.btnCopyEstrutura.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCopyEstrutura.LargeGlyph")));
            this.btnCopyEstrutura.Name = "btnCopyEstrutura";
            this.btnCopyEstrutura.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnCopyEstrutura.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopyEstrutura_ItemClick);
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
            // btnRemoverEstrutura
            // 
            this.btnRemoverEstrutura.Caption = "Remover";
            this.btnRemoverEstrutura.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRemoverEstrutura.Glyph")));
            this.btnRemoverEstrutura.Id = 6;
            this.btnRemoverEstrutura.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRemoverEstrutura.LargeGlyph")));
            this.btnRemoverEstrutura.Name = "btnRemoverEstrutura";
            this.btnRemoverEstrutura.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoverEstrutura_ItemClick);
            // 
            // barBtnClearCache
            // 
            this.barBtnClearCache.Caption = "Limpar Cache";
            this.barBtnClearCache.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnClearCache.Glyph")));
            this.barBtnClearCache.Id = 11;
            this.barBtnClearCache.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnClearCache.LargeGlyph")));
            this.barBtnClearCache.Name = "barBtnClearCache";
            this.barBtnClearCache.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnClearCache_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(807, 45);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 428);
            this.barDockControlBottom.Size = new System.Drawing.Size(807, 21);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 45);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 383);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(807, 45);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 383);
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.bsReportImage;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 45);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(807, 383);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bsReportImage
            // 
            this.bsReportImage.DataSource = typeof(ITSolution.Framework.Common.BaseClasses.Reports.ReportImage);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdReport,
            this.colIdGrpReport,
            this.colReportName,
            this.colReportDescription,
            this.colReportImageData,
            this.colGrupo});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGrupo, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colReportDescription, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colIdReport
            // 
            this.colIdReport.AppearanceCell.Options.UseTextOptions = true;
            this.colIdReport.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdReport.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdReport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdReport.Caption = "ID Relatório";
            this.colIdReport.FieldName = "IdReport";
            this.colIdReport.Name = "colIdReport";
            this.colIdReport.Width = 130;
            // 
            // colIdGrpReport
            // 
            this.colIdGrpReport.AppearanceCell.Options.UseTextOptions = true;
            this.colIdGrpReport.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdGrpReport.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdGrpReport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdGrpReport.FieldName = "IdGrpReport";
            this.colIdGrpReport.Name = "colIdGrpReport";
            // 
            // colReportName
            // 
            this.colReportName.AppearanceCell.Options.UseTextOptions = true;
            this.colReportName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colReportName.AppearanceHeader.Options.UseTextOptions = true;
            this.colReportName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colReportName.Caption = "Nome Relatório";
            this.colReportName.FieldName = "ReportName";
            this.colReportName.Name = "colReportName";
            this.colReportName.Width = 244;
            // 
            // colReportDescription
            // 
            this.colReportDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colReportDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colReportDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colReportDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colReportDescription.Caption = "Descrição do Relatório";
            this.colReportDescription.FieldName = "ReportDescription";
            this.colReportDescription.Name = "colReportDescription";
            this.colReportDescription.Visible = true;
            this.colReportDescription.VisibleIndex = 0;
            this.colReportDescription.Width = 580;
            // 
            // colReportImageData
            // 
            this.colReportImageData.AppearanceCell.Options.UseTextOptions = true;
            this.colReportImageData.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colReportImageData.AppearanceHeader.Options.UseTextOptions = true;
            this.colReportImageData.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colReportImageData.FieldName = "ReportImageData";
            this.colReportImageData.Name = "colReportImageData";
            // 
            // colGrupo
            // 
            this.colGrupo.AppearanceCell.Options.UseTextOptions = true;
            this.colGrupo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colGrupo.AppearanceHeader.Options.UseTextOptions = true;
            this.colGrupo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colGrupo.Caption = "Grupo";
            this.colGrupo.FieldName = "Grupo.GroupDescription";
            this.colGrupo.Name = "colGrupo";
            this.colGrupo.Visible = true;
            this.colGrupo.VisibleIndex = 2;
            this.colGrupo.Width = 210;
            // 
            // XFrmReportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 449);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "Office 2010 Blue";
            this.Name = "XFrmReportList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciador de Relatórios";
            this.Shown += new System.EventHandler(this.XFrmReportList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsReportImage)).EndInit();
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
        private System.Windows.Forms.BindingSource bsReportImage;
        private DevExpress.XtraBars.BarButtonItem btnRemoverEstrutura;
        private DevExpress.XtraGrid.Columns.GridColumn colIdReport;
        private DevExpress.XtraGrid.Columns.GridColumn colIdGrpReport;
        private DevExpress.XtraGrid.Columns.GridColumn colReportName;
        private DevExpress.XtraGrid.Columns.GridColumn colReportDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colReportImageData;
        private DevExpress.XtraGrid.Columns.GridColumn colGrupo;
        private DevExpress.XtraBars.BarCheckItem barChEditarReport;
        private DevExpress.XtraBars.BarSubItem barSubImpExp;
        private DevExpress.XtraBars.BarButtonItem btnExportEstrutura;
        private DevExpress.XtraBars.BarButtonItem btnImportEstrutura;
        private DevExpress.XtraBars.BarButtonItem barBtnClearCache;
        private DevExpress.XtraBars.BarButtonItem btnCopyEstrutura;
    }
}