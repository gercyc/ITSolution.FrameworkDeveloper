namespace ITSolution.Framework.Forms
{
    partial class XFrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmLogin));
            this.timer1 = new System.Windows.Forms.Timer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblData = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblHrs = new DevExpress.XtraEditors.LabelControl();
            this.panelControlLogin = new DevExpress.XtraEditors.PanelControl();
            this.chLembrarMe = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.lblLogin = new DevExpress.XtraEditors.LabelControl();
            this.btnLogar = new DevExpress.XtraEditors.SimpleButton();
            this.lblSenha = new DevExpress.XtraEditors.LabelControl();
            this.btnActionBtn = new DevExpress.XtraEditors.SimpleButton();
            this.txtSenha = new DevExpress.XtraEditors.TextEdit();
            this.txtNome = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLogin)).BeginInit();
            this.panelControlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chLembrarMe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNome.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseImage = true;
            this.panelControl1.AutoSize = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.panelLogo);
            this.panelControl1.Controls.Add(this.lblData);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.lblHrs);
            this.panelControl1.Controls.Add(this.panelControlLogin);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 601);
            this.panelControl1.TabIndex = 9;
            this.panelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseDown);
            this.panelControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseMove);
            this.panelControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseUp);
            // 
            // panelLogo
            // 
            this.panelLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLogo.BackColor = System.Drawing.Color.Transparent;
            this.panelLogo.Controls.Add(this.pictureEdit1);
            this.panelLogo.Controls.Add(this.labelControl1);
            this.panelLogo.Location = new System.Drawing.Point(588, 526);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(199, 43);
            this.panelLogo.TabIndex = 12;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureEdit1.EditValue = global::ITSolution.Framework.Properties.Resources.itsolution;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(41, 43);
            this.pictureEdit1.TabIndex = 10;
            this.pictureEdit1.ToolTip = "Clique aqui para altera imagem de plano de fundo";
            this.pictureEdit1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.labelControl1.Location = new System.Drawing.Point(48, 7);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 24);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "IT Solution";
            // 
            // lblData
            // 
            this.lblData.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblData.Appearance.Font = new System.Drawing.Font("Tahoma", 22F);
            this.lblData.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.lblData.Location = new System.Drawing.Point(26, 486);
            this.lblData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(410, 45);
            this.lblData.TabIndex = 7;
            this.lblData.Text = "Nome do Dia, dia do Mes";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.labelControl3.Location = new System.Drawing.Point(589, 572);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(199, 16);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Sistema de Gestão Empresarial";
            // 
            // lblHrs
            // 
            this.lblHrs.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblHrs.Appearance.Font = new System.Drawing.Font("Tahoma", 42F);
            this.lblHrs.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.lblHrs.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblHrs.Location = new System.Drawing.Point(26, 398);
            this.lblHrs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblHrs.Name = "lblHrs";
            this.lblHrs.Size = new System.Drawing.Size(178, 84);
            this.lblHrs.TabIndex = 6;
            this.lblHrs.Text = "Horas";
            // 
            // panelControlLogin
            // 
            this.panelControlLogin.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControlLogin.Appearance.Options.UseBackColor = true;
            this.panelControlLogin.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlLogin.Controls.Add(this.chLembrarMe);
            this.panelControlLogin.Controls.Add(this.btnCancelar);
            this.panelControlLogin.Controls.Add(this.lblLogin);
            this.panelControlLogin.Controls.Add(this.btnLogar);
            this.panelControlLogin.Controls.Add(this.lblSenha);
            this.panelControlLogin.Controls.Add(this.btnActionBtn);
            this.panelControlLogin.Controls.Add(this.txtSenha);
            this.panelControlLogin.Controls.Add(this.txtNome);
            this.panelControlLogin.Location = new System.Drawing.Point(199, 134);
            this.panelControlLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControlLogin.Name = "panelControlLogin";
            this.panelControlLogin.Size = new System.Drawing.Size(421, 220);
            this.panelControlLogin.TabIndex = 9;
            // 
            // chLembrarMe
            // 
            this.chLembrarMe.Location = new System.Drawing.Point(28, 165);
            this.chLembrarMe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chLembrarMe.Name = "chLembrarMe";
            this.chLembrarMe.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chLembrarMe.Properties.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.chLembrarMe.Properties.Appearance.Options.UseFont = true;
            this.chLembrarMe.Properties.Appearance.Options.UseForeColor = true;
            this.chLembrarMe.Properties.Caption = "Lembrar-me";
            this.chLembrarMe.Size = new System.Drawing.Size(113, 22);
            this.chLembrarMe.TabIndex = 7;
            this.chLembrarMe.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnCancelar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.Appearance.Options.UseForeColor = true;
            this.btnCancelar.Location = new System.Drawing.Point(168, 161);
            this.btnCancelar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnCancelar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblLogin.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.lblLogin.Location = new System.Drawing.Point(28, 26);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(45, 18);
            this.lblLogin.TabIndex = 4;
            this.lblLogin.Text = "Logon";
            // 
            // btnLogar
            // 
            this.btnLogar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLogar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnLogar.Appearance.Options.UseFont = true;
            this.btnLogar.Appearance.Options.UseForeColor = true;
            this.btnLogar.Location = new System.Drawing.Point(285, 161);
            this.btnLogar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnLogar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLogar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(100, 30);
            this.btnLogar.TabIndex = 2;
            this.btnLogar.Text = "Logar";
            this.btnLogar.Click += new System.EventHandler(this.btnLogar_Click);
            // 
            // lblSenha
            // 
            this.lblSenha.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSenha.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.lblSenha.Location = new System.Drawing.Point(27, 89);
            this.lblSenha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(46, 18);
            this.lblSenha.TabIndex = 5;
            this.lblSenha.Text = "Senha";
            // 
            // btnActionBtn
            // 
            this.btnActionBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnActionBtn.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnActionBtn.Appearance.Options.UseFont = true;
            this.btnActionBtn.Appearance.Options.UseForeColor = true;
            this.btnActionBtn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnActionBtn.Location = new System.Drawing.Point(265, 14);
            this.btnActionBtn.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnActionBtn.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnActionBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActionBtn.Name = "btnActionBtn";
            this.btnActionBtn.Size = new System.Drawing.Size(120, 30);
            this.btnActionBtn.TabIndex = 4;
            this.btnActionBtn.Text = "Cadastrar";
            this.btnActionBtn.Visible = false;
            this.btnActionBtn.Click += new System.EventHandler(this.btnActionBtn_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(27, 118);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Properties.Appearance.Options.UseFont = true;
            this.txtSenha.Properties.PasswordChar = '•';
            this.txtSenha.Size = new System.Drawing.Size(358, 28);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyDown);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(27, 53);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Properties.Appearance.Options.UseFont = true;
            this.txtNome.Size = new System.Drawing.Size(358, 28);
            this.txtNome.TabIndex = 0;
            this.txtNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyDown);
            // 
            // XFrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 601);
            this.Controls.Add(this.panelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XFrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login:";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XFrmLogin_FormClosing);
            this.Load += new System.EventHandler(this.XFrmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XFrmLogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLogin)).EndInit();
            this.panelControlLogin.ResumeLayout(false);
            this.panelControlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chLembrarMe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNome.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblData;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblHrs;
        private DevExpress.XtraEditors.SimpleButton btnActionBtn;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.TextEdit txtNome;
        private DevExpress.XtraEditors.TextEdit txtSenha;
        private DevExpress.XtraEditors.LabelControl lblSenha;
        private DevExpress.XtraEditors.SimpleButton btnLogar;
        private DevExpress.XtraEditors.LabelControl lblLogin;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.PanelControl panelControlLogin;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panelLogo;
        private DevExpress.XtraEditors.CheckEdit chLembrarMe;
    }
}