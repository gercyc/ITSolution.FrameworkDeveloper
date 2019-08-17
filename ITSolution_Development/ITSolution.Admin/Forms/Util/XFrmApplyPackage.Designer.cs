using DevExpress.Utils;

namespace ITSolution.Admin.Forms.Util
{
    partial class XFrmApplyPackage
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmApplyPackage));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chRoolbackTransaction = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtUpdateFile = new DevExpress.XtraEditors.TextEdit();
            this.btnSelecionarUpdateFile = new DevExpress.XtraEditors.SimpleButton();
            this.pnlDlls = new DevExpress.XtraEditors.PanelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnSelecionar = new DevExpress.XtraEditors.SimpleButton();
            this.txtInstallDir = new DevExpress.XtraEditors.TextEdit();
            this.groupControlInfoPackage = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lbDtPublish = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.memoEditDesc = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlSql = new DevExpress.XtraEditors.PanelControl();
            this.lbPwd = new DevExpress.XtraEditors.LabelControl();
            this.lbUsr = new DevExpress.XtraEditors.LabelControl();
            this.txtPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.chAutenticacao = new DevExpress.XtraEditors.CheckEdit();
            this.btnConectar = new DevExpress.XtraEditors.SimpleButton();
            this.txtServerName = new DevExpress.XtraEditors.TextEdit();
            this.lblDatabase = new DevExpress.XtraEditors.LabelControl();
            this.cbDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.chExibirArquivo = new DevExpress.XtraEditors.CheckEdit();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.scintilla = new ScintillaNET.Scintilla();
            this.lblPercent = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFilePkg = new System.Windows.Forms.OpenFileDialog();
            this.openFileITE = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chRoolbackTransaction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdateFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDlls)).BeginInit();
            this.pnlDlls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstallDir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfoPackage)).BeginInit();
            this.groupControlInfoPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSql)).BeginInit();
            this.pnlSql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAutenticacao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).BeginInit();
            this.completionWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chExibirArquivo.Properties)).BeginInit();
            this.wizardPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelText = "Cancelar";
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage2);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wizardControl1.MinimumSize = new System.Drawing.Size(117, 123);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "&Avançar >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.wizardPage2,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< &Voltar";
            this.wizardControl1.Size = new System.Drawing.Size(873, 671);
            this.wizardControl1.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_CancelClick);
            this.wizardControl1.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_FinishClick);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.IntroductionText = "Este assistente irá guia-lo durante o processo de atualização do seu software";
            this.welcomeWizardPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "Para continuar, clique em Avançar";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(656, 521);
            this.welcomeWizardPage1.Text = "Bem-vindo ao assistente de atualização";
            // 
            // wizardPage1
            // 
            this.wizardPage1.AllowNext = false;
            this.wizardPage1.Controls.Add(this.panelControl1);
            this.wizardPage1.Controls.Add(this.pnlDlls);
            this.wizardPage1.Controls.Add(this.groupControlInfoPackage);
            this.wizardPage1.Controls.Add(this.pnlSql);
            this.wizardPage1.DescriptionText = "Observação: O assistente tentará detectar automaticamente o diretório de instalaç" +
    "ão do software";
            this.wizardPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(841, 497);
            this.wizardPage1.Text = "Informe o diretório de instalação do software";
            this.wizardPage1.PageValidating += new DevExpress.XtraWizard.WizardPageValidatingEventHandler(this.wizardPage1_PageValidating);
            this.wizardPage1.PageCommit += new System.EventHandler(this.wizardPage1_PageCommit);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.chRoolbackTransaction);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtUpdateFile);
            this.panelControl1.Controls.Add(this.btnSelecionarUpdateFile);
            this.panelControl1.Location = new System.Drawing.Point(12, 11);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(815, 60);
            this.panelControl1.TabIndex = 3;
            // 
            // chRoolbackTransaction
            // 
            this.chRoolbackTransaction.EditValue = true;
            this.chRoolbackTransaction.Location = new System.Drawing.Point(155, 3);
            this.chRoolbackTransaction.Name = "chRoolbackTransaction";
            this.chRoolbackTransaction.Properties.Caption = "Single Transaction";
            this.chRoolbackTransaction.Size = new System.Drawing.Size(179, 20);
            toolTipTitleItem1.Text = "Rollback Transaction";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Somente a transação que falhar será desfeita.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.chRoolbackTransaction.SuperTip = superToolTip1;
            this.chRoolbackTransaction.TabIndex = 21;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelControl3.Location = new System.Drawing.Point(7, 7);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(129, 16);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Arquivo de atualização";
            // 
            // txtUpdateFile
            // 
            this.txtUpdateFile.Location = new System.Drawing.Point(7, 28);
            this.txtUpdateFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUpdateFile.Name = "txtUpdateFile";
            this.txtUpdateFile.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtUpdateFile.Properties.Appearance.Options.UseFont = true;
            this.txtUpdateFile.Properties.ReadOnly = true;
            this.txtUpdateFile.Size = new System.Drawing.Size(714, 22);
            this.txtUpdateFile.TabIndex = 0;
            // 
            // btnSelecionarUpdateFile
            // 
            this.btnSelecionarUpdateFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarUpdateFile.Image")));
            this.btnSelecionarUpdateFile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSelecionarUpdateFile.Location = new System.Drawing.Point(729, 27);
            this.btnSelecionarUpdateFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelecionarUpdateFile.Name = "btnSelecionarUpdateFile";
            this.btnSelecionarUpdateFile.Size = new System.Drawing.Size(38, 25);
            this.btnSelecionarUpdateFile.TabIndex = 1;
            this.btnSelecionarUpdateFile.Text = "...";
            this.btnSelecionarUpdateFile.Click += new System.EventHandler(this.btnSelecionarUpdateFile_Click);
            // 
            // pnlDlls
            // 
            this.pnlDlls.Controls.Add(this.lblStatus);
            this.pnlDlls.Controls.Add(this.labelControl5);
            this.pnlDlls.Controls.Add(this.btnSelecionar);
            this.pnlDlls.Controls.Add(this.txtInstallDir);
            this.pnlDlls.Location = new System.Drawing.Point(12, 159);
            this.pnlDlls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDlls.Name = "pnlDlls";
            this.pnlDlls.Size = new System.Drawing.Size(815, 85);
            this.pnlDlls.TabIndex = 4;
            this.pnlDlls.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(6, 60);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 16);
            this.lblStatus.TabIndex = 26;
            this.lblStatus.Text = "Status";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelControl5.Location = new System.Drawing.Point(6, 10);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(79, 16);
            this.labelControl5.TabIndex = 25;
            this.labelControl5.Text = "Instalado em:";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionar.Image")));
            this.btnSelecionar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSelecionar.Location = new System.Drawing.Point(727, 32);
            this.btnSelecionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(38, 25);
            this.btnSelecionar.TabIndex = 24;
            this.btnSelecionar.Text = "...";
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionarITE_Click);
            // 
            // txtInstallDir
            // 
            this.txtInstallDir.Location = new System.Drawing.Point(6, 33);
            this.txtInstallDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInstallDir.Name = "txtInstallDir";
            this.txtInstallDir.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtInstallDir.Properties.Appearance.Options.UseFont = true;
            this.txtInstallDir.Size = new System.Drawing.Size(714, 22);
            this.txtInstallDir.TabIndex = 23;
            // 
            // groupControlInfoPackage
            // 
            this.groupControlInfoPackage.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControlInfoPackage.AppearanceCaption.Options.UseFont = true;
            this.groupControlInfoPackage.Controls.Add(this.labelControl6);
            this.groupControlInfoPackage.Controls.Add(this.labelControl7);
            this.groupControlInfoPackage.Controls.Add(this.lbDtPublish);
            this.groupControlInfoPackage.Controls.Add(this.labelControl4);
            this.groupControlInfoPackage.Controls.Add(this.memoEditDesc);
            this.groupControlInfoPackage.Controls.Add(this.labelControl1);
            this.groupControlInfoPackage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControlInfoPackage.Location = new System.Drawing.Point(0, 259);
            this.groupControlInfoPackage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControlInfoPackage.Name = "groupControlInfoPackage";
            this.groupControlInfoPackage.Size = new System.Drawing.Size(841, 238);
            this.groupControlInfoPackage.TabIndex = 34;
            this.groupControlInfoPackage.Text = "Informações do pacote";
            this.groupControlInfoPackage.Visible = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(279, 41);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(49, 16);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "%num%";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(224, 41);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(50, 16);
            this.labelControl7.TabIndex = 5;
            this.labelControl7.Text = "Número:";
            // 
            // lbDtPublish
            // 
            this.lbDtPublish.Location = new System.Drawing.Point(541, 41);
            this.lbDtPublish.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbDtPublish.Name = "lbDtPublish";
            this.lbDtPublish.Size = new System.Drawing.Size(35, 16);
            this.lbDtPublish.TabIndex = 3;
            this.lbDtPublish.Text = "%dt%";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(422, 41);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(113, 16);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Data de Publicação:";
            // 
            // memoEditDesc
            // 
            this.memoEditDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.memoEditDesc.Location = new System.Drawing.Point(2, 65);
            this.memoEditDesc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.memoEditDesc.Name = "memoEditDesc";
            this.memoEditDesc.Properties.ReadOnly = true;
            this.memoEditDesc.Size = new System.Drawing.Size(837, 171);
            this.memoEditDesc.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 41);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Descrição:";
            // 
            // pnlSql
            // 
            this.pnlSql.Controls.Add(this.lbPwd);
            this.pnlSql.Controls.Add(this.lbUsr);
            this.pnlSql.Controls.Add(this.txtPwd);
            this.pnlSql.Controls.Add(this.txtUser);
            this.pnlSql.Controls.Add(this.chAutenticacao);
            this.pnlSql.Controls.Add(this.btnConectar);
            this.pnlSql.Controls.Add(this.txtServerName);
            this.pnlSql.Controls.Add(this.lblDatabase);
            this.pnlSql.Controls.Add(this.cbDatabase);
            this.pnlSql.Controls.Add(this.labelControl2);
            this.pnlSql.Location = new System.Drawing.Point(12, 78);
            this.pnlSql.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSql.Name = "pnlSql";
            this.pnlSql.Size = new System.Drawing.Size(815, 73);
            this.pnlSql.TabIndex = 5;
            this.pnlSql.Visible = false;
            // 
            // lbPwd
            // 
            this.lbPwd.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lbPwd.Location = new System.Drawing.Point(373, 16);
            this.lbPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbPwd.Name = "lbPwd";
            this.lbPwd.Size = new System.Drawing.Size(55, 16);
            this.lbPwd.TabIndex = 41;
            this.lbPwd.Text = "Password";
            this.lbPwd.Visible = false;
            // 
            // lbUsr
            // 
            this.lbUsr.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lbUsr.Location = new System.Drawing.Point(259, 16);
            this.lbUsr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbUsr.Name = "lbUsr";
            this.lbUsr.Size = new System.Drawing.Size(26, 16);
            this.lbUsr.TabIndex = 40;
            this.lbUsr.Text = "User";
            this.lbUsr.Visible = false;
            // 
            // txtPwd
            // 
            this.txtPwd.EditValue = "";
            this.txtPwd.Location = new System.Drawing.Point(373, 38);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Properties.UseSystemPasswordChar = true;
            this.txtPwd.Size = new System.Drawing.Size(99, 22);
            this.txtPwd.TabIndex = 4;
            this.txtPwd.Visible = false;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(259, 38);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(98, 22);
            this.txtUser.TabIndex = 3;
            this.txtUser.Visible = false;
            // 
            // chAutenticacao
            // 
            this.chAutenticacao.Location = new System.Drawing.Point(135, 12);
            this.chAutenticacao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chAutenticacao.Name = "chAutenticacao";
            this.chAutenticacao.Properties.Caption = "Autenticação";
            this.chAutenticacao.Size = new System.Drawing.Size(108, 20);
            this.chAutenticacao.TabIndex = 37;
            this.chAutenticacao.CheckedChanged += new System.EventHandler(this.chkAutenticacao_CheckedChanged);
            // 
            // btnConectar
            // 
            this.btnConectar.Image = ((System.Drawing.Image)(resources.GetObject("btnConectar.Image")));
            this.btnConectar.Location = new System.Drawing.Point(701, 32);
            this.btnConectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(87, 28);
            this.btnConectar.TabIndex = 34;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(6, 38);
            this.txtServerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtServerName.Properties.Appearance.Options.UseFont = true;
            this.txtServerName.Size = new System.Drawing.Size(237, 22);
            this.txtServerName.TabIndex = 2;
            this.txtServerName.Leave += new System.EventHandler(this.txtServerName_Leave);
            // 
            // lblDatabase
            // 
            this.lblDatabase.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblDatabase.Location = new System.Drawing.Point(486, 16);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(95, 16);
            this.lblDatabase.TabIndex = 23;
            this.lblDatabase.Text = "Banco de dados:";
            // 
            // cbDatabase
            // 
            this.cbDatabase.Location = new System.Drawing.Point(486, 38);
            this.cbDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.cbDatabase.Properties.Appearance.Options.UseFont = true;
            this.cbDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDatabase.Size = new System.Drawing.Size(194, 22);
            this.cbDatabase.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelControl2.Location = new System.Drawing.Point(6, 16);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(103, 16);
            this.labelControl2.TabIndex = 33;
            this.labelControl2.Text = "Nome do Servidor";
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Controls.Add(this.chExibirArquivo);
            this.completionWizardPage1.FinishText = "Atualização de software concluída com sucesso !";
            this.completionWizardPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "Para fechar, clique em \"Terminar\"";
            this.completionWizardPage1.Size = new System.Drawing.Size(656, 521);
            this.completionWizardPage1.Text = "Finalizando o assistente de atualização";
            // 
            // chExibirArquivo
            // 
            this.chExibirArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chExibirArquivo.Location = new System.Drawing.Point(495, 495);
            this.chExibirArquivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chExibirArquivo.Name = "chExibirArquivo";
            this.chExibirArquivo.Properties.Caption = "Iniciar aplicação";
            this.chExibirArquivo.Size = new System.Drawing.Size(157, 20);
            this.chExibirArquivo.TabIndex = 2;
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.scintilla);
            this.wizardPage2.Controls.Add(this.lblPercent);
            this.wizardPage2.Controls.Add(this.progressBarControl1);
            this.wizardPage2.DescriptionText = "Por favor aguarde enquanto as tarefas são executadas";
            this.wizardPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(841, 497);
            this.wizardPage2.Text = "Atualização em andamento";
            // 
            // scintilla
            // 
            this.scintilla.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scintilla.Lexer = ScintillaNET.Lexer.Sql;
            this.scintilla.Location = new System.Drawing.Point(0, 85);
            this.scintilla.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scintilla.Name = "scintilla";
            this.scintilla.Size = new System.Drawing.Size(841, 412);
            this.scintilla.TabIndex = 6;
            this.scintilla.TextChanged += new System.EventHandler(this.scintilla_TextChanged);
            // 
            // lblPercent
            // 
            this.lblPercent.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblPercent.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.lblPercent.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.lblPercent.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblPercent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblPercent.Location = new System.Drawing.Point(409, 18);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(19, 16);
            this.lblPercent.TabIndex = 4;
            this.lblPercent.Text = "0%";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(49, 39);
            this.progressBarControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.progressBarControl1.Properties.Step = 1;
            this.progressBarControl1.Size = new System.Drawing.Size(735, 25);
            this.progressBarControl1.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // openFilePkg
            // 
            this.openFilePkg.Filter = "ITS Package | *.itspkg";
            // 
            // openFileITE
            // 
            this.openFileITE.Filter = "ITE Solution | *.exe";
            // 
            // XFrmApplyPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 671);
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "XFrmApplyPackage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updater ITE Solution";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.XFrmApplyPackage_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XFrmApplyPackage_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chRoolbackTransaction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdateFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDlls)).EndInit();
            this.pnlDlls.ResumeLayout(false);
            this.pnlDlls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstallDir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfoPackage)).EndInit();
            this.groupControlInfoPackage.ResumeLayout(false);
            this.groupControlInfoPackage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSql)).EndInit();
            this.pnlSql.ResumeLayout(false);
            this.pnlSql.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAutenticacao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).EndInit();
            this.completionWizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chExibirArquivo.Properties)).EndInit();
            this.wizardPage2.ResumeLayout(false);
            this.wizardPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnSelecionarUpdateFile;
        private DevExpress.XtraEditors.TextEdit txtUpdateFile;
        private DevExpress.XtraEditors.ComboBoxEdit cbDatabase;
        private DevExpress.XtraEditors.LabelControl lblDatabase;
        private DevExpress.XtraEditors.LabelControl lblPercent;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.CheckEdit chExibirArquivo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFilePkg;
        private DevExpress.XtraEditors.TextEdit txtServerName;
        private DevExpress.XtraEditors.GroupControl groupControlInfoPackage;
        private DevExpress.XtraEditors.LabelControl lbDtPublish;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.MemoEdit memoEditDesc;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl pnlSql;
        private DevExpress.XtraEditors.PanelControl pnlDlls;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnSelecionar;
        private DevExpress.XtraEditors.TextEdit txtInstallDir;
        private System.Windows.Forms.OpenFileDialog openFileITE;
        private DevExpress.XtraEditors.SimpleButton btnConectar;
        private DevExpress.XtraEditors.CheckEdit chAutenticacao;
        private DevExpress.XtraEditors.TextEdit txtPwd;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.LabelControl lbPwd;
        private DevExpress.XtraEditors.LabelControl lbUsr;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ScintillaNET.Scintilla scintilla;
        private DevExpress.XtraEditors.CheckEdit chRoolbackTransaction;
    }
}