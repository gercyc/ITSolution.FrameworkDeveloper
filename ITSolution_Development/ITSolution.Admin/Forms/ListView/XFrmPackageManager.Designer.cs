namespace ITSolution.Admin.Forms.ListView
{
    partial class XFrmPackageManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmPackageManager));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNovoPacote = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditarPacote = new DevExpress.XtraBars.BarButtonItem();
            this.btnPublicarPacote = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveFile = new DevExpress.XtraBars.BarButtonItem();
            this.btnReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcluirPacote = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlPackages = new DevExpress.XtraGrid.GridControl();
            this.bsPackage = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewPackages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdPacote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroPacote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSintoma = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTratamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataCriacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataPublicacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPackages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPackages)).BeginInit();
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
            this.btnNovoPacote,
            this.btnEditarPacote,
            this.btnPublicarPacote,
            this.btnExcluirPacote,
            this.btnReport,
            this.btnSaveFile});
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNovoPacote),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEditarPacote),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPublicarPacote),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExcluirPacote)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnNovoPacote
            // 
            this.btnNovoPacote.Caption = "Novo";
            this.btnNovoPacote.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNovoPacote.Glyph")));
            this.btnNovoPacote.Id = 1;
            this.btnNovoPacote.Name = "btnNovoPacote";
            this.btnNovoPacote.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnNovoPacote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNovoPacote_ItemClick);
            // 
            // btnEditarPacote
            // 
            this.btnEditarPacote.Caption = "Editar";
            this.btnEditarPacote.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEditarPacote.Glyph")));
            this.btnEditarPacote.Id = 2;
            this.btnEditarPacote.Name = "btnEditarPacote";
            this.btnEditarPacote.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnEditarPacote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditarPacote_ItemClick);
            // 
            // btnPublicarPacote
            // 
            this.btnPublicarPacote.Caption = "Publicar";
            this.btnPublicarPacote.Enabled = false;
            this.btnPublicarPacote.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPublicarPacote.Glyph")));
            this.btnPublicarPacote.Id = 3;
            this.btnPublicarPacote.Name = "btnPublicarPacote";
            this.btnPublicarPacote.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPublicarPacote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPublicarPacote_ItemClick);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Caption = "Exportar Pacote";
            this.btnSaveFile.Enabled = false;
            this.btnSaveFile.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveFile.Glyph")));
            this.btnSaveFile.Id = 6;
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSaveFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveFile_ItemClick);
            // 
            // btnReport
            // 
            this.btnReport.Caption = "Relatório";
            this.btnReport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnReport.Glyph")));
            this.btnReport.Id = 5;
            this.btnReport.Name = "btnReport";
            this.btnReport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReport_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Atualizar";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 0;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnExcluirPacote
            // 
            this.btnExcluirPacote.Caption = "Excluir";
            this.btnExcluirPacote.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExcluirPacote.Glyph")));
            this.btnExcluirPacote.Id = 4;
            this.btnExcluirPacote.Name = "btnExcluirPacote";
            this.btnExcluirPacote.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnExcluirPacote.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnExcluirPacote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcluirPacote_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(911, 45);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 428);
            this.barDockControlBottom.Size = new System.Drawing.Size(911, 21);
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
            this.barDockControlRight.Location = new System.Drawing.Point(911, 45);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 383);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlPackages);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(911, 383);
            this.panelControl1.TabIndex = 4;
            // 
            // gridControlPackages
            // 
            this.gridControlPackages.DataSource = this.bsPackage;
            this.gridControlPackages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPackages.Location = new System.Drawing.Point(2, 2);
            this.gridControlPackages.MainView = this.gridViewPackages;
            this.gridControlPackages.MenuManager = this.barManager1;
            this.gridControlPackages.Name = "gridControlPackages";
            this.gridControlPackages.Size = new System.Drawing.Size(907, 379);
            this.gridControlPackages.TabIndex = 0;
            this.gridControlPackages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPackages});
            // 
            // bsPackage
            // 
            this.bsPackage.DataSource = typeof(ITSolution.Admin.Entidades.EntidadesBd.Package);
            // 
            // gridViewPackages
            // 
            this.gridViewPackages.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdPacote,
            this.colNumeroPacote,
            this.colDescricao,
            this.colSintoma,
            this.colTratamento,
            this.colDataCriacao,
            this.colDataPublicacao,
            this.colStatus});
            this.gridViewPackages.GridControl = this.gridControlPackages;
            this.gridViewPackages.Name = "gridViewPackages";
            this.gridViewPackages.OptionsBehavior.Editable = false;
            this.gridViewPackages.OptionsView.ColumnAutoWidth = false;
            this.gridViewPackages.OptionsView.ShowGroupPanel = false;
            this.gridViewPackages.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDataPublicacao, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewPackages.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewPackages_FocusedRowChanged);
            this.gridViewPackages.DoubleClick += new System.EventHandler(this.gridViewPackages_DoubleClick);
            // 
            // colIdPacote
            // 
            this.colIdPacote.FieldName = "IdPacote";
            this.colIdPacote.Name = "colIdPacote";
            // 
            // colNumeroPacote
            // 
            this.colNumeroPacote.Caption = "Nº Pacote";
            this.colNumeroPacote.FieldName = "NumeroPacote";
            this.colNumeroPacote.Name = "colNumeroPacote";
            this.colNumeroPacote.Visible = true;
            this.colNumeroPacote.VisibleIndex = 0;
            this.colNumeroPacote.Width = 98;
            // 
            // colDescricao
            // 
            this.colDescricao.Caption = "Pacote";
            this.colDescricao.FieldName = "Descricao";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.Visible = true;
            this.colDescricao.VisibleIndex = 1;
            this.colDescricao.Width = 323;
            // 
            // colSintoma
            // 
            this.colSintoma.FieldName = "Sintoma";
            this.colSintoma.Name = "colSintoma";
            this.colSintoma.Visible = true;
            this.colSintoma.VisibleIndex = 2;
            this.colSintoma.Width = 300;
            // 
            // colTratamento
            // 
            this.colTratamento.FieldName = "Tratamento";
            this.colTratamento.Name = "colTratamento";
            this.colTratamento.Visible = true;
            this.colTratamento.VisibleIndex = 3;
            this.colTratamento.Width = 253;
            // 
            // colDataCriacao
            // 
            this.colDataCriacao.Caption = "Data Criação";
            this.colDataCriacao.FieldName = "DataCriacao";
            this.colDataCriacao.Name = "colDataCriacao";
            this.colDataCriacao.Visible = true;
            this.colDataCriacao.VisibleIndex = 5;
            this.colDataCriacao.Width = 91;
            // 
            // colDataPublicacao
            // 
            this.colDataPublicacao.Caption = "Data Publicação";
            this.colDataPublicacao.FieldName = "DataPublicacao";
            this.colDataPublicacao.Name = "colDataPublicacao";
            this.colDataPublicacao.Visible = true;
            this.colDataPublicacao.VisibleIndex = 6;
            this.colDataPublicacao.Width = 157;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;
            this.colStatus.Width = 95;
            // 
            // XFrmPackageManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 449);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "XFrmPackageManager";
            this.Text = "Gerenciador de Pacotes";
            this.Shown += new System.EventHandler(this.XFrmPackageManager_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPackages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPackages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlPackages;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPackages;
        private DevExpress.XtraBars.BarButtonItem btnNovoPacote;
        private DevExpress.XtraBars.BarButtonItem btnEditarPacote;
        private DevExpress.XtraBars.BarButtonItem btnExcluirPacote;
        private DevExpress.XtraBars.BarButtonItem btnPublicarPacote;
        private System.Windows.Forms.BindingSource bsPackage;
        private DevExpress.XtraGrid.Columns.GridColumn colIdPacote;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroPacote;
        private DevExpress.XtraGrid.Columns.GridColumn colDescricao;
        private DevExpress.XtraGrid.Columns.GridColumn colSintoma;
        private DevExpress.XtraGrid.Columns.GridColumn colTratamento;
        private DevExpress.XtraGrid.Columns.GridColumn colDataCriacao;
        private DevExpress.XtraGrid.Columns.GridColumn colDataPublicacao;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraBars.BarButtonItem btnReport;
        private DevExpress.XtraBars.BarButtonItem btnSaveFile;
    }
}