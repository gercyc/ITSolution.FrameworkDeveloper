namespace ITSolution.Admin.Forms.ListView
{
    partial class XFrmUpdateManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmUpdateManager));
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlUpdates = new DevExpress.XtraGrid.GridControl();
            this.bsPkgUpdate = new System.Windows.Forms.BindingSource();
            this.gridViewUpdates = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroPacote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescricaoUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataAplicacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogAplicacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.memLogEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUpdates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPkgUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUpdates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memLogEdit)).BeginInit();
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
            this.btnRefresh});
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            this.bar1.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Atualizar";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 0;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            this.barDockControlTop.Size = new System.Drawing.Size(788, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 426);
            this.barDockControlBottom.Size = new System.Drawing.Size(788, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 379);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(788, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 379);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControlUpdates);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 47);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(788, 379);
            this.panelControl1.TabIndex = 4;
            // 
            // gridControlUpdates
            // 
            this.gridControlUpdates.DataSource = this.bsPkgUpdate;
            this.gridControlUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlUpdates.Location = new System.Drawing.Point(2, 2);
            this.gridControlUpdates.MainView = this.gridViewUpdates;
            this.gridControlUpdates.MenuManager = this.barManager1;
            this.gridControlUpdates.Name = "gridControlUpdates";
            this.gridControlUpdates.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.memLogEdit});
            this.gridControlUpdates.Size = new System.Drawing.Size(784, 375);
            this.gridControlUpdates.TabIndex = 0;
            this.gridControlUpdates.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUpdates});
            // 
            // bsPkgUpdate
            // 
            this.bsPkgUpdate.DataSource = typeof(ITSolution.Admin.Entidades.EntidadesBd.UpdateInfo);
            // 
            // gridViewUpdates
            // 
            this.gridViewUpdates.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdUpdate,
            this.colNumeroPacote,
            this.colDescricaoUpdate,
            this.colDataAplicacao,
            this.colLogAplicacao,
            this.colStatus});
            this.gridViewUpdates.GridControl = this.gridControlUpdates;
            this.gridViewUpdates.Name = "gridViewUpdates";
            this.gridViewUpdates.OptionsBehavior.Editable = false;
            this.gridViewUpdates.OptionsView.ShowGroupPanel = false;
            this.gridViewUpdates.DoubleClick += new System.EventHandler(this.gridViewUpdates_DoubleClick);
            // 
            // colIdUpdate
            // 
            this.colIdUpdate.Caption = "ID";
            this.colIdUpdate.FieldName = "IdUpdate";
            this.colIdUpdate.Name = "colIdUpdate";
            this.colIdUpdate.OptionsColumn.AllowEdit = false;
            this.colIdUpdate.Width = 86;
            // 
            // colNumeroPacote
            // 
            this.colNumeroPacote.Caption = "Package Number";
            this.colNumeroPacote.FieldName = "NumeroPacote";
            this.colNumeroPacote.Name = "colNumeroPacote";
            this.colNumeroPacote.OptionsColumn.AllowEdit = false;
            this.colNumeroPacote.Visible = true;
            this.colNumeroPacote.VisibleIndex = 0;
            this.colNumeroPacote.Width = 150;
            // 
            // colDescricaoUpdate
            // 
            this.colDescricaoUpdate.Caption = "Update Name";
            this.colDescricaoUpdate.FieldName = "DescricaoUpdate";
            this.colDescricaoUpdate.Name = "colDescricaoUpdate";
            this.colDescricaoUpdate.OptionsColumn.AllowEdit = false;
            this.colDescricaoUpdate.Visible = true;
            this.colDescricaoUpdate.VisibleIndex = 1;
            this.colDescricaoUpdate.Width = 300;
            // 
            // colDataAplicacao
            // 
            this.colDataAplicacao.Caption = "Update Date";
            this.colDataAplicacao.FieldName = "DataAplicacao";
            this.colDataAplicacao.Name = "colDataAplicacao";
            this.colDataAplicacao.OptionsColumn.AllowEdit = false;
            this.colDataAplicacao.Visible = true;
            this.colDataAplicacao.VisibleIndex = 2;
            this.colDataAplicacao.Width = 120;
            // 
            // colLogAplicacao
            // 
            this.colLogAplicacao.Caption = "Application log";
            this.colLogAplicacao.ColumnEdit = this.memLogEdit;
            this.colLogAplicacao.FieldName = "LogAplicacao";
            this.colLogAplicacao.Name = "colLogAplicacao";
            this.colLogAplicacao.Width = 259;
            // 
            // memLogEdit
            // 
            this.memLogEdit.AutoHeight = false;
            this.memLogEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.memLogEdit.Name = "memLogEdit";
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;
            this.colStatus.Width = 126;
            // 
            // XFrmUpdateManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 449);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "XFrmUpdateManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Installed updates";
            this.Shown += new System.EventHandler(this.XFrmUpdateManager_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUpdates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPkgUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUpdates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memLogEdit)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControlUpdates;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUpdates;
        private System.Windows.Forms.BindingSource bsPkgUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colIdUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroPacote;
        private DevExpress.XtraGrid.Columns.GridColumn colDescricaoUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colDataAplicacao;
        private DevExpress.XtraGrid.Columns.GridColumn colLogAplicacao;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit memLogEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}