namespace ITSolution.Framework.Components
{
    partial class PanelSum
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblMedia = new DevExpress.XtraEditors.LabelControl();

            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblContagem = new DevExpress.XtraEditors.LabelControl();

            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblSoma = new DevExpress.XtraEditors.LabelControl();
            this.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Location = new System.Drawing.Point(0, 104);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            //this.Name = "panelControl1";
            this.Size = new System.Drawing.Size(752, 35);
            this.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl1.Location = new System.Drawing.Point(469, 2);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.labelControl1.Size = new System.Drawing.Size(32, 21);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Média:";
            // 
            // lblMedia
            // 
            this.lblMedia.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMedia.Location = new System.Drawing.Point(501, 2);
            this.lblMedia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Padding = new System.Windows.Forms.Padding(4, 8, 34, 0);
            this.lblMedia.Size = new System.Drawing.Size(54, 21);
            this.lblMedia.TabIndex = 4;
            this.lblMedia.Text = "0,0";
            // 
            // labelControl2
            // 
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl2.Location = new System.Drawing.Point(555, 2);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(0, 8, 9, 0);
            this.labelControl2.Size = new System.Drawing.Size(62, 21);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Contagem:";
            // 
            // lblContagem
            // 
            this.lblContagem.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblContagem.Location = new System.Drawing.Point(617, 2);
            this.lblContagem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblContagem.Name = "lblContagem";
            this.lblContagem.Padding = new System.Windows.Forms.Padding(0, 8, 34, 0);
            this.lblContagem.Size = new System.Drawing.Size(40, 21);
            this.lblContagem.TabIndex = 2;
            this.lblContagem.Text = "0";
            // 
            // labelControl3
            // 
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl3.Location = new System.Drawing.Point(657, 2);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(0, 8, 4, 0);
            this.labelControl3.Size = new System.Drawing.Size(34, 21);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Soma:";
            // 
            // lblSoma
            // 
            this.lblSoma.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSoma.Location = new System.Drawing.Point(691, 2);
            this.lblSoma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSoma.Name = "lblSoma";
            this.lblSoma.Padding = new System.Windows.Forms.Padding(0, 8, 43, 0);
            this.lblSoma.Size = new System.Drawing.Size(59, 21);
            this.lblSoma.TabIndex = 0;
            this.lblSoma.Text = "0,0";

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblMedia;
        private DevExpress.XtraEditors.LabelControl lblContagem;
        private DevExpress.XtraEditors.LabelControl lblSoma;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}