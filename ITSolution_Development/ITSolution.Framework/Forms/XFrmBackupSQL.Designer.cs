namespace ITSolution.Framework.Forms
{
    partial class XFrmBackupSql
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmBackupSql));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.cbDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDatabase = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSelecionar = new DevExpress.XtraEditors.SimpleButton();
            this.txtPathBackup = new DevExpress.XtraEditors.TextEdit();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.chExibirArquivo = new DevExpress.XtraEditors.CheckEdit();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.lblMsg = new DevExpress.XtraEditors.LabelControl();
            this.lblPercent = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathBackup.Properties)).BeginInit();
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
            this.wizardControl1.FinishText = "&Terminar";
            this.wizardControl1.HelpText = "&Ajuda";
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "&Avançar >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.wizardPage2,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< &Voltar";
            this.wizardControl1.Size = new System.Drawing.Size(713, 522);
            this.wizardControl1.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_CancelClick);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.IntroductionText = "Este assistente irá guia-lo durante o processo de backup";
            this.welcomeWizardPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "Para continuar, clique em Avançar";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(496, 372);
            this.welcomeWizardPage1.Text = "Bem-vindo ao assistente de backup";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.cbDatabase);
            this.wizardPage1.Controls.Add(this.lblDatabase);
            this.wizardPage1.Controls.Add(this.labelControl1);
            this.wizardPage1.Controls.Add(this.btnSelecionar);
            this.wizardPage1.Controls.Add(this.txtPathBackup);
            this.wizardPage1.DescriptionText = "Observação: Procure selecionar mídias removíveis. Não utilize o disco C: ou mesmo" +
    " \"Área de trabalho\"";
            this.wizardPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(681, 348);
            this.wizardPage1.Text = "Informe o local de destino do backup";
            this.wizardPage1.PageValidating += new DevExpress.XtraWizard.WizardPageValidatingEventHandler(this.wizardPage1_PageValidating);
            this.wizardPage1.PageCommit += new System.EventHandler(this.wizardPage1_PageCommit);
            // 
            // cbDatabase
            // 
            this.cbDatabase.Location = new System.Drawing.Point(19, 53);
            this.cbDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.cbDatabase.Properties.Appearance.Options.UseFont = true;
            this.cbDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDatabase.Size = new System.Drawing.Size(358, 22);
            this.cbDatabase.TabIndex = 9;
            this.cbDatabase.SelectedIndexChanged += new System.EventHandler(this.cbDatabase_SelectedIndexChanged);
            // 
            // lblDatabase
            // 
            this.lblDatabase.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblDatabase.Location = new System.Drawing.Point(19, 31);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(95, 16);
            this.lblDatabase.TabIndex = 8;
            this.lblDatabase.Text = "Banco de dados:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelControl1.Location = new System.Drawing.Point(19, 110);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(119, 16);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Backup para o disco:";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionar.Image")));
            this.btnSelecionar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSelecionar.Location = new System.Drawing.Point(626, 129);
            this.btnSelecionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(38, 25);
            this.btnSelecionar.TabIndex = 6;
            this.btnSelecionar.Text = "...";
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // txtPathBackup
            // 
            this.txtPathBackup.Location = new System.Drawing.Point(19, 130);
            this.txtPathBackup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPathBackup.Name = "txtPathBackup";
            this.txtPathBackup.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtPathBackup.Properties.Appearance.Options.UseFont = true;
            this.txtPathBackup.Properties.ReadOnly = true;
            this.txtPathBackup.Size = new System.Drawing.Size(587, 22);
            this.txtPathBackup.TabIndex = 5;
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Controls.Add(this.chExibirArquivo);
            this.completionWizardPage1.FinishText = "Backup realizado com sucesso !";
            this.completionWizardPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "Para fechar, clique em \"Terminar\"";
            this.completionWizardPage1.Size = new System.Drawing.Size(496, 372);
            this.completionWizardPage1.Text = "Finalizando o assistente de backup";
            this.completionWizardPage1.PageValidating += new DevExpress.XtraWizard.WizardPageValidatingEventHandler(this.completionWizardPage1_PageValidating);
            // 
            // chExibirArquivo
            // 
            this.chExibirArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chExibirArquivo.Location = new System.Drawing.Point(316, 348);
            this.chExibirArquivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chExibirArquivo.Name = "chExibirArquivo";
            this.chExibirArquivo.Properties.Caption = "Exibir local do arquivo";
            this.chExibirArquivo.Size = new System.Drawing.Size(157, 20);
            this.chExibirArquivo.TabIndex = 1;
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.lblMsg);
            this.wizardPage2.Controls.Add(this.lblPercent);
            this.wizardPage2.Controls.Add(this.progressBarControl1);
            this.wizardPage2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.wizardPage2.DescriptionText = "Por favor aguarde o processo de backup da base de dados ";
            this.wizardPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(681, 348);
            this.wizardPage2.Text = "Realizando backup";
            // 
            // lblMsg
            // 
            this.lblMsg.Location = new System.Drawing.Point(50, 114);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 16);
            this.lblMsg.TabIndex = 2;
            // 
            // lblPercent
            // 
            this.lblPercent.Location = new System.Drawing.Point(314, 182);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(19, 16);
            this.lblPercent.TabIndex = 1;
            this.lblPercent.Text = "0%";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(50, 148);
            this.progressBarControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.progressBarControl1.Properties.Step = 1;
            this.progressBarControl1.Size = new System.Drawing.Size(575, 30);
            this.progressBarControl1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // XFrmBackupSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 522);
            this.Controls.Add(this.wizardControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XFrmBackupSql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup da base dados";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathBackup.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSelecionar;
        private DevExpress.XtraEditors.TextEdit txtPathBackup;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.ComboBoxEdit cbDatabase;
        private DevExpress.XtraEditors.LabelControl lblDatabase;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.LabelControl lblPercent;
        private DevExpress.XtraEditors.LabelControl lblMsg;
        private DevExpress.XtraEditors.CheckEdit chExibirArquivo;
    }
}