namespace ITSolution.Admin.Forms.Util
{
    partial class XFrmLicenseManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmLicenseManager));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNewLicense = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveLicense = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportLicense = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridControlLicenses = new DevExpress.XtraGrid.GridControl();
            this.itsLicenseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewLicenses = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdLicense = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLicenseData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLicenseStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbCustomer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMenusAct = new DevExpress.XtraGrid.GridControl();
            this.itsMenuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewMenusAct = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdMenu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomeMenu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMenuPai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMenuText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMenuType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.colController = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAction = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itsLicenseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLicenses)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMenusAct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itsMenuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMenusAct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties)).BeginInit();
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
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNewLicense,
            this.btnSaveLicense,
            this.btnExportLicense});
            this.barManager1.MaxItemId = 3;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewLicense),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveLicense),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportLicense)});
            this.bar1.Text = "Tools";
            // 
            // btnNewLicense
            // 
            this.btnNewLicense.Caption = "Nova licença";
            this.btnNewLicense.Id = 0;
            this.btnNewLicense.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNewLicense.ImageOptions.Image")));
            this.btnNewLicense.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNewLicense.ImageOptions.LargeImage")));
            this.btnNewLicense.Name = "btnNewLicense";
            this.btnNewLicense.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnNewLicense.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewLicense_ItemClick);
            // 
            // btnSaveLicense
            // 
            this.btnSaveLicense.Caption = "Salvar";
            this.btnSaveLicense.Id = 1;
            this.btnSaveLicense.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLicense.ImageOptions.Image")));
            this.btnSaveLicense.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSaveLicense.ImageOptions.LargeImage")));
            this.btnSaveLicense.Name = "btnSaveLicense";
            this.btnSaveLicense.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSaveLicense.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveLicense_ItemClick);
            // 
            // btnExportLicense
            // 
            this.btnExportLicense.Caption = "Exportar arquivo";
            this.btnExportLicense.Id = 2;
            this.btnExportLicense.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportLicense.ImageOptions.Image")));
            this.btnExportLicense.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExportLicense.ImageOptions.LargeImage")));
            this.btnExportLicense.Name = "btnExportLicense";
            this.btnExportLicense.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(878, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 384);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(878, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 353);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(878, 31);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 353);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("00f02af4-cff2-42d9-bac3-14dfaffd0902");
            this.dockPanel1.Location = new System.Drawing.Point(0, 31);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(374, 200);
            this.dockPanel1.Size = new System.Drawing.Size(374, 353);
            this.dockPanel1.Text = "Licenças geradas";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControlLicenses);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(365, 326);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // gridControlLicenses
            // 
            this.gridControlLicenses.DataSource = this.itsLicenseBindingSource;
            this.gridControlLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLicenses.Location = new System.Drawing.Point(0, 0);
            this.gridControlLicenses.MainView = this.gridViewLicenses;
            this.gridControlLicenses.MenuManager = this.barManager1;
            this.gridControlLicenses.Name = "gridControlLicenses";
            this.gridControlLicenses.Size = new System.Drawing.Size(365, 326);
            this.gridControlLicenses.TabIndex = 0;
            this.gridControlLicenses.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLicenses});
            // 
            // itsLicenseBindingSource
            // 
            this.itsLicenseBindingSource.DataSource = typeof(ITSolution.Framework.BaseClasses.License.POCO.ItsLicense);
            // 
            // gridViewLicenses
            // 
            this.gridViewLicenses.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdLicense,
            this.colCustomerName,
            this.colStartDate,
            this.colEndDate,
            this.colLicenseData,
            this.colLicenseStatus});
            this.gridViewLicenses.GridControl = this.gridControlLicenses;
            this.gridViewLicenses.Name = "gridViewLicenses";
            this.gridViewLicenses.OptionsBehavior.Editable = false;
            this.gridViewLicenses.OptionsView.ShowGroupPanel = false;
            this.gridViewLicenses.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewLicenses_RowClick);
            // 
            // colIdLicense
            // 
            this.colIdLicense.FieldName = "IdLicense";
            this.colIdLicense.Name = "colIdLicense";
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 0;
            this.colCustomerName.Width = 86;
            // 
            // colStartDate
            // 
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 1;
            this.colStartDate.Width = 86;
            // 
            // colEndDate
            // 
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.Visible = true;
            this.colEndDate.VisibleIndex = 2;
            this.colEndDate.Width = 99;
            // 
            // colLicenseData
            // 
            this.colLicenseData.FieldName = "LicenseData";
            this.colLicenseData.Name = "colLicenseData";
            // 
            // colLicenseStatus
            // 
            this.colLicenseStatus.Caption = "License Status";
            this.colLicenseStatus.FieldName = "LicenseStatus";
            this.colLicenseStatus.Name = "colLicenseStatus";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.cbCustomer);
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.dtEndDate);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.dtStartDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(374, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 353);
            this.panel1.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 19);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Customer";
            // 
            // cbCustomer
            // 
            this.cbCustomer.Location = new System.Drawing.Point(13, 38);
            this.cbCustomer.MenuManager = this.barManager1;
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCustomer.Size = new System.Drawing.Size(314, 20);
            this.cbCustomer.TabIndex = 8;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.gridControlMenusAct);
            this.groupControl1.Location = new System.Drawing.Point(13, 119);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(479, 228);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Menus liberados";
            // 
            // gridControlMenusAct
            // 
            this.gridControlMenusAct.DataSource = this.itsMenuBindingSource;
            this.gridControlMenusAct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMenusAct.Location = new System.Drawing.Point(2, 20);
            this.gridControlMenusAct.MainView = this.gridViewMenusAct;
            this.gridControlMenusAct.MenuManager = this.barManager1;
            this.gridControlMenusAct.Name = "gridControlMenusAct";
            this.gridControlMenusAct.Size = new System.Drawing.Size(475, 206);
            this.gridControlMenusAct.TabIndex = 0;
            this.gridControlMenusAct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMenusAct});
            // 
            // itsMenuBindingSource
            // 
            this.itsMenuBindingSource.DataSource = typeof(ITSolution.Framework.BaseClasses.License.POCO.ItsMenu);
            // 
            // gridViewMenusAct
            // 
            this.gridViewMenusAct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdMenu,
            this.colNomeMenu,
            this.colMenuPai,
            this.colStatus,
            this.colMenuText,
            this.colMenuType,
            this.colController,
            this.colAction});
            this.gridViewMenusAct.GridControl = this.gridControlMenusAct;
            this.gridViewMenusAct.Name = "gridViewMenusAct";
            this.gridViewMenusAct.OptionsView.ShowGroupPanel = false;
            // 
            // colIdMenu
            // 
            this.colIdMenu.FieldName = "IdMenu";
            this.colIdMenu.Name = "colIdMenu";
            // 
            // colNomeMenu
            // 
            this.colNomeMenu.FieldName = "NomeMenu";
            this.colNomeMenu.Name = "colNomeMenu";
            // 
            // colMenuPai
            // 
            this.colMenuPai.FieldName = "MenuPai";
            this.colMenuPai.Name = "colMenuPai";
            this.colMenuPai.OptionsColumn.AllowEdit = false;
            this.colMenuPai.Visible = true;
            this.colMenuPai.VisibleIndex = 0;
            this.colMenuPai.Width = 70;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;
            this.colStatus.Width = 95;
            // 
            // colMenuText
            // 
            this.colMenuText.FieldName = "MenuText";
            this.colMenuText.Name = "colMenuText";
            this.colMenuText.OptionsColumn.AllowEdit = false;
            this.colMenuText.Visible = true;
            this.colMenuText.VisibleIndex = 1;
            this.colMenuText.Width = 205;
            // 
            // colMenuType
            // 
            this.colMenuType.FieldName = "MenuType";
            this.colMenuType.Name = "colMenuType";
            this.colMenuType.OptionsColumn.AllowEdit = false;
            this.colMenuType.Visible = true;
            this.colMenuType.VisibleIndex = 2;
            this.colMenuType.Width = 149;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(198, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(96, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Data final da licença";
            // 
            // dtEndDate
            // 
            this.dtEndDate.EditValue = null;
            this.dtEndDate.Location = new System.Drawing.Point(198, 83);
            this.dtEndDate.MenuManager = this.barManager1;
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEndDate.Size = new System.Drawing.Size(136, 20);
            this.dtEndDate.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(114, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Data de início da licença";
            // 
            // dtStartDate
            // 
            this.dtStartDate.EditValue = null;
            this.dtStartDate.Location = new System.Drawing.Point(15, 83);
            this.dtStartDate.MenuManager = this.barManager1;
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStartDate.Size = new System.Drawing.Size(136, 20);
            this.dtStartDate.TabIndex = 1;
            // 
            // colController
            // 
            this.colController.Caption = "Controller";
            this.colController.FieldName = "ControllerClass";
            this.colController.Name = "colController";
            // 
            // colAction
            // 
            this.colAction.Caption = "Action";
            this.colAction.FieldName = "ActionController";
            this.colAction.Name = "colAction";
            // 
            // XFrmLicenseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 407);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "XFrmLicenseManager";
            this.Text = "XFrmLicenseManager";
            this.Shown += new System.EventHandler(this.XFrmLicenseManager_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itsLicenseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLicenses)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMenusAct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itsMenuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMenusAct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnNewLicense;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl gridControlLicenses;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLicenses;
        private DevExpress.XtraBars.BarButtonItem btnSaveLicense;
        private DevExpress.XtraBars.BarButtonItem btnExportLicense;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControlMenusAct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMenusAct;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtEndDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        //private ITE.Components.LookUp.LookUpCliFor lookUpCliFor1;
        private DevExpress.XtraEditors.DateEdit dtStartDate;
        private System.Windows.Forms.BindingSource itsMenuBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIdMenu;
        private DevExpress.XtraGrid.Columns.GridColumn colNomeMenu;
        private DevExpress.XtraGrid.Columns.GridColumn colMenuPai;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colMenuText;
        private DevExpress.XtraGrid.Columns.GridColumn colMenuType;
        private System.Windows.Forms.BindingSource itsLicenseBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIdLicense;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLicenseData;
        private DevExpress.XtraGrid.Columns.GridColumn colLicenseStatus;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cbCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colController;
        private DevExpress.XtraGrid.Columns.GridColumn colAction;
    }
}