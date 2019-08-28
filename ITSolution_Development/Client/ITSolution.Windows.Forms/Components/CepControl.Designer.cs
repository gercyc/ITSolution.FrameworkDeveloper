namespace ITSolution.Framework.Components
{
    partial class CepControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CepControl));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblFlagCep = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.chValidacaoOnline = new DevExpress.XtraEditors.CheckEdit();
            this.txtCep = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chValidacaoOnline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCep.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.lblFlagCep);
            this.panelControl1.Controls.Add(this.labelControl13);
            this.panelControl1.Controls.Add(this.chValidacaoOnline);
            this.panelControl1.Location = new System.Drawing.Point(31, 10);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(164, 23);
            this.panelControl1.TabIndex = 79;
            // 
            // lblFlagCep
            // 
            this.lblFlagCep.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFlagCep.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblFlagCep.Appearance.Image")));
            this.lblFlagCep.Location = new System.Drawing.Point(139, 1);
            this.lblFlagCep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblFlagCep.Name = "lblFlagCep";
            this.lblFlagCep.Size = new System.Drawing.Size(16, 21);
            this.lblFlagCep.TabIndex = 17;
            this.lblFlagCep.Visible = false;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl13.Appearance.Image")));
            this.labelControl13.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelControl13.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labelControl13.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl13.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightTop;
            this.labelControl13.Location = new System.Drawing.Point(19, 2);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(114, 20);
            this.labelControl13.TabIndex = 16;
            this.labelControl13.Text = "Validação online";
            // 
            // chValidacaoOnline
            // 
            this.chValidacaoOnline.Dock = System.Windows.Forms.DockStyle.Left;
            this.chValidacaoOnline.EditValue = true;
            this.chValidacaoOnline.Location = new System.Drawing.Point(2, 2);
            this.chValidacaoOnline.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chValidacaoOnline.Name = "chValidacaoOnline";
            this.chValidacaoOnline.Properties.Caption = "";
            this.chValidacaoOnline.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chValidacaoOnline.Size = new System.Drawing.Size(17, 19);
            this.chValidacaoOnline.TabIndex = 8;
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(3, 36);
            this.txtCep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCep.Name = "txtCep";
            this.txtCep.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtCep.Properties.Appearance.Options.UseFont = true;
            this.txtCep.Properties.Mask.EditMask = "\\d\\d\\d\\d\\d-\\d\\d\\d";
            this.txtCep.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txtCep.Size = new System.Drawing.Size(195, 24);
            this.txtCep.TabIndex = 0;
            this.txtCep.EditValueChanged += new System.EventHandler(this.txtCep_EditValueChanged);
            this.txtCep.Enter += new System.EventHandler(this.txtCep_Enter);
            this.txtCep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCep_KeyDown);
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl17.Location = new System.Drawing.Point(3, 12);
            this.labelControl17.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(25, 18);
            this.labelControl17.TabIndex = 78;
            this.labelControl17.Text = "CEP";
            // 
            // CepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.txtCep);
            this.Controls.Add(this.labelControl17);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CepControl";
            this.Size = new System.Drawing.Size(201, 64);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chValidacaoOnline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCep.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chValidacaoOnline;
        private DevExpress.XtraEditors.TextEdit txtCep;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl lblFlagCep;
    }
}
