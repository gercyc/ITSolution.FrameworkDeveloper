namespace ITSolution.Framework.Mensagem
{
    partial class MessageBoxException
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtException = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.txtInner = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.txtStack = new DevExpress.XtraEditors.MemoEdit();
            this.lblMsg = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtException.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInner.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStack.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.xtraTabControl1.Appearance.Options.UseFont = true;
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 48);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(636, 304);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtException);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(629, 270);
            this.xtraTabPage1.Text = "Exceção";
            // 
            // txtException
            // 
            this.txtException.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtException.Location = new System.Drawing.Point(0, 0);
            this.txtException.Name = "txtException";
            this.txtException.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtException.Properties.Appearance.Options.UseFont = true;
            this.txtException.Size = new System.Drawing.Size(629, 270);
            this.txtException.TabIndex = 6;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.txtInner);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(629, 270);
            this.xtraTabPage2.Text = "Exceção Interna";
            // 
            // txtInner
            // 
            this.txtInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInner.Location = new System.Drawing.Point(0, 0);
            this.txtInner.Name = "txtInner";
            this.txtInner.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtInner.Properties.Appearance.Options.UseFont = true;
            this.txtInner.Size = new System.Drawing.Size(629, 270);
            this.txtInner.TabIndex = 7;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.txtStack);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(629, 270);
            this.xtraTabPage3.Text = "Pilha de Erros";
            // 
            // txtStack
            // 
            this.txtStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStack.Location = new System.Drawing.Point(0, 0);
            this.txtStack.Name = "txtStack";
            this.txtStack.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtStack.Properties.Appearance.Options.UseFont = true;
            this.txtStack.Size = new System.Drawing.Size(629, 270);
            this.txtStack.TabIndex = 8;
            // 
            // lblMsg
            // 
            this.lblMsg.Location = new System.Drawing.Point(13, 12);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(75, 16);
            this.lblMsg.TabIndex = 5;
            this.lblMsg.Text = "%message%";
            this.lblMsg.TextChanged += new System.EventHandler(this.lblMsg_TextChanged);
            // 
            // MessageBoxException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 364);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.xtraTabControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBoxException";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detecção de Erros";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtException.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInner.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtStack.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.LabelControl lblMsg;
        private DevExpress.XtraEditors.MemoEdit txtException;
        private DevExpress.XtraEditors.MemoEdit txtInner;
        private DevExpress.XtraEditors.MemoEdit txtStack;
    }
}