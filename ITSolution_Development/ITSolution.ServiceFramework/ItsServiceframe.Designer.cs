namespace ITSolution.ServiceFramework
{
    partial class ItsServiceframe
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
            this.btnStartReports = new DevExpress.XtraEditors.ButtonEdit();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnStarScheduler = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnStartReports.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStarScheduler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartReports
            // 
            this.btnStartReports.EditValue = "Inicializar ReportServer";
            this.btnStartReports.Location = new System.Drawing.Point(12, 26);
            this.btnStartReports.Name = "btnStartReports";
            this.btnStartReports.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnStartReports.Properties.ReadOnly = true;
            this.btnStartReports.Size = new System.Drawing.Size(224, 20);
            this.btnStartReports.TabIndex = 1;
            this.btnStartReports.Click += new System.EventHandler(this.btnStartSvc1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // btnStarScheduler
            // 
            this.btnStarScheduler.EditValue = "Inicializar Scheduler";
            this.btnStarScheduler.Location = new System.Drawing.Point(12, 71);
            this.btnStarScheduler.Name = "btnStarScheduler";
            this.btnStarScheduler.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnStarScheduler.Properties.ReadOnly = true;
            this.btnStarScheduler.Size = new System.Drawing.Size(224, 20);
            this.btnStarScheduler.TabIndex = 2;
            this.btnStarScheduler.Click += new System.EventHandler(this.btnStarScheduler_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(98, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Serviço de relatórios";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Serviço de Jobs";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 99);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(110, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Serviço de Movimentos";
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.EditValue = "Inicializar Movimento";
            this.buttonEdit1.Location = new System.Drawing.Point(12, 118);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Properties.ReadOnly = true;
            this.buttonEdit1.Size = new System.Drawing.Size(224, 20);
            this.buttonEdit1.TabIndex = 5;
            this.buttonEdit1.Click += new System.EventHandler(this.buttonEdit1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "StartServices";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ItsServiceframe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 333);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.buttonEdit1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnStarScheduler);
            this.Controls.Add(this.btnStartReports);
            this.Name = "ItsServiceframe";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.btnStartReports.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStarScheduler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.ButtonEdit btnStartReports;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private DevExpress.XtraEditors.ButtonEdit btnStarScheduler;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private System.Windows.Forms.Button button1;
    }
}

