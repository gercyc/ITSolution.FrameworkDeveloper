namespace ITSolution.Reports.Forms.View
{
    partial class XFrmAddReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmAddReport));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbGrupoRelatorio = new DevExpress.XtraEditors.ComboBoxEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnCriarEstrutura = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnAlterarNome = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescricaoRelatorio = new DevExpress.XtraEditors.TextEdit();
            this.btnRefreshGroup = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbGrupoRelatorio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricaoRelatorio.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(29, 70);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Grupo:";
            // 
            // cbGrupoRelatorio
            // 
            this.cbGrupoRelatorio.Location = new System.Drawing.Point(29, 98);
            this.cbGrupoRelatorio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbGrupoRelatorio.Name = "cbGrupoRelatorio";
            this.cbGrupoRelatorio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbGrupoRelatorio.Properties.Appearance.Options.UseFont = true;
            this.cbGrupoRelatorio.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbGrupoRelatorio.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbGrupoRelatorio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGrupoRelatorio.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbGrupoRelatorio.Size = new System.Drawing.Size(299, 28);
            this.cbGrupoRelatorio.TabIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnCriarEstrutura,
            this.barBtnCancelar,
            this.barBtnAlterarNome});
            this.barManager1.MaxItemId = 3;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCriarEstrutura),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnAlterarNome),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnCancelar)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnCriarEstrutura
            // 
            this.btnCriarEstrutura.Caption = "Editar Relatório";
            this.btnCriarEstrutura.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCriarEstrutura.Glyph")));
            this.btnCriarEstrutura.Id = 0;
            this.btnCriarEstrutura.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCriarEstrutura.LargeGlyph")));
            this.btnCriarEstrutura.Name = "btnCriarEstrutura";
            this.btnCriarEstrutura.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnCriarEstrutura.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCriarEstrutura_ItemClick);
            // 
            // barBtnAlterarNome
            // 
            this.barBtnAlterarNome.Caption = "Salvar Alterações";
            this.barBtnAlterarNome.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnAlterarNome.Glyph")));
            this.barBtnAlterarNome.Id = 2;
            this.barBtnAlterarNome.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.barBtnAlterarNome.Name = "barBtnAlterarNome";
            this.barBtnAlterarNome.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnAlterarNome.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnAlterarNome_ItemClick);
            // 
            // barBtnCancelar
            // 
            this.barBtnCancelar.Caption = "Cancelar";
            this.barBtnCancelar.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnCancelar.Glyph")));
            this.barBtnCancelar.Id = 1;
            this.barBtnCancelar.Name = "barBtnCancelar";
            this.barBtnCancelar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnCancelar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCancelar_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(507, 57);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 266);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(507, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 57);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 209);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(507, 57);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 209);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Location = new System.Drawing.Point(29, 161);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(168, 21);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Descrição do Relatório";
            // 
            // txtDescricaoRelatorio
            // 
            this.txtDescricaoRelatorio.Location = new System.Drawing.Point(29, 190);
            this.txtDescricaoRelatorio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescricaoRelatorio.Name = "txtDescricaoRelatorio";
            this.txtDescricaoRelatorio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDescricaoRelatorio.Properties.Appearance.Options.UseFont = true;
            this.txtDescricaoRelatorio.Size = new System.Drawing.Size(374, 28);
            this.txtDescricaoRelatorio.TabIndex = 1;
            this.txtDescricaoRelatorio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescricaoRelatorio_KeyDown);
            // 
            // btnRefreshGroup
            // 
            this.btnRefreshGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshGroup.Image")));
            this.btnRefreshGroup.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRefreshGroup.Location = new System.Drawing.Point(299, 68);
            this.btnRefreshGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefreshGroup.Name = "btnRefreshGroup";
            this.btnRefreshGroup.Size = new System.Drawing.Size(29, 25);
            this.btnRefreshGroup.TabIndex = 14;
            this.btnRefreshGroup.Text = "Atualizar Grupos";
            this.btnRefreshGroup.Click += new System.EventHandler(this.btnRefreshGroup_Click);
            // 
            // XFrmAddReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 288);
            this.ControlBox = false;
            this.Controls.Add(this.btnRefreshGroup);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtDescricaoRelatorio);
            this.Controls.Add(this.cbGrupoRelatorio);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "XFrmAddReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criação Relatório";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XFrmAddReport_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.cbGrupoRelatorio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricaoRelatorio.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cbGrupoRelatorio;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnCriarEstrutura;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDescricaoRelatorio;
        private DevExpress.XtraBars.BarButtonItem barBtnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnRefreshGroup;
        private DevExpress.XtraBars.BarButtonItem barBtnAlterarNome;
    }
}