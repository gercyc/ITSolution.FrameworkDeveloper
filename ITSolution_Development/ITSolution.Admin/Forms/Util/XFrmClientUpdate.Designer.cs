namespace ITSolution.Admin.Forms.Util
{
    partial class XFrmClientUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmClientUpdate));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.pnlSql = new DevExpress.XtraEditors.PanelControl();
            this.lbPwd = new DevExpress.XtraEditors.LabelControl();
            this.lbUsr = new DevExpress.XtraEditors.LabelControl();
            this.txtPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtUsr = new DevExpress.XtraEditors.TextEdit();
            this.chAutenticacao = new DevExpress.XtraEditors.CheckEdit();
            this.btnConectar = new DevExpress.XtraEditors.SimpleButton();
            this.txtServerName = new DevExpress.XtraEditors.TextEdit();
            this.lblDatabase = new DevExpress.XtraEditors.LabelControl();
            this.cbDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.txtInstallDir = new DevExpress.XtraEditors.TextEdit();
            this.btnSelecionar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.rChListTask = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.chExibirArquivo = new DevExpress.XtraEditors.CheckEdit();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.richLog = new System.Windows.Forms.RichTextBox();
            this.lblPercent = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileZip = new System.Windows.Forms.OpenFileDialog();
            this.folderInstallDir = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSql)).BeginInit();
            this.pnlSql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAutenticacao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstallDir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rChListTask)).BeginInit();
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
            this.wizardControl1.Size = new System.Drawing.Size(873, 596);
            this.wizardControl1.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_CancelClick);
            this.wizardControl1.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_FinishClick);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.IntroductionText = "Este assistente irá guia-lo durante o processo de atualização do seu software";
            this.welcomeWizardPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "Para continuar, clique em Avançar";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(656, 446);
            this.welcomeWizardPage1.Text = "Bem-vindo ao assistente de atualização";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.pnlSql);
            this.wizardPage1.Controls.Add(this.panelControl1);
            this.wizardPage1.Controls.Add(this.groupControl1);
            this.wizardPage1.DescriptionText = "Observação: O assistente tentará detectar automaticamente o diretório de instalaç" +
    "ão do software";
            this.wizardPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(841, 422);
            this.wizardPage1.Text = "Informe o diretório de instalação do software";
            this.wizardPage1.PageValidating += new DevExpress.XtraWizard.WizardPageValidatingEventHandler(this.wizardPage1_PageValidating);
            this.wizardPage1.PageCommit += new System.EventHandler(this.wizardPage1_PageCommit);
            this.wizardPage1.PageInit += new System.EventHandler(this.wizardPage1_PageInit);
            // 
            // pnlSql
            // 
            this.pnlSql.Controls.Add(this.lbPwd);
            this.pnlSql.Controls.Add(this.lbUsr);
            this.pnlSql.Controls.Add(this.txtPwd);
            this.pnlSql.Controls.Add(this.txtUsr);
            this.pnlSql.Controls.Add(this.chAutenticacao);
            this.pnlSql.Controls.Add(this.btnConectar);
            this.pnlSql.Controls.Add(this.txtServerName);
            this.pnlSql.Controls.Add(this.lblDatabase);
            this.pnlSql.Controls.Add(this.cbDatabase);
            this.pnlSql.Controls.Add(this.labelControl2);
            this.pnlSql.Location = new System.Drawing.Point(12, 122);
            this.pnlSql.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSql.Name = "pnlSql";
            this.pnlSql.Size = new System.Drawing.Size(815, 73);
            this.pnlSql.TabIndex = 23;
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
            this.txtPwd.TabIndex = 39;
            this.txtPwd.Visible = false;
            // 
            // txtUsr
            // 
            this.txtUsr.Location = new System.Drawing.Point(259, 38);
            this.txtUsr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsr.Name = "txtUsr";
            this.txtUsr.Size = new System.Drawing.Size(98, 22);
            this.txtUsr.TabIndex = 38;
            this.txtUsr.Visible = false;
            // 
            // chAutenticacao
            // 
            this.chAutenticacao.Location = new System.Drawing.Point(135, 12);
            this.chAutenticacao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chAutenticacao.Name = "chAutenticacao";
            this.chAutenticacao.Properties.Caption = "Autenticação";
            this.chAutenticacao.Size = new System.Drawing.Size(108, 20);
            this.chAutenticacao.TabIndex = 37;
            this.chAutenticacao.CheckedChanged += new System.EventHandler(this.chAutenticacao_CheckedChanged);
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
            this.cbDatabase.TabIndex = 3;
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblStatus);
            this.panelControl1.Controls.Add(this.txtInstallDir);
            this.panelControl1.Controls.Add(this.btnSelecionar);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 21);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(815, 86);
            this.panelControl1.TabIndex = 37;
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(6, 62);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 16);
            this.lblStatus.TabIndex = 22;
            this.lblStatus.Text = "Status";
            // 
            // txtInstallDir
            // 
            this.txtInstallDir.Location = new System.Drawing.Point(6, 30);
            this.txtInstallDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInstallDir.Name = "txtInstallDir";
            this.txtInstallDir.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtInstallDir.Properties.Appearance.Options.UseFont = true;
            this.txtInstallDir.Size = new System.Drawing.Size(710, 22);
            this.txtInstallDir.TabIndex = 19;
            this.txtInstallDir.EditValueChanged += new System.EventHandler(this.txtInstallDir_EditValueChanged);
            this.txtInstallDir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInstallDir_KeyDown);
            this.txtInstallDir.Leave += new System.EventHandler(this.txtInstallDir_Leave);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionar.Image")));
            this.btnSelecionar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSelecionar.Location = new System.Drawing.Point(723, 30);
            this.btnSelecionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(38, 25);
            this.btnSelecionar.TabIndex = 20;
            this.btnSelecionar.Text = "...";
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionarInstallDir_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelControl1.Location = new System.Drawing.Point(6, 9);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(113, 16);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Local de instalação:";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.rChListTask);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 208);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(841, 214);
            this.groupControl1.TabIndex = 35;
            this.groupControl1.Text = "Tarefas:";
            // 
            // rChListTask
            // 
            this.rChListTask.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.rChListTask.Appearance.Options.UseFont = true;
            this.rChListTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rChListTask.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Execute SQL Script"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(1, "Update DLLs"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(2, "Update ITE DLLS"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(3, "Update ITSolution DLLS")});
            this.rChListTask.Location = new System.Drawing.Point(2, 28);
            this.rChListTask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rChListTask.Name = "rChListTask";
            this.rChListTask.Size = new System.Drawing.Size(837, 184);
            this.rChListTask.TabIndex = 36;
            this.rChListTask.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.rChListTask_ItemCheck);
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Controls.Add(this.chExibirArquivo);
            this.completionWizardPage1.FinishText = "Atualização de software concluída com sucesso !";
            this.completionWizardPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "Para fechar, clique em \"Terminar\"";
            this.completionWizardPage1.Size = new System.Drawing.Size(656, 446);
            this.completionWizardPage1.Text = "Finalizando o assistente de atualização";
            this.completionWizardPage1.PageValidating += new DevExpress.XtraWizard.WizardPageValidatingEventHandler(this.completionWizardPage1_PageValidating);
            // 
            // chExibirArquivo
            // 
            this.chExibirArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chExibirArquivo.Location = new System.Drawing.Point(495, 420);
            this.chExibirArquivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chExibirArquivo.Name = "chExibirArquivo";
            this.chExibirArquivo.Properties.Caption = "Iniciar aplicação";
            this.chExibirArquivo.Size = new System.Drawing.Size(157, 20);
            this.chExibirArquivo.TabIndex = 2;
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.richLog);
            this.wizardPage2.Controls.Add(this.lblPercent);
            this.wizardPage2.Controls.Add(this.progressBarControl1);
            this.wizardPage2.DescriptionText = "Por favor aguarde enquanto as tarefas são executadas";
            this.wizardPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(841, 422);
            this.wizardPage2.Text = "Atualização em andamento";
            // 
            // richLog
            // 
            this.richLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richLog.Location = new System.Drawing.Point(0, 89);
            this.richLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richLog.Name = "richLog";
            this.richLog.Size = new System.Drawing.Size(841, 333);
            this.richLog.TabIndex = 5;
            this.richLog.Text = "";
            this.richLog.TextChanged += new System.EventHandler(this.richLog_TextChanged);
            // 
            // lblPercent
            // 
            this.lblPercent.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblPercent.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.lblPercent.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.lblPercent.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblPercent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblPercent.Location = new System.Drawing.Point(395, 18);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(19, 16);
            this.lblPercent.TabIndex = 4;
            this.lblPercent.Text = "0%";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // openFileZip
            // 
            this.openFileZip.Filter = "Zip Files | *.zip";
            // 
            // XFrmClientUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 596);
            this.Controls.Add(this.wizardControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "XFrmClientUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updater ITE Solution";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XFrmUpdateITE_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSql)).EndInit();
            this.pnlSql.ResumeLayout(false);
            this.pnlSql.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAutenticacao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstallDir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rChListTask)).EndInit();
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
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSelecionar;
        private DevExpress.XtraEditors.TextEdit txtInstallDir;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private System.Windows.Forms.RichTextBox richLog;
        private DevExpress.XtraEditors.LabelControl lblPercent;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.CheckEdit chExibirArquivo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileZip;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.FolderBrowserDialog folderInstallDir;
        private DevExpress.XtraEditors.CheckedListBoxControl rChListTask;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl pnlSql;
        private DevExpress.XtraEditors.LabelControl lbPwd;
        private DevExpress.XtraEditors.LabelControl lbUsr;
        private DevExpress.XtraEditors.TextEdit txtPwd;
        private DevExpress.XtraEditors.TextEdit txtUsr;
        private DevExpress.XtraEditors.CheckEdit chAutenticacao;
        private DevExpress.XtraEditors.SimpleButton btnConectar;
        private DevExpress.XtraEditors.TextEdit txtServerName;
        private DevExpress.XtraEditors.LabelControl lblDatabase;
        private DevExpress.XtraEditors.ComboBoxEdit cbDatabase;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}