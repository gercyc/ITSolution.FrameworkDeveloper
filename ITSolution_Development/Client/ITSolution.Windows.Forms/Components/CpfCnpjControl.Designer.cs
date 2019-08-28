namespace ITSolution.Framework.Components
{
    partial class CpfCnpjControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CpfCnpjControl));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.maskedTxtCpfCnpj = new System.Windows.Forms.MaskedTextBox();
            this.lbCpfCnpj = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblFlagCnpj = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.chValidacaoOnline = new DevExpress.XtraEditors.CheckEdit();
            this.lblValidacaoRFB = new DevExpress.XtraEditors.LabelControl();
            this.lblFlagValidando = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chValidacaoOnline.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // maskedTxtCpfCnpj
            // 
            this.maskedTxtCpfCnpj.Font = new System.Drawing.Font("Tahoma", 9F);
            this.maskedTxtCpfCnpj.Location = new System.Drawing.Point(7, 31);
            this.maskedTxtCpfCnpj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTxtCpfCnpj.Mask = "00\\.000\\.000\\.0000-00";
            this.maskedTxtCpfCnpj.Name = "maskedTxtCpfCnpj";
            this.maskedTxtCpfCnpj.Size = new System.Drawing.Size(147, 22);
            this.maskedTxtCpfCnpj.TabIndex = 14;
            this.maskedTxtCpfCnpj.MaskChanged += new System.EventHandler(this.maskedTxtCpfCnpj_MaskChanged);
            this.maskedTxtCpfCnpj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTxtCpfCnpj_KeyDown);
            // 
            // lbCpfCnpj
            // 
            this.lbCpfCnpj.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lbCpfCnpj.Location = new System.Drawing.Point(7, 9);
            this.lbCpfCnpj.Name = "lbCpfCnpj";
            this.lbCpfCnpj.Size = new System.Drawing.Size(56, 14);
            this.lbCpfCnpj.TabIndex = 0;
            this.lbCpfCnpj.Text = "CPF/CNPJ:";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lblFlagCnpj);
            this.panelControl1.Controls.Add(this.labelControl13);
            this.panelControl1.Controls.Add(this.chValidacaoOnline);
            this.panelControl1.Location = new System.Drawing.Point(68, 7);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(141, 19);
            this.panelControl1.TabIndex = 80;
            // 
            // lblFlagCnpj
            // 
            this.lblFlagCnpj.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFlagCnpj.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblFlagCnpj.Appearance.Image")));
            this.lblFlagCnpj.Location = new System.Drawing.Point(121, 2);
            this.lblFlagCnpj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblFlagCnpj.Name = "lblFlagCnpj";
            this.lblFlagCnpj.Size = new System.Drawing.Size(16, 16);
            this.lblFlagCnpj.TabIndex = 2;
            this.lblFlagCnpj.Visible = false;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl13.Appearance.Image")));
            this.labelControl13.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelControl13.Location = new System.Drawing.Point(17, 3);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(99, 16);
            this.labelControl13.TabIndex = 1;
            this.labelControl13.Text = " Validação Online      ";
            // 
            // chValidacaoOnline
            // 
            this.chValidacaoOnline.Dock = System.Windows.Forms.DockStyle.Left;
            this.chValidacaoOnline.EditValue = true;
            this.chValidacaoOnline.Location = new System.Drawing.Point(0, 0);
            this.chValidacaoOnline.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chValidacaoOnline.Name = "chValidacaoOnline";
            this.chValidacaoOnline.Properties.Caption = "";
            this.chValidacaoOnline.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chValidacaoOnline.Size = new System.Drawing.Size(15, 19);
            this.chValidacaoOnline.TabIndex = 8;
            this.chValidacaoOnline.CheckedChanged += new System.EventHandler(this.chValidacaoOnline_CheckedChanged);
            // 
            // lblValidacaoRFB
            // 
            this.lblValidacaoRFB.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblValidacaoRFB.Appearance.Image = global::ITSolution.Framework.Properties.Resources.rfb32x32;
            this.lblValidacaoRFB.Location = new System.Drawing.Point(159, 28);
            this.lblValidacaoRFB.Name = "lblValidacaoRFB";
            this.lblValidacaoRFB.Size = new System.Drawing.Size(32, 32);
            toolTipTitleItem1.Text = "Receita Federal Brasileira";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Todas as informações fornecidas são da base da RFB";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.lblValidacaoRFB.SuperTip = superToolTip1;
            this.lblValidacaoRFB.TabIndex = 81;
            this.lblValidacaoRFB.Click += new System.EventHandler(this.lblValidacaoRFB_Click);
            // 
            // lblFlagValidando
            // 
            this.lblFlagValidando.Appearance.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.lblFlagValidando.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblFlagValidando.Location = new System.Drawing.Point(7, 52);
            this.lblFlagValidando.Name = "lblFlagValidando";
            this.lblFlagValidando.Size = new System.Drawing.Size(61, 11);
            this.lblFlagValidando.TabIndex = 82;
            this.lblFlagValidando.Text = "Validando ...";
            this.lblFlagValidando.Visible = false;
            // 
            // CpfCnpjControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFlagValidando);
            this.Controls.Add(this.lblValidacaoRFB);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.maskedTxtCpfCnpj);
            this.Controls.Add(this.lbCpfCnpj);
            this.Name = "CpfCnpjControl";
            this.Size = new System.Drawing.Size(212, 64);
            this.Load += new System.EventHandler(this.CNPJControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chValidacaoOnline.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTxtCpfCnpj;
        private DevExpress.XtraEditors.LabelControl lbCpfCnpj;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.CheckEdit chValidacaoOnline;
        private DevExpress.XtraEditors.LabelControl lblFlagCnpj;
        private DevExpress.XtraEditors.LabelControl lblValidacaoRFB;
        private DevExpress.XtraEditors.LabelControl lblFlagValidando;
    }
}
