namespace ITSolution.Framework.Forms
{
    partial class XFrmRestoreBackupSql
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmRestoreBackupSql));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.cbDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDatabase = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSelecionar = new DevExpress.XtraEditors.SimpleButton();
            this.txtPathBackup = new DevExpress.XtraEditors.TextEdit();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.lblMsg = new DevExpress.XtraEditors.LabelControl();
            this.lblPercent = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathBackup.Properties)).BeginInit();
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
            this.wizardControl1.MinimumSize = new System.Drawing.Size(86, 81);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "&Avançar >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.wizardPage2,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< &Voltar";
            this.wizardControl1.Size = new System.Drawing.Size(611, 424);
            this.wizardControl1.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_CancelClick);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.IntroductionText = "Este assistente irá guia-lo durante o processo de backup";
            this.welcomeWizardPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "Para continuar, clique em Avançar";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(394, 268);
            this.welcomeWizardPage1.Text = "Bem-vindo ao assistente de restauração de backup";
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
            this.wizardPage1.Size = new System.Drawing.Size(579, 279);
            this.wizardPage1.Text = "Informe o local de destino do backup";
            this.wizardPage1.PageValidating += new DevExpress.XtraWizard.WizardPageValidatingEventHandler(this.wizardPage1_PageValidating);
            this.wizardPage1.PageCommit += new System.EventHandler(this.wizardPage1_PageCommit);
            // 
            // cbDatabase
            // 
            this.cbDatabase.Location = new System.Drawing.Point(16, 43);
            this.cbDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.cbDatabase.Properties.Appearance.Options.UseFont = true;
            this.cbDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDatabase.Size = new System.Drawing.Size(307, 20);
            this.cbDatabase.TabIndex = 0;
            this.cbDatabase.SelectedIndexChanged += new System.EventHandler(this.cbDatabase_SelectedIndexChanged);
            // 
            // lblDatabase
            // 
            this.lblDatabase.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblDatabase.Location = new System.Drawing.Point(16, 25);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(80, 13);
            this.lblDatabase.TabIndex = 8;
            this.lblDatabase.Text = "Banco de dados:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.labelControl1.Location = new System.Drawing.Point(16, 89);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Arquivo de backup:";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionar.Image")));
            this.btnSelecionar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSelecionar.Location = new System.Drawing.Point(537, 105);
            this.btnSelecionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(33, 20);
            this.btnSelecionar.TabIndex = 6;
            this.btnSelecionar.Text = "...";
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // txtPathBackup
            // 
            this.txtPathBackup.Location = new System.Drawing.Point(16, 106);
            this.txtPathBackup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPathBackup.Name = "txtPathBackup";
            this.txtPathBackup.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtPathBackup.Properties.Appearance.Options.UseFont = true;
            this.txtPathBackup.Size = new System.Drawing.Size(503, 20);
            this.txtPathBackup.TabIndex = 1;
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.FinishText = "Backup restaurado com sucesso !";
            this.completionWizardPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "Para fechar, clique em \"Terminar\"";
            this.completionWizardPage1.Size = new System.Drawing.Size(394, 268);
            this.completionWizardPage1.Text = "Finalizando o assistente de restauração backup.";
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.lblMsg);
            this.wizardPage2.Controls.Add(this.lblPercent);
            this.wizardPage2.Controls.Add(this.progressBarControl1);
            this.wizardPage2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.wizardPage2.DescriptionText = "Por favor aguarde o processo de restauração da base dados";
            this.wizardPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(579, 279);
            this.wizardPage2.Text = "Restaurando backup";
            // 
            // lblMsg
            // 
            this.lblMsg.Location = new System.Drawing.Point(43, 93);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 2;
            // 
            // lblPercent
            // 
            this.lblPercent.Location = new System.Drawing.Point(269, 148);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(17, 13);
            this.lblPercent.TabIndex = 1;
            this.lblPercent.Text = "0%";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(43, 120);
            this.progressBarControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.progressBarControl1.Properties.Step = 1;
            this.progressBarControl1.Size = new System.Drawing.Size(493, 24);
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
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Backup | *.bak";
            // 
            // XFrmRestoreBackupSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 424);
            this.Controls.Add(this.wizardControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XFrmRestoreBackupSql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restauração da base dados";
            this.Load += new System.EventHandler(this.XFrmRestoreBackupSQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathBackup.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblDatabase;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.LabelControl lblPercent;
        private DevExpress.XtraEditors.LabelControl lblMsg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.ComboBoxEdit cbDatabase;
    }
}