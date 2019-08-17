namespace ITSolution.Admin.Forms.ContextUtil
{
    partial class XFrmAppConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmAppConfig));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnAppConfig = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnTestarConexao = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barToggleCriptografar = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.barBtnLoadConfig = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnAddConnection = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.cbDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtServerName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtConnectionName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cbAuthentication = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.radioDatabase = new System.Windows.Forms.RadioButton();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.radioServerName = new DevExpress.XtraEditors.RadioGroup();
            this.lblXmlConnections = new DevExpress.XtraEditors.LabelControl();
            this.cbConnections = new DevExpress.XtraEditors.ComboBoxEdit();
            this.openFileAppXml = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConnectionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAuthentication.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbConnections.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barBtnAppConfig,
            this.barBtnTestarConexao,
            this.barBtnCancelar,
            this.barToggleCriptografar,
            this.barBtnLoadConfig,
            this.barBtnAddConnection});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(571, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // barBtnAppConfig
            // 
            this.barBtnAppConfig.Caption = "Configure Connection";
            this.barBtnAppConfig.Glyph = global::ITSolution.Admin.Properties.Resources.ExtendedProperty;
            this.barBtnAppConfig.Id = 1;
            this.barBtnAppConfig.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.barBtnAppConfig.Name = "barBtnAppConfig";
            this.barBtnAppConfig.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnAppConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnAppConfig_ItemClick);
            // 
            // barBtnTestarConexao
            // 
            this.barBtnTestarConexao.Caption = "Connection Test";
            this.barBtnTestarConexao.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnTestarConexao.Glyph")));
            this.barBtnTestarConexao.Id = 2;
            this.barBtnTestarConexao.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T));
            this.barBtnTestarConexao.Name = "barBtnTestarConexao";
            this.barBtnTestarConexao.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            toolTipTitleItem1.Text = "Teste de conexão";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Verifica se os dados da conexão são válidos.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.barBtnTestarConexao.SuperTip = superToolTip1;
            this.barBtnTestarConexao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnTestarConexao_ItemClick);
            // 
            // barBtnCancelar
            // 
            this.barBtnCancelar.Caption = "Cancelar";
            this.barBtnCancelar.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnCancelar.Glyph")));
            this.barBtnCancelar.Id = 3;
            this.barBtnCancelar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W));
            this.barBtnCancelar.Name = "barBtnCancelar";
            this.barBtnCancelar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnCancelar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCancelar_ItemClick);
            // 
            // barToggleCriptografar
            // 
            this.barToggleCriptografar.BindableChecked = true;
            this.barToggleCriptografar.Caption = "Encrypt";
            this.barToggleCriptografar.Checked = true;
            this.barToggleCriptografar.Id = 4;
            this.barToggleCriptografar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.barToggleCriptografar.Name = "barToggleCriptografar";
            this.barToggleCriptografar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            toolTipTitleItem2.Text = "Criptografar XML";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Os dados do arquivo de conexão serão criptografados.\r\n";
            toolTipTitleItem3.LeftIndent = 6;
            toolTipTitleItem3.Text = "Somente a senha";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            superToolTip2.Items.Add(toolTipTitleItem3);
            this.barToggleCriptografar.SuperTip = superToolTip2;
            // 
            // barBtnLoadConfig
            // 
            this.barBtnLoadConfig.Caption = "Load XML";
            this.barBtnLoadConfig.Glyph = global::ITSolution.Admin.Properties.Resources.xml;
            this.barBtnLoadConfig.Id = 6;
            this.barBtnLoadConfig.Name = "barBtnLoadConfig";
            this.barBtnLoadConfig.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barBtnLoadConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnLoadConfig_ItemClick);
            // 
            // barBtnAddConnection
            // 
            this.barBtnAddConnection.Caption = "Add New Connection";
            this.barBtnAddConnection.Glyph = global::ITSolution.Admin.Properties.Resources.xmltable;
            this.barBtnAddConnection.Id = 8;
            this.barBtnAddConnection.Name = "barBtnAddConnection";
            this.barBtnAddConnection.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barBtnAddConnection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnAddConnection_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnAppConfig);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnTestarConexao);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnAddConnection);
            this.ribbonPageGroup1.ItemLinks.Add(this.barToggleCriptografar);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnLoadConfig);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barBtnCancelar);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Cancelar";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 588);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(571, 32);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(35, 92);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(89, 14);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Database Details";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(434, 77);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 24);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbDatabase
            // 
            this.cbDatabase.Location = new System.Drawing.Point(35, 57);
            this.cbDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDatabase.MenuManager = this.ribbon;
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDatabase.Properties.Appearance.Options.UseFont = true;
            this.cbDatabase.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbDatabase.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDatabase.Properties.ReadOnly = true;
            this.cbDatabase.Properties.DoubleClick += new System.EventHandler(this.btnRefresh_Click);
            this.cbDatabase.Size = new System.Drawing.Size(296, 20);
            this.cbDatabase.TabIndex = 5;
            this.cbDatabase.DoubleClick += new System.EventHandler(this.cbDatabase_DoubleClick);
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(6, 88);
            this.txtServerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtServerName.MenuManager = this.ribbon;
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerName.Properties.Appearance.Options.UseFont = true;
            this.txtServerName.Size = new System.Drawing.Size(407, 20);
            this.txtServerName.TabIndex = 1;
            this.txtServerName.Leave += new System.EventHandler(this.txtServerName_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(6, 68);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 14);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Server name:";
            // 
            // txtConnectionName
            // 
            this.txtConnectionName.Location = new System.Drawing.Point(6, 44);
            this.txtConnectionName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConnectionName.MenuManager = this.ribbon;
            this.txtConnectionName.Name = "txtConnectionName";
            this.txtConnectionName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnectionName.Properties.Appearance.Options.UseFont = true;
            this.txtConnectionName.Size = new System.Drawing.Size(189, 20);
            this.txtConnectionName.TabIndex = 0;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(6, 24);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(31, 14);
            this.labelControl6.TabIndex = 20;
            this.labelControl6.Text = "Name";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.cbAuthentication);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtUser);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtPassword);
            this.groupControl1.Location = new System.Drawing.Point(16, 274);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(540, 154);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Log on to the Server";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl4.Location = new System.Drawing.Point(9, 33);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(85, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Authentication:";
            // 
            // cbAuthentication
            // 
            this.cbAuthentication.Location = new System.Drawing.Point(100, 31);
            this.cbAuthentication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAuthentication.MenuManager = this.ribbon;
            this.cbAuthentication.Name = "cbAuthentication";
            this.cbAuthentication.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbAuthentication.Properties.Appearance.Options.UseFont = true;
            this.cbAuthentication.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAuthentication.Properties.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cbAuthentication.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbAuthentication.Size = new System.Drawing.Size(382, 20);
            this.cbAuthentication.TabIndex = 2;
            this.cbAuthentication.SelectedIndexChanged += new System.EventHandler(this.cbAuthentication_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Location = new System.Drawing.Point(56, 77);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "User name:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(129, 75);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUser.MenuManager = this.ribbon;
            this.txtUser.Name = "txtUser";
            this.txtUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtUser.Properties.Appearance.Options.UseFont = true;
            this.txtUser.Size = new System.Drawing.Size(296, 20);
            this.txtUser.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl3.Location = new System.Drawing.Point(65, 111);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(129, 109);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.MenuManager = this.ribbon;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(296, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.radioDatabase);
            this.groupControl2.Controls.Add(this.lookUpEdit1);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.btnRefresh);
            this.groupControl2.Controls.Add(this.cbDatabase);
            this.groupControl2.Location = new System.Drawing.Point(16, 437);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(540, 144);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Connect to a Database";
            // 
            // radioDatabase
            // 
            this.radioDatabase.AutoSize = true;
            this.radioDatabase.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radioDatabase.Location = new System.Drawing.Point(19, 34);
            this.radioDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioDatabase.Name = "radioDatabase";
            this.radioDatabase.Size = new System.Drawing.Size(199, 18);
            this.radioDatabase.TabIndex = 12;
            this.radioDatabase.TabStop = true;
            this.radioDatabase.Text = "Select or enter database name:";
            this.radioDatabase.UseVisualStyleBackColor = true;
            this.radioDatabase.CheckedChanged += new System.EventHandler(this.radioDatabase_CheckedChanged);
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.EditValue = "";
            this.lookUpEdit1.Location = new System.Drawing.Point(35, 111);
            this.lookUpEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lookUpEdit1.MenuManager = this.ribbon;
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lookUpEdit1.Properties.Appearance.Options.UseFont = true;
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.NullText = "";
            this.lookUpEdit1.Size = new System.Drawing.Size(478, 20);
            this.lookUpEdit1.TabIndex = 7;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.radioServerName);
            this.groupControl3.Controls.Add(this.lblXmlConnections);
            this.groupControl3.Controls.Add(this.cbConnections);
            this.groupControl3.Controls.Add(this.txtServerName);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.txtConnectionName);
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Location = new System.Drawing.Point(16, 155);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(540, 114);
            this.groupControl3.TabIndex = 23;
            this.groupControl3.Text = "Connection";
            // 
            // radioServerName
            // 
            this.radioServerName.Dock = System.Windows.Forms.DockStyle.Right;
            this.radioServerName.Location = new System.Drawing.Point(433, 21);
            this.radioServerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioServerName.MenuManager = this.ribbon;
            this.radioServerName.Name = "radioServerName";
            this.radioServerName.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Static"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Hostname"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Local IP")});
            this.radioServerName.Size = new System.Drawing.Size(105, 91);
            this.radioServerName.TabIndex = 14;
            this.radioServerName.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // lblXmlConnections
            // 
            this.lblXmlConnections.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXmlConnections.Location = new System.Drawing.Point(225, 24);
            this.lblXmlConnections.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblXmlConnections.Name = "lblXmlConnections";
            this.lblXmlConnections.Size = new System.Drawing.Size(93, 14);
            this.lblXmlConnections.TabIndex = 22;
            this.lblXmlConnections.Text = "XML Connections";
            this.lblXmlConnections.Visible = false;
            // 
            // cbConnections
            // 
            this.cbConnections.Location = new System.Drawing.Point(225, 44);
            this.cbConnections.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbConnections.MenuManager = this.ribbon;
            this.cbConnections.Name = "cbConnections";
            this.cbConnections.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbConnections.Properties.Appearance.Options.UseFont = true;
            this.cbConnections.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbConnections.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbConnections.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbConnections.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbConnections.Size = new System.Drawing.Size(189, 20);
            this.cbConnections.TabIndex = 13;
            this.cbConnections.Visible = false;
            this.cbConnections.SelectedIndexChanged += new System.EventHandler(this.cbConnections_SelectedIndexChanged);
            // 
            // openFileAppXml
            // 
            this.openFileAppXml.Filter = "App Config |*.xml";
            // 
            // XFrmAppConfig
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 620);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "XFrmAppConfig";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Connection Properties";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConnectionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAuthentication.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbConnections.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barBtnAppConfig;
        private DevExpress.XtraBars.BarButtonItem barBtnTestarConexao;
        private DevExpress.XtraBars.BarButtonItem barBtnCancelar;
        private DevExpress.XtraBars.BarToggleSwitchItem barToggleCriptografar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.ComboBoxEdit cbDatabase;
        private DevExpress.XtraEditors.TextEdit txtServerName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtConnectionName;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private System.Windows.Forms.RadioButton radioDatabase;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cbAuthentication;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraBars.BarButtonItem barBtnLoadConfig;
        private System.Windows.Forms.OpenFileDialog openFileAppXml;
        private DevExpress.XtraEditors.ComboBoxEdit cbConnections;
        private DevExpress.XtraEditors.LabelControl lblXmlConnections;
        private DevExpress.XtraEditors.RadioGroup radioServerName;
        private DevExpress.XtraBars.BarButtonItem barBtnAddConnection;
    }
}