namespace ITSolution.Framework.Beans.Forms
{
    partial class XFrmPrinterText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmPrinterText));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSelecionaArquivo = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnVisualizarImpressao = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckEditarTextArea = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbImpressoras = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtImpressao = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbImpressoras.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barBtnImprimir,
            this.barBtnSelecionaArquivo,
            this.barBtnVisualizarImpressao,
            this.barCheckEditarTextArea});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(1012, 179);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barBtnImprimir
            // 
            this.barBtnImprimir.Caption = "Imprimir";
            this.barBtnImprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnImprimir.Glyph")));
            this.barBtnImprimir.Id = 1;
            this.barBtnImprimir.Name = "barBtnImprimir";
            this.barBtnImprimir.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnImprimir_ItemClick);
            // 
            // barBtnSelecionaArquivo
            // 
            this.barBtnSelecionaArquivo.Caption = "Abrir Arquivo";
            this.barBtnSelecionaArquivo.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSelecionaArquivo.Glyph")));
            this.barBtnSelecionaArquivo.Id = 2;
            this.barBtnSelecionaArquivo.Name = "barBtnSelecionaArquivo";
            this.barBtnSelecionaArquivo.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnSelecionaArquivo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSelecionaArquivo_ItemClick);
            // 
            // barBtnVisualizarImpressao
            // 
            this.barBtnVisualizarImpressao.Caption = "Visualizar Impressão";
            this.barBtnVisualizarImpressao.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnVisualizarImpressao.Glyph")));
            this.barBtnVisualizarImpressao.Id = 3;
            this.barBtnVisualizarImpressao.Name = "barBtnVisualizarImpressao";
            this.barBtnVisualizarImpressao.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnVisualizarImpressao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnVisualizarImpressao_ItemClick);
            // 
            // barCheckEditarTextArea
            // 
            this.barCheckEditarTextArea.Caption = "Habilitar área de texto";
            this.barCheckEditarTextArea.Glyph = ((System.Drawing.Image)(resources.GetObject("barCheckEditarTextArea.Glyph")));
            this.barCheckEditarTextArea.Id = 4;
            this.barCheckEditarTextArea.Name = "barCheckEditarTextArea";
            this.barCheckEditarTextArea.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barCheckEditarTextArea.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckEditarTextArea_CheckedChanged);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Início";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnImprimir);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnVisualizarImpressao);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnSelecionaArquivo);
            this.ribbonPageGroup1.ItemLinks.Add(this.barCheckEditarTextArea);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Impressão";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 727);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1012, 40);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.cbImpressoras, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtImpressao, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 179);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1012, 548);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cbImpressoras
            // 
            this.cbImpressoras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbImpressoras.Location = new System.Drawing.Point(23, 30);
            this.cbImpressoras.MenuManager = this.ribbon;
            this.cbImpressoras.Name = "cbImpressoras";
            this.cbImpressoras.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbImpressoras.Properties.Appearance.Options.UseFont = true;
            this.cbImpressoras.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbImpressoras.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbImpressoras.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbImpressoras.Size = new System.Drawing.Size(966, 28);
            this.cbImpressoras.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(23, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 21);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Impressoras";
            // 
            // txtImpressao
            // 
            this.txtImpressao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtImpressao.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtImpressao.Location = new System.Drawing.Point(23, 74);
            this.txtImpressao.Multiline = true;
            this.txtImpressao.Name = "txtImpressao";
            this.txtImpressao.ReadOnly = true;
            this.txtImpressao.Size = new System.Drawing.Size(966, 471);
            this.txtImpressao.TabIndex = 2;
            this.txtImpressao.TextChanged += new System.EventHandler(this.txtImpressao_TextChanged);
            // 
            // XFrmPrinterText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 767);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "XFrmPrinterText";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Controlador de Impressão Texto";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbImpressoras.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barBtnImprimir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.ComboBoxEdit cbImpressoras;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.BarButtonItem barBtnSelecionaArquivo;
        private System.Windows.Forms.TextBox txtImpressao;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraBars.BarButtonItem barBtnVisualizarImpressao;
        private DevExpress.XtraBars.BarCheckItem barCheckEditarTextArea;
    }
}