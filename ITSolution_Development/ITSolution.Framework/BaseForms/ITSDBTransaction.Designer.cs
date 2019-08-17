namespace ITSolution.Framework.BaseForms
{
    partial class ITSDBTransaction
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
            this.EFBindingNav = new ITSolution.Framework.BaseClasses.ThirdyPartyComponents.EntityBindingNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // EFBindingNav
            // 
            this.EFBindingNav.Location = new System.Drawing.Point(0, 0);
            this.EFBindingNav.Name = "EFBindingNav";
            this.EFBindingNav.Size = new System.Drawing.Size(523, 25);
            this.EFBindingNav.TabIndex = 1;
            this.EFBindingNav.Text = "efNav";
            // 
            // ITSDBTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 351);
            this.Controls.Add(this.EFBindingNav);
            this.Name = "ITSDBTransaction";
            this.Text = "ITSDBTransaction";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.EFBindingNav, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public BaseClasses.ThirdyPartyComponents.EntityBindingNavigator EFBindingNav;
    }
}