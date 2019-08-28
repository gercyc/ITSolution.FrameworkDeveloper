using System;

namespace ITSolution.Framework.Beans.Forms
{
    partial class XFrmScanning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmScanning));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticPageIndex = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticPagesCount = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemZoom = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.repositoryItemZoomTrackBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar();
            this.repositoryItemTrackBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemTrackBar();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picImagem = new System.Windows.Forms.PictureBox();
            this.cbExibicaoImagem = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblFileName = new DevExpress.XtraEditors.LabelControl();
            this.lblResolucao = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnRecortar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnLimpar = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemover = new DevExpress.XtraEditors.SimpleButton();
            this.btnRotacionar = new DevExpress.XtraEditors.SimpleButton();
            this.btnRedimensionar = new DevExpress.XtraEditors.SimpleButton();
            this.barBtnSelecionaArquivo = new DevExpress.XtraEditors.SimpleButton();
            this.btnDigitalizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnDigitalizarPara = new DevExpress.XtraEditors.SimpleButton();
            this.btnDigitalizarParaDisco = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnZoomIn = new DevExpress.XtraEditors.SimpleButton();
            this.trackBarControl1 = new DevExpress.XtraEditors.TrackBarControl();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.btnProximo = new DevExpress.XtraEditors.SimpleButton();
            this.btnZoomOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnterior = new DevExpress.XtraEditors.SimpleButton();
            this.chRenameTo = new DevExpress.XtraEditors.CheckEdit();
            this.openImage = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTrackBar1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbExibicaoImagem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chRenameTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barStaticItem1,
            this.barStaticPageIndex,
            this.barStaticItem3,
            this.barStaticPagesCount,
            this.barStaticItemZoom,
            this.barStaticItem2});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbon.MaxItemId = 14;
            this.ribbon.Name = "ribbon";
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemZoomTrackBar1,
            this.repositoryItemTrackBar1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(840, 52);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Páginas";
            this.barStaticItem1.Id = 3;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticPageIndex
            // 
            this.barStaticPageIndex.Caption = "0";
            this.barStaticPageIndex.Id = 4;
            this.barStaticPageIndex.Name = "barStaticPageIndex";
            this.barStaticPageIndex.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "/";
            this.barStaticItem3.Id = 5;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticPagesCount
            // 
            this.barStaticPagesCount.Caption = "0";
            this.barStaticPagesCount.Id = 6;
            this.barStaticPagesCount.Name = "barStaticPagesCount";
            this.barStaticPagesCount.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemZoom
            // 
            this.barStaticItemZoom.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItemZoom.Caption = "100%";
            this.barStaticItemZoom.Id = 11;
            this.barStaticItemZoom.Name = "barStaticItemZoom";
            this.barStaticItemZoom.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem2.Caption = "barStaticItem2";
            this.barStaticItem2.Id = 12;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // repositoryItemZoomTrackBar1
            // 
            this.repositoryItemZoomTrackBar1.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.repositoryItemZoomTrackBar1.Maximum = 200;
            this.repositoryItemZoomTrackBar1.Middle = 5;
            this.repositoryItemZoomTrackBar1.Minimum = 10;
            this.repositoryItemZoomTrackBar1.Name = "repositoryItemZoomTrackBar1";
            this.repositoryItemZoomTrackBar1.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.Bar;
            this.repositoryItemZoomTrackBar1.SmallChange = 10;
            // 
            // repositoryItemTrackBar1
            // 
            this.repositoryItemTrackBar1.LabelAppearance.Options.UseTextOptions = true;
            this.repositoryItemTrackBar1.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemTrackBar1.Name = "repositoryItemTrackBar1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticPageIndex);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem3);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticPagesCount);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemZoom);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 591);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(840, 32);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Controls.Add(this.picImagem, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbExibicaoImagem, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFileName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblResolucao, 3, 14);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 3, 12);
            this.tableLayoutPanel1.Controls.Add(this.btnRecortar, 3, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 11);
            this.tableLayoutPanel1.Controls.Add(this.btnLimpar, 3, 10);
            this.tableLayoutPanel1.Controls.Add(this.btnRemover, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.btnRotacionar, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnRedimensionar, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.barBtnSelecionaArquivo, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnDigitalizar, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnDigitalizarPara, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnDigitalizarParaDisco, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.panelControl2, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.chRenameTo, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.081633F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.153989F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.493506F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.888382F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.888382F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.888382F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.888382F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.888382F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.888382F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.888382F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.888382F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.888382F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.888382F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.256445F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.900448F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 539);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // picImagem
            // 
            this.picImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImagem.Location = new System.Drawing.Point(15, 24);
            this.picImagem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picImagem.Name = "picImagem";
            this.tableLayoutPanel1.SetRowSpan(this.picImagem, 13);
            this.picImagem.Size = new System.Drawing.Size(669, 462);
            this.picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImagem.TabIndex = 14;
            this.picImagem.TabStop = false;
            // 
            // cbExibicaoImagem
            // 
            this.cbExibicaoImagem.Location = new System.Drawing.Point(702, 41);
            this.cbExibicaoImagem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbExibicaoImagem.MenuManager = this.ribbon;
            this.cbExibicaoImagem.Name = "cbExibicaoImagem";
            this.cbExibicaoImagem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbExibicaoImagem.Properties.Appearance.Options.UseFont = true;
            this.cbExibicaoImagem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbExibicaoImagem.Properties.Items.AddRange(new object[] {
            "Normal",
            "Estender",
            "Automático",
            "Centralizado",
            "Zoom"});
            this.cbExibicaoImagem.Size = new System.Drawing.Size(123, 22);
            this.cbExibicaoImagem.TabIndex = 0;
            this.cbExibicaoImagem.SelectedIndexChanged += new System.EventHandler(this.cbExibicaoImagem_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(702, 24);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Modo Exibição";
            // 
            // lblFileName
            // 
            this.lblFileName.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileName.Location = new System.Drawing.Point(15, 2);
            this.lblFileName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(3, 13);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = " ";
            this.lblFileName.Click += new System.EventHandler(this.lblFileName_Click);
            // 
            // lblResolucao
            // 
            this.lblResolucao.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.tableLayoutPanel1.SetColumnSpan(this.lblResolucao, 2);
            this.lblResolucao.Location = new System.Drawing.Point(702, 490);
            this.lblResolucao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblResolucao.Name = "lblResolucao";
            this.lblResolucao.Size = new System.Drawing.Size(91, 13);
            this.lblResolucao.TabIndex = 17;
            this.lblResolucao.Text = "Resolução: 0 x 0";
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(702, 409);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(123, 28);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnRecortar
            // 
            this.btnRecortar.Enabled = false;
            this.btnRecortar.Image = ((System.Drawing.Image)(resources.GetObject("btnRecortar.Image")));
            this.btnRecortar.Location = new System.Drawing.Point(702, 446);
            this.btnRecortar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(123, 28);
            this.btnRecortar.TabIndex = 3;
            this.btnRecortar.Text = "Recortar";
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(702, 372);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(123, 28);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.Location = new System.Drawing.Point(702, 335);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(123, 28);
            this.btnLimpar.TabIndex = 9;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Image = ((System.Drawing.Image)(resources.GetObject("btnRemover.Image")));
            this.btnRemover.Location = new System.Drawing.Point(702, 298);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(123, 28);
            this.btnRemover.TabIndex = 8;
            this.btnRemover.Text = "Remover";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnRotacionar
            // 
            this.btnRotacionar.Image = ((System.Drawing.Image)(resources.GetObject("btnRotacionar.Image")));
            this.btnRotacionar.Location = new System.Drawing.Point(702, 261);
            this.btnRotacionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRotacionar.Name = "btnRotacionar";
            this.btnRotacionar.Size = new System.Drawing.Size(123, 28);
            this.btnRotacionar.TabIndex = 15;
            this.btnRotacionar.Text = "Rotacionar";
            this.btnRotacionar.Click += new System.EventHandler(this.btnRotacionar_Click);
            // 
            // btnRedimensionar
            // 
            this.btnRedimensionar.Enabled = false;
            this.btnRedimensionar.Image = ((System.Drawing.Image)(resources.GetObject("btnRedimensionar.Image")));
            this.btnRedimensionar.Location = new System.Drawing.Point(702, 224);
            this.btnRedimensionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRedimensionar.Name = "btnRedimensionar";
            this.btnRedimensionar.Size = new System.Drawing.Size(123, 28);
            this.btnRedimensionar.TabIndex = 0;
            this.btnRedimensionar.Text = "Redimensionar";
            this.btnRedimensionar.Click += new System.EventHandler(this.btnRedimensionar_Click);
            // 
            // barBtnSelecionaArquivo
            // 
            this.barBtnSelecionaArquivo.Image = ((System.Drawing.Image)(resources.GetObject("barBtnSelecionaArquivo.Image")));
            this.barBtnSelecionaArquivo.Location = new System.Drawing.Point(702, 76);
            this.barBtnSelecionaArquivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barBtnSelecionaArquivo.Name = "barBtnSelecionaArquivo";
            this.barBtnSelecionaArquivo.Size = new System.Drawing.Size(123, 28);
            this.barBtnSelecionaArquivo.TabIndex = 1;
            this.barBtnSelecionaArquivo.Text = "Carregar Imagem";
            this.barBtnSelecionaArquivo.Click += new System.EventHandler(this.barBtnSelecionaArquivo_Click);
            // 
            // btnDigitalizar
            // 
            this.btnDigitalizar.Image = global::ITSolution.Framework.Properties.Resources.scanner1_16x16;
            this.btnDigitalizar.Location = new System.Drawing.Point(702, 113);
            this.btnDigitalizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDigitalizar.Name = "btnDigitalizar";
            this.btnDigitalizar.Size = new System.Drawing.Size(123, 28);
            toolTipTitleItem1.Text = "Digitaliza uma imagem na impressora padrão.";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "A imagem não estará disponível posteriomente.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnDigitalizar.SuperTip = superToolTip1;
            this.btnDigitalizar.TabIndex = 2;
            this.btnDigitalizar.Text = "Digitalizar";
            this.btnDigitalizar.Click += new System.EventHandler(this.btnDigitalizar_Click);
            // 
            // btnDigitalizarPara
            // 
            this.btnDigitalizarPara.Image = global::ITSolution.Framework.Properties.Resources.scanner_advanced_16x16;
            this.btnDigitalizarPara.Location = new System.Drawing.Point(702, 150);
            this.btnDigitalizarPara.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDigitalizarPara.Name = "btnDigitalizarPara";
            this.btnDigitalizarPara.Size = new System.Drawing.Size(123, 28);
            toolTipTitleItem2.Text = "Digitaliza uma imagem na impressora selecionada.";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "A imagem não estará disponível posteriomente.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnDigitalizarPara.SuperTip = superToolTip2;
            this.btnDigitalizarPara.TabIndex = 18;
            this.btnDigitalizarPara.Text = "Digitalizar Para";
            this.btnDigitalizarPara.Click += new System.EventHandler(this.btnDigitalizarPara_Click);
            // 
            // btnDigitalizarParaDisco
            // 
            this.btnDigitalizarParaDisco.Image = ((System.Drawing.Image)(resources.GetObject("btnDigitalizarParaDisco.Image")));
            this.btnDigitalizarParaDisco.Location = new System.Drawing.Point(702, 187);
            this.btnDigitalizarParaDisco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDigitalizarParaDisco.Name = "btnDigitalizarParaDisco";
            this.btnDigitalizarParaDisco.Size = new System.Drawing.Size(123, 28);
            toolTipTitleItem3.Text = "Digitaliza uma imagem na impressora selecionada.";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "A imagem não estará disponível posteriomente.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnDigitalizarParaDisco.SuperTip = superToolTip3;
            this.btnDigitalizarParaDisco.TabIndex = 20;
            this.btnDigitalizarParaDisco.Text = "Digitalizar p/disco";
            this.btnDigitalizarParaDisco.Click += new System.EventHandler(this.btnDigitalizarParaDisco_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnZoomIn);
            this.panelControl2.Controls.Add(this.trackBarControl1);
            this.panelControl2.Controls.Add(this.btnFirst);
            this.panelControl2.Controls.Add(this.btnProximo);
            this.panelControl2.Controls.Add(this.btnZoomOut);
            this.panelControl2.Controls.Add(this.btnLast);
            this.panelControl2.Controls.Add(this.btnAnterior);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(15, 491);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(669, 45);
            this.panelControl2.TabIndex = 0;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
            this.btnZoomIn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnZoomIn.Location = new System.Drawing.Point(549, 7);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(30, 28);
            this.btnZoomIn.TabIndex = 18;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // trackBarControl1
            // 
            this.trackBarControl1.EditValue = 100;
            this.trackBarControl1.Location = new System.Drawing.Point(117, 0);
            this.trackBarControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBarControl1.MenuManager = this.ribbon;
            this.trackBarControl1.Name = "trackBarControl1";
            this.trackBarControl1.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.trackBarControl1.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.trackBarControl1.Properties.Maximum = 200;
            this.trackBarControl1.Properties.Minimum = 10;
            this.trackBarControl1.Properties.SmallChange = 10;
            this.trackBarControl1.Properties.TickFrequency = 10;
            this.trackBarControl1.Size = new System.Drawing.Size(426, 45);
            this.trackBarControl1.TabIndex = 16;
            this.trackBarControl1.Value = 100;
            this.trackBarControl1.EditValueChanged += new System.EventHandler(this.trackBarControl1_EditValueChanged);
            // 
            // btnFirst
            // 
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnFirst.Location = new System.Drawing.Point(5, 7);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(33, 28);
            this.btnFirst.TabIndex = 4;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnProximo
            // 
            this.btnProximo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnProximo.Image = ((System.Drawing.Image)(resources.GetObject("btnProximo.Image")));
            this.btnProximo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnProximo.Location = new System.Drawing.Point(623, 7);
            this.btnProximo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(33, 28);
            this.btnProximo.TabIndex = 0;
            this.btnProximo.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnZoomOut.Location = new System.Drawing.Point(81, 7);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(30, 28);
            this.btnZoomOut.TabIndex = 17;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnLast
            // 
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLast.Location = new System.Drawing.Point(584, 7);
            this.btnLast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(33, 28);
            this.btnLast.TabIndex = 3;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAnterior.Location = new System.Drawing.Point(42, 7);
            this.btnAnterior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(33, 28);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // chRenameTo
            // 
            this.chRenameTo.EditValue = true;
            this.chRenameTo.Location = new System.Drawing.Point(702, 3);
            this.chRenameTo.MenuManager = this.ribbon;
            this.chRenameTo.Name = "chRenameTo";
            this.chRenameTo.Properties.Caption = "Renomear ";
            this.chRenameTo.Size = new System.Drawing.Size(75, 19);
            this.chRenameTo.TabIndex = 21;
            this.chRenameTo.ToolTip = "Renomear arquivo após digitalização";
            // 
            // openImage
            // 
            this.openImage.Multiselect = true;
            // 
            // XFrmScanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 623);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "XFrmScanning";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Digitalização Avançada";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XFrmDigitalizacaoAvancada_FormClosing);
            this.SizeChanged += new System.EventHandler(this.XFrmDigitalizacaoAvancada_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XFrmScanning_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTrackBar1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbExibicaoImagem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chRenameTo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnDigitalizar;
        private DevExpress.XtraEditors.SimpleButton btnRedimensionar;
        private DevExpress.XtraEditors.SimpleButton barBtnSelecionaArquivo;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnRecortar;
        private DevExpress.XtraEditors.SimpleButton btnRemover;
        private DevExpress.XtraEditors.SimpleButton btnLimpar;
        private System.Windows.Forms.OpenFileDialog openImage;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraEditors.SimpleButton btnAnterior;
        private DevExpress.XtraEditors.SimpleButton btnProximo;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraEditors.LabelControl lblFileName;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticPageIndex;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticPagesCount;
        private DevExpress.XtraEditors.ComboBoxEdit cbExibicaoImagem;
        private DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar repositoryItemZoomTrackBar1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemZoom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.PictureBox picImagem;
        private DevExpress.XtraEditors.SimpleButton btnRotacionar;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTrackBar repositoryItemTrackBar1;
        private DevExpress.XtraEditors.TrackBarControl trackBarControl1;
        private DevExpress.XtraEditors.SimpleButton btnZoomOut;
        private DevExpress.XtraEditors.SimpleButton btnZoomIn;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.LabelControl lblResolucao;
        private DevExpress.XtraEditors.SimpleButton btnDigitalizarPara;
        private DevExpress.XtraEditors.SimpleButton btnDigitalizarParaDisco;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.CheckEdit chRenameTo;
    }
}