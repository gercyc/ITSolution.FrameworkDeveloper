using DevExpress.XtraEditors;

namespace ITSolution.Framework.Beans.Forms
{
    partial class XFrmOptionPane
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInput = new DevExpress.XtraEditors.TextEdit();
            this.lblMsg = new DevExpress.XtraEditors.LabelControl();
            this.panelImg = new System.Windows.Forms.Panel();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rTextBoxArea = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.panelImg);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 281);
            this.panel1.TabIndex = 6;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(76, 44);
            this.txtInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInput.Name = "txtInput";
            this.txtInput.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtInput.Properties.Appearance.Options.UseFont = true;
            this.txtInput.Size = new System.Drawing.Size(519, 22);
            this.txtInput.TabIndex = 8;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // lblMsg
            // 
            this.lblMsg.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblMsg.Location = new System.Drawing.Point(76, 24);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(180, 16);
            this.lblMsg.TabIndex = 9;
            this.lblMsg.Text = "Digite abaixo o texto de retorno";
            // 
            // panelImg
            // 
            this.panelImg.BackgroundImage = global::ITSolution.Framework.Properties.Resources.index_32x32;
            this.panelImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelImg.Location = new System.Drawing.Point(9, 20);
            this.panelImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelImg.Name = "panelImg";
            this.panelImg.Size = new System.Drawing.Size(63, 46);
            this.panelImg.TabIndex = 10;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(531, 80);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(64, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(453, 80);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(64, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            this.btnOk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rTextBoxArea);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 281);
            this.panel2.TabIndex = 11;
            // 
            // rTextBoxArea
            // 
            this.rTextBoxArea.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rTextBoxArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTextBoxArea.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rTextBoxArea.Location = new System.Drawing.Point(0, 0);
            this.rTextBoxArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rTextBoxArea.Name = "rTextBoxArea";
            this.rTextBoxArea.ReadOnly = true;
            this.rTextBoxArea.Size = new System.Drawing.Size(615, 281);
            this.rTextBoxArea.TabIndex = 1;
            this.rTextBoxArea.Text = "";
            // 
            // XFrmOptionPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 281);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XFrmOptionPane";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Texto de entrada:";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XFrmOptionPane_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelImg;
        private DevExpress.XtraEditors.LabelControl lblMsg;
        private DevExpress.XtraEditors.TextEdit txtInput;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rTextBoxArea;
    }
}