using System;
using System.Windows.Forms;

namespace ITSolution.Admin.Forms.ContextUtil
{
    partial class XFrmContextUtil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmContextUtil));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnSelectDir = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnGerarContexto = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticConvertendo = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticNone = new DevExpress.XtraBars.BarStaticItem();
            this.barBtnSelecionarFileCs = new DevExpress.XtraBars.BarButtonItem();
            this.barToggleSwitchReplace = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.barToggleSwitchModo = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.barBtnShowResult = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCriptografarString = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCreateAppXml = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDescriptografarString = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticOk = new DevExpress.XtraBars.BarStaticItem();
            this.barBtnSetConnString = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnConfigAppXml = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewClasses = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPathName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fBrowserFileCs = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileCs = new System.Windows.Forms.OpenFileDialog();
            this.openFileAppConfig = new System.Windows.Forms.OpenFileDialog();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewClasses)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNavigationPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barBtnSelectDir,
            this.barBtnGerarContexto,
            this.barStaticConvertendo,
            this.barStaticNone,
            this.barBtnSelecionarFileCs,
            this.barToggleSwitchReplace,
            this.barToggleSwitchModo,
            this.barBtnShowResult,
            this.barBtnCriptografarString,
            this.barBtnCreateAppXml,
            this.barBtnDescriptografarString,
            this.barStaticOk,
            this.barBtnSetConnString,
            this.barBtnConfigAppXml});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbon.MaxItemId = 37;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemRadioGroup1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckedComboBoxEdit1,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.Size = new System.Drawing.Size(979, 183);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barBtnSelectDir
            // 
            this.barBtnSelectDir.Caption = "Selecionar Diretório";
            this.barBtnSelectDir.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSelectDir.Glyph")));
            this.barBtnSelectDir.Id = 1;
            this.barBtnSelectDir.Name = "barBtnSelectDir";
            this.barBtnSelectDir.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnSelectDir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barBtnSelectDir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSelectDir_ItemClick);
            // 
            // barBtnGerarContexto
            // 
            this.barBtnGerarContexto.Caption = "Gerar Contexto";
            this.barBtnGerarContexto.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnGerarContexto.Glyph")));
            this.barBtnGerarContexto.Id = 2;
            this.barBtnGerarContexto.Name = "barBtnGerarContexto";
            this.barBtnGerarContexto.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barBtnGerarContexto.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnGerarContexto_ItemClick);
            // 
            // barStaticConvertendo
            // 
            this.barStaticConvertendo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticConvertendo.Glyph = ((System.Drawing.Image)(resources.GetObject("barStaticConvertendo.Glyph")));
            this.barStaticConvertendo.Id = 3;
            this.barStaticConvertendo.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barStaticConvertendo.LargeGlyph")));
            this.barStaticConvertendo.Name = "barStaticConvertendo";
            this.barStaticConvertendo.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStaticConvertendo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barStaticNone
            // 
            this.barStaticNone.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticNone.Glyph = ((System.Drawing.Image)(resources.GetObject("barStaticNone.Glyph")));
            this.barStaticNone.Id = 4;
            this.barStaticNone.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barStaticNone.LargeGlyph")));
            this.barStaticNone.Name = "barStaticNone";
            this.barStaticNone.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barBtnSelecionarFileCs
            // 
            this.barBtnSelecionarFileCs.Caption = "Selecionar Arquivo(s)";
            this.barBtnSelecionarFileCs.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSelecionarFileCs.Glyph")));
            this.barBtnSelecionarFileCs.Id = 5;
            this.barBtnSelecionarFileCs.Name = "barBtnSelecionarFileCs";
            this.barBtnSelecionarFileCs.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barBtnSelecionarFileCs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSelecionarFileCs_ItemClick);
            // 
            // barToggleSwitchReplace
            // 
            this.barToggleSwitchReplace.Caption = "Sobreescrever:   ";
            this.barToggleSwitchReplace.Glyph = ((System.Drawing.Image)(resources.GetObject("barToggleSwitchReplace.Glyph")));
            this.barToggleSwitchReplace.Id = 16;
            this.barToggleSwitchReplace.Name = "barToggleSwitchReplace";
            this.barToggleSwitchReplace.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            superToolTip1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem1.Text = "Ação efetuada sobre a tabela e App.config";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = resources.GetString("toolTipItem1.Text");
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.barToggleSwitchReplace.SuperTip = superToolTip1;
            // 
            // barToggleSwitchModo
            // 
            this.barToggleSwitchModo.BindableChecked = true;
            this.barToggleSwitchModo.Caption = "Modo optimizado:";
            this.barToggleSwitchModo.Checked = true;
            this.barToggleSwitchModo.Glyph = ((System.Drawing.Image)(resources.GetObject("barToggleSwitchModo.Glyph")));
            this.barToggleSwitchModo.Id = 17;
            this.barToggleSwitchModo.Name = "barToggleSwitchModo";
            superToolTip2.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            toolTipTitleItem2.Text = "Modo Default  e Modo optimizado\r\n\r\n\r\n";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = resources.GetString("toolTipItem2.Text");
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.barToggleSwitchModo.SuperTip = superToolTip2;
            // 
            // barBtnShowResult
            // 
            this.barBtnShowResult.Caption = "Visualizar Contexto";
            this.barBtnShowResult.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnShowResult.Glyph")));
            this.barBtnShowResult.Id = 18;
            this.barBtnShowResult.Name = "barBtnShowResult";
            this.barBtnShowResult.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnShowResult.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnShowResult_ItemClick);
            // 
            // barBtnCriptografarString
            // 
            this.barBtnCriptografarString.Caption = "Criptografar Conexão";
            this.barBtnCriptografarString.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnCriptografarString.Glyph")));
            this.barBtnCriptografarString.Id = 19;
            this.barBtnCriptografarString.Name = "barBtnCriptografarString";
            toolTipTitleItem3.Text = "Criptografa a string de conexão do arquivo App.config";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "O arquivo atual será alterado";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.barBtnCriptografarString.SuperTip = superToolTip3;
            this.barBtnCriptografarString.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCriptografarString_ItemClick);
            // 
            // barBtnCreateAppXml
            // 
            this.barBtnCreateAppXml.Caption = "Criar Conexão";
            this.barBtnCreateAppXml.Glyph = global::ITSolution.Admin.Properties.Resources.ExtendedProperty;
            this.barBtnCreateAppXml.Id = 20;
            this.barBtnCreateAppXml.Name = "barBtnCreateAppXml";
            this.barBtnCreateAppXml.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            toolTipTitleItem4.Text = "Cria um arquivo de configuração com uma string criptografada";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "A criptografia é opcional";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.barBtnCreateAppXml.SuperTip = superToolTip4;
            this.barBtnCreateAppXml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCreateAppConfig_ItemClick);
            // 
            // barBtnDescriptografarString
            // 
            this.barBtnDescriptografarString.Caption = "Descriptografar Conexão";
            this.barBtnDescriptografarString.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnDescriptografarString.Glyph")));
            this.barBtnDescriptografarString.Id = 21;
            this.barBtnDescriptografarString.Name = "barBtnDescriptografarString";
            toolTipTitleItem5.Text = "Descriptografa a string de conexão do arquivo App.config";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "O arquivo atual será alterado";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            this.barBtnDescriptografarString.SuperTip = superToolTip5;
            this.barBtnDescriptografarString.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDescriptografarString_ItemClick);
            // 
            // barStaticOk
            // 
            this.barStaticOk.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticOk.Glyph = ((System.Drawing.Image)(resources.GetObject("barStaticOk.Glyph")));
            this.barStaticOk.Id = 32;
            this.barStaticOk.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barStaticOk.LargeGlyph")));
            this.barStaticOk.Name = "barStaticOk";
            this.barStaticOk.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStaticOk.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnSetConnString
            // 
            this.barBtnSetConnString.Caption = "Alternar Database";
            this.barBtnSetConnString.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSetConnString.Glyph")));
            this.barBtnSetConnString.Id = 34;
            this.barBtnSetConnString.Name = "barBtnSetConnString";
            this.barBtnSetConnString.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barBtnSetConnString.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSetConnString_ItemClick);
            // 
            // barBtnConfigAppXml
            // 
            this.barBtnConfigAppXml.Caption = "Configurar Conexão";
            this.barBtnConfigAppXml.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnConfigAppXml.Glyph")));
            this.barBtnConfigAppXml.Id = 35;
            this.barBtnConfigAppXml.Name = "barBtnConfigAppXml";
            this.barBtnConfigAppXml.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barBtnConfigAppXml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnConfigAppXml_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnSelecionarFileCs);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnSelectDir);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnGerarContexto);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnShowResult);
            this.ribbonPageGroup1.ItemLinks.Add(this.barToggleSwitchReplace);
            this.ribbonPageGroup1.ItemLinks.Add(this.barToggleSwitchModo);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Contexto";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barBtnCreateAppXml);
            this.ribbonPageGroup2.ItemLinks.Add(this.barBtnConfigAppXml);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Configuração XML Conexão";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.barBtnSetConnString);
            this.ribbonPageGroup3.ItemLinks.Add(this.barBtnCriptografarString);
            this.ribbonPageGroup3.ItemLinks.Add(this.barBtnDescriptografarString);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "App.config";
            this.ribbonPageGroup3.Visible = false;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Columns = 2;
            this.repositoryItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Adiconar"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Substituir")});
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticNone);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticConvertendo);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticOk);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 726);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(979, 41);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridViewClasses;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(957, 486);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewClasses});
            // 
            // gridViewClasses
            // 
            this.gridViewClasses.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colClassName,
            this.colPathName});
            this.gridViewClasses.GridControl = this.gridControl1;
            this.gridViewClasses.Name = "gridViewClasses";
            this.gridViewClasses.OptionsBehavior.Editable = false;
            this.gridViewClasses.OptionsSelection.MultiSelect = true;
            this.gridViewClasses.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewClasses.OptionsView.ShowGroupPanel = false;
            this.gridViewClasses.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewClasses_SelectionChanged);
            this.gridViewClasses.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewClasses_KeyDown);
            // 
            // colId
            // 
            this.colId.AppearanceCell.Options.UseTextOptions = true;
            this.colId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colId.AppearanceHeader.Options.UseTextOptions = true;
            this.colId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colId.Caption = "ID";
            this.colId.FieldName = "ID";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 1;
            this.colId.Width = 88;
            // 
            // colClassName
            // 
            this.colClassName.AppearanceCell.Options.UseTextOptions = true;
            this.colClassName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colClassName.AppearanceHeader.Options.UseTextOptions = true;
            this.colClassName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colClassName.Caption = "Class Name";
            this.colClassName.FieldName = "ClassName";
            this.colClassName.Name = "colClassName";
            this.colClassName.OptionsColumn.AllowEdit = false;
            this.colClassName.Visible = true;
            this.colClassName.VisibleIndex = 3;
            this.colClassName.Width = 264;
            // 
            // colPathName
            // 
            this.colPathName.AppearanceCell.Options.UseTextOptions = true;
            this.colPathName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPathName.AppearanceHeader.Options.UseTextOptions = true;
            this.colPathName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPathName.Caption = "Path Name";
            this.colPathName.FieldName = "Path";
            this.colPathName.Name = "colPathName";
            this.colPathName.OptionsColumn.AllowEdit = false;
            this.colPathName.Visible = true;
            this.colPathName.VisibleIndex = 2;
            this.colPathName.Width = 556;
            // 
            // openFileCs
            // 
            this.openFileCs.Filter = "C# files |*.cs";
            this.openFileCs.Multiselect = true;
            // 
            // openFileAppConfig
            // 
            this.openFileAppConfig.Filter = "App Config |*.config";
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNavigationPage1);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 183);
            this.tabPane1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage1});
            this.tabPane1.RegularSize = new System.Drawing.Size(979, 543);
            this.tabPane1.SelectedPage = this.tabNavigationPage1;
            this.tabPane1.SelectedPageIndex = 0;
            this.tabPane1.Size = new System.Drawing.Size(979, 543);
            this.tabPane1.TabIndex = 5;
            this.tabPane1.Text = "Contexto";
            // 
            // tabNavigationPage1
            // 
            this.tabNavigationPage1.Caption = "Contexto";
            this.tabNavigationPage1.Controls.Add(this.gridControl1);
            this.tabNavigationPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabNavigationPage1.Name = "tabNavigationPage1";
            this.tabNavigationPage1.Size = new System.Drawing.Size(957, 486);
            // 
            // XFrmContextUtil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 767);
            this.Controls.Add(this.tabPane1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "XFrmContextUtil";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "System Utilities";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewClasses)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNavigationPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void gridViewClasses_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                gridViewClasses.DeleteSelectedRows();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barBtnSelectDir;
        private DevExpress.XtraBars.BarButtonItem barBtnGerarContexto;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewClasses;
        private DevExpress.XtraGrid.Columns.GridColumn colClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colPathName;
        private DevExpress.XtraBars.BarStaticItem barStaticConvertendo;
        private DevExpress.XtraBars.BarStaticItem barStaticNone;
        private System.Windows.Forms.FolderBrowserDialog fBrowserFileCs;
        private DevExpress.XtraBars.BarButtonItem barBtnSelecionarFileCs;
        private System.Windows.Forms.OpenFileDialog openFileCs;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraBars.BarToggleSwitchItem barToggleSwitchReplace;
        private DevExpress.XtraBars.BarToggleSwitchItem barToggleSwitchModo;
        private DevExpress.XtraBars.BarButtonItem barBtnShowResult;
        private DevExpress.XtraBars.BarButtonItem barBtnCriptografarString;
        private DevExpress.XtraBars.BarButtonItem barBtnCreateAppXml;
        private System.Windows.Forms.OpenFileDialog openFileAppConfig;
        private DevExpress.XtraBars.BarButtonItem barBtnDescriptografarString;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
        private DevExpress.XtraBars.BarStaticItem barStaticOk;
        private DevExpress.XtraBars.BarButtonItem barBtnSetConnString;
        private DevExpress.XtraBars.BarButtonItem barBtnConfigAppXml;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}