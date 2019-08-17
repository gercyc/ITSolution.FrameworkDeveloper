
using DevExpress.XtraEditors;

namespace ITSolution.Admin.Forms.ContextUtil
{
    partial class XFrmListViewDataBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmListViewDataBase));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetConnection = new DevExpress.XtraEditors.SimpleButton();
            this.lblDatabase = new DevExpress.XtraEditors.LabelControl();
            this.cbDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.Location = new System.Drawing.Point(178, 98);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 28);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSetConnection
            // 
            this.btnSetConnection.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSetConnection.Appearance.Options.UseFont = true;
            this.btnSetConnection.Image = ((System.Drawing.Image)(resources.GetObject("btnSetConnection.Image")));
            this.btnSetConnection.Location = new System.Drawing.Point(290, 98);
            this.btnSetConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetConnection.Name = "btnSetConnection";
            this.btnSetConnection.Size = new System.Drawing.Size(90, 28);
            this.btnSetConnection.TabIndex = 2;
            this.btnSetConnection.Text = "OK";
            this.btnSetConnection.ToolTip = "Pressionar CTRL + Enter para alterar o arquivo fisicamente";
            this.btnSetConnection.Click += new System.EventHandler(this.btnSetDatabase_Click);
            // 
            // lblDatabase
            // 
            this.lblDatabase.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDatabase.Location = new System.Drawing.Point(26, 23);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(110, 18);
            this.lblDatabase.TabIndex = 4;
            this.lblDatabase.Text = "Banco de dados:";
            // 
            // cbDatabase
            // 
            this.cbDatabase.Location = new System.Drawing.Point(26, 49);
            this.cbDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbDatabase.Properties.Appearance.Options.UseFont = true;
            this.cbDatabase.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbDatabase.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDatabase.Size = new System.Drawing.Size(358, 24);
            this.cbDatabase.TabIndex = 5;
            // 
            // XFrmListViewDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 155);
            this.Controls.Add(this.cbDatabase);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.btnSetConnection);
            this.Controls.Add(this.btnCancelar);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "XFrmListViewDataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar database:";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XFrmListViewDataBase_FormClosing);
            this.Load += new System.EventHandler(this.XFrmListViewDataBase_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XFrmListViewDataBase_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.cbDatabase.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnSetConnection;
        private DevExpress.XtraEditors.LabelControl lblDatabase;
        private ComboBoxEdit cbDatabase;
    }
}