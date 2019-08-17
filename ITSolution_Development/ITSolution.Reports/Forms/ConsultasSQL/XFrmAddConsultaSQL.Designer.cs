namespace ITSolution.Reports.Forms.ConsultasSQL
{
    partial class XFrmAddConsultaSQL
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodQuery = new DevExpress.XtraEditors.TextEdit();
            this.txtNomeQuery = new DevExpress.XtraEditors.TextEdit();
            this.memCorpoQuery = new DevExpress.XtraEditors.MemoEdit();
            this.btnSalvar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodQuery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeQuery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memCorpoQuery.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(14, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Código";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(162, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Descrição";
            // 
            // txtCodQuery
            // 
            this.txtCodQuery.Location = new System.Drawing.Point(14, 31);
            this.txtCodQuery.Name = "txtCodQuery";
            this.txtCodQuery.Size = new System.Drawing.Size(117, 20);
            this.txtCodQuery.TabIndex = 2;
            // 
            // txtNomeQuery
            // 
            this.txtNomeQuery.Location = new System.Drawing.Point(162, 31);
            this.txtNomeQuery.Name = "txtNomeQuery";
            this.txtNomeQuery.Size = new System.Drawing.Size(516, 20);
            this.txtNomeQuery.TabIndex = 3;
            // 
            // memCorpoQuery
            // 
            this.memCorpoQuery.Location = new System.Drawing.Point(14, 74);
            this.memCorpoQuery.Name = "memCorpoQuery";
            this.memCorpoQuery.Size = new System.Drawing.Size(664, 292);
            this.memCorpoQuery.TabIndex = 4;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(590, 382);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(87, 23);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(496, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(14, 57);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(57, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Script SQL";
            // 
            // XFrmAddConsultaSQL
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 417);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.memCorpoQuery);
            this.Controls.Add(this.txtNomeQuery);
            this.Controls.Add(this.txtCodQuery);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Name = "XFrmAddConsultaSQL";
            this.Text = "Nova consulta SQL*";
            ((System.ComponentModel.ISupportInitialize)(this.txtCodQuery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeQuery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memCorpoQuery.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCodQuery;
        private DevExpress.XtraEditors.TextEdit txtNomeQuery;
        private DevExpress.XtraEditors.MemoEdit memCorpoQuery;
        private DevExpress.XtraEditors.SimpleButton btnSalvar;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}