namespace ITSolution.Framework.Web.Bacen
{
    partial class XFrmHistoricoMoedas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmHistoricoMoedas));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdCotacaoMonetaria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataCotacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorVenda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdMoeda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoeda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbMoedas = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSalvarCotacao = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnExportarPdf = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDownloadHistoricoMoeda = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.btnFiltrar = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditFim = new DevExpress.XtraEditors.DateEdit();
            this.dateEditInicio = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMoedas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFim.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInicio.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 183);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(930, 423);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(3, 59);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(924, 362);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdCotacaoMonetaria,
            this.colDataCotacao,
            this.colValorCompra,
            this.colValorVenda,
            this.colIdMoeda,
            this.colMoeda});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // colIdCotacaoMonetaria
            // 
            this.colIdCotacaoMonetaria.AppearanceCell.Options.UseTextOptions = true;
            this.colIdCotacaoMonetaria.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdCotacaoMonetaria.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdCotacaoMonetaria.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdCotacaoMonetaria.FieldName = "IdCotacaoMonetaria";
            this.colIdCotacaoMonetaria.Name = "colIdCotacaoMonetaria";
            // 
            // colDataCotacao
            // 
            this.colDataCotacao.AppearanceCell.Options.UseTextOptions = true;
            this.colDataCotacao.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDataCotacao.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataCotacao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDataCotacao.Caption = "Data Cotação";
            this.colDataCotacao.FieldName = "DataCotacao";
            this.colDataCotacao.Name = "colDataCotacao";
            this.colDataCotacao.Visible = true;
            this.colDataCotacao.VisibleIndex = 1;
            this.colDataCotacao.Width = 96;
            // 
            // colValorCompra
            // 
            this.colValorCompra.AppearanceCell.Options.UseTextOptions = true;
            this.colValorCompra.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colValorCompra.AppearanceHeader.Options.UseTextOptions = true;
            this.colValorCompra.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colValorCompra.DisplayFormat.FormatString = "n4";
            this.colValorCompra.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colValorCompra.FieldName = "ValorCompra";
            this.colValorCompra.Name = "colValorCompra";
            this.colValorCompra.Visible = true;
            this.colValorCompra.VisibleIndex = 2;
            this.colValorCompra.Width = 112;
            // 
            // colValorVenda
            // 
            this.colValorVenda.AppearanceCell.Options.UseTextOptions = true;
            this.colValorVenda.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colValorVenda.AppearanceHeader.Options.UseTextOptions = true;
            this.colValorVenda.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colValorVenda.DisplayFormat.FormatString = "n4";
            this.colValorVenda.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colValorVenda.FieldName = "ValorVenda";
            this.colValorVenda.Name = "colValorVenda";
            this.colValorVenda.Visible = true;
            this.colValorVenda.VisibleIndex = 3;
            this.colValorVenda.Width = 126;
            // 
            // colIdMoeda
            // 
            this.colIdMoeda.AppearanceCell.Options.UseTextOptions = true;
            this.colIdMoeda.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdMoeda.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdMoeda.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdMoeda.FieldName = "IdMoeda";
            this.colIdMoeda.Name = "colIdMoeda";
            // 
            // colMoeda
            // 
            this.colMoeda.AppearanceCell.Options.UseTextOptions = true;
            this.colMoeda.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colMoeda.AppearanceHeader.Options.UseTextOptions = true;
            this.colMoeda.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colMoeda.Caption = "Moeda";
            this.colMoeda.FieldName = "Moeda.NomeMoeda";
            this.colMoeda.Name = "colMoeda";
            this.colMoeda.Visible = true;
            this.colMoeda.VisibleIndex = 0;
            this.colMoeda.Width = 169;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.cbMoedas);
            this.panelControl1.Controls.Add(this.btnFiltrar);
            this.panelControl1.Controls.Add(this.dateEditFim);
            this.panelControl1.Controls.Add(this.dateEditInicio);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 4);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(924, 49);
            this.panelControl1.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl3.Location = new System.Drawing.Point(346, 17);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 18);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Moeda";
            // 
            // cbMoedas
            // 
            this.cbMoedas.Location = new System.Drawing.Point(395, 14);
            this.cbMoedas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMoedas.MenuManager = this.ribbonControl1;
            this.cbMoedas.Name = "cbMoedas";
            this.cbMoedas.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbMoedas.Properties.Appearance.Options.UseFont = true;
            this.cbMoedas.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbMoedas.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbMoedas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMoedas.Size = new System.Drawing.Size(227, 24);
            this.cbMoedas.TabIndex = 5;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barBtnRefresh,
            this.barBtnSalvarCotacao,
            this.barBtnExportExcel,
            this.barBtnExportarPdf,
            this.barBtnDownloadHistoricoMoeda});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.ribbonControl1.Size = new System.Drawing.Size(930, 183);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // barBtnRefresh
            // 
            this.barBtnRefresh.Caption = "Atualizar";
            this.barBtnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnRefresh.Glyph")));
            this.barBtnRefresh.Id = 1;
            this.barBtnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.barBtnRefresh.Name = "barBtnRefresh";
            this.barBtnRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            toolTipTitleItem1.Text = "Carrega a cotação de todas as moedas do dia.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.barBtnRefresh.SuperTip = superToolTip1;
            this.barBtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnRefresh_ItemClick);
            // 
            // barBtnSalvarCotacao
            // 
            this.barBtnSalvarCotacao.Caption = "Salvar Histórico";
            this.barBtnSalvarCotacao.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSalvarCotacao.Glyph")));
            this.barBtnSalvarCotacao.Id = 2;
            this.barBtnSalvarCotacao.Name = "barBtnSalvarCotacao";
            this.barBtnSalvarCotacao.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            toolTipTitleItem2.Text = "Salva cotação no banco de dados.";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Cotação com mesma data será apenas atualizdas.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem1);
            this.barBtnSalvarCotacao.SuperTip = superToolTip2;
            this.barBtnSalvarCotacao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSalvarCotacao_ItemClick);
            // 
            // barBtnExportExcel
            // 
            this.barBtnExportExcel.Caption = "Exportar para Excel";
            this.barBtnExportExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnExportExcel.Glyph")));
            this.barBtnExportExcel.Id = 3;
            this.barBtnExportExcel.Name = "barBtnExportExcel";
            this.barBtnExportExcel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barBtnExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnExportExcel_ItemClick);
            // 
            // barBtnExportarPdf
            // 
            this.barBtnExportarPdf.Caption = "Exportar para PDF";
            this.barBtnExportarPdf.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnExportarPdf.Glyph")));
            this.barBtnExportarPdf.Id = 4;
            this.barBtnExportarPdf.Name = "barBtnExportarPdf";
            this.barBtnExportarPdf.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barBtnExportarPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnExportarPdf_ItemClick);
            // 
            // barBtnDownloadHistoricoMoeda
            // 
            this.barBtnDownloadHistoricoMoeda.Caption = "Download Histórico Moeda";
            this.barBtnDownloadHistoricoMoeda.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnDownloadHistoricoMoeda.Glyph")));
            this.barBtnDownloadHistoricoMoeda.Id = 6;
            this.barBtnDownloadHistoricoMoeda.Name = "barBtnDownloadHistoricoMoeda";
            this.barBtnDownloadHistoricoMoeda.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            toolTipTitleItem3.Text = "Download das moedas disponíveis";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Realiza busca do histórico de todas as moedas disponíveis no período informado.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem2);
            this.barBtnDownloadHistoricoMoeda.SuperTip = superToolTip3;
            this.barBtnDownloadHistoricoMoeda.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnHistoricoCotacaoTodasMoedas_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Câmbio";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnSalvarCotacao);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnDownloadHistoricoMoeda);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnExportExcel);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnExportarPdf);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Controle Cambial";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 606);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(930, 41);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnFiltrar.Appearance.Options.UseFont = true;
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.Location = new System.Drawing.Point(640, 11);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(87, 28);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            this.btnFiltrar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnFiltrar_KeyDown);
            // 
            // dateEditFim
            // 
            this.dateEditFim.EditValue = null;
            this.dateEditFim.Location = new System.Drawing.Point(199, 14);
            this.dateEditFim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditFim.Name = "dateEditFim";
            this.dateEditFim.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dateEditFim.Properties.Appearance.Options.UseFont = true;
            this.dateEditFim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFim.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFim.Size = new System.Drawing.Size(117, 24);
            this.dateEditFim.TabIndex = 3;
            // 
            // dateEditInicio
            // 
            this.dateEditInicio.EditValue = null;
            this.dateEditInicio.Location = new System.Drawing.Point(33, 14);
            this.dateEditInicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditInicio.Name = "dateEditInicio";
            this.dateEditInicio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dateEditInicio.Properties.Appearance.Options.UseFont = true;
            this.dateEditInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditInicio.Size = new System.Drawing.Size(117, 24);
            this.dateEditInicio.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Location = new System.Drawing.Point(171, 17);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 18);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Até";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Location = new System.Drawing.Point(10, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "De";
            // 
            // XFrmHistoricoMoedas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 647);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "XFrmHistoricoMoedas";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Cotação Cambial";
            this.Shown += new System.EventHandler(this.XFrmCotacaoMonetaria_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XFrmCotacaoMonetaria_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMoedas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFim.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditInicio.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dateEditFim;
        private DevExpress.XtraEditors.DateEdit dateEditInicio;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnFiltrar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraGrid.Columns.GridColumn colIdCotacaoMonetaria;
        private DevExpress.XtraGrid.Columns.GridColumn colDataCotacao;
        private DevExpress.XtraGrid.Columns.GridColumn colValorCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colValorVenda;
        private DevExpress.XtraGrid.Columns.GridColumn colIdMoeda;
        private DevExpress.XtraGrid.Columns.GridColumn colMoeda;
        private DevExpress.XtraBars.BarButtonItem barBtnRefresh;
        private DevExpress.XtraBars.BarButtonItem barBtnSalvarCotacao;
        private DevExpress.XtraBars.BarButtonItem barBtnExportExcel;
        private DevExpress.XtraBars.BarButtonItem barBtnExportarPdf;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cbMoedas;
        private DevExpress.XtraBars.BarButtonItem barBtnDownloadHistoricoMoeda;
    }
}