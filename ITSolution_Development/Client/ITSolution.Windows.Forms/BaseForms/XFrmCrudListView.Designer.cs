namespace ITSolution.Framework.Forms
{
    partial class XFrmCrudListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmCrudListView));
            this.barBtnNovo = new DevExpress.XtraBars.BarButtonItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnEditar = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRemover = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnAtualizar = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnVisualizar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // barBtnNovo
            // 
            this.barBtnNovo.Caption = "Novo";
            this.barBtnNovo.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnNovo.Glyph")));
            this.barBtnNovo.Id = 1;
            this.barBtnNovo.Name = "barBtnNovo";
            this.barBtnNovo.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnNovo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnNovo_ItemClick);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barBtnNovo,
            this.barBtnEditar,
            this.barBtnRemover,
            this.barBtnAtualizar,
            this.barBtnVisualizar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(965, 179);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barBtnEditar
            // 
            this.barBtnEditar.Caption = "Editar";
            this.barBtnEditar.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnEditar.Glyph")));
            this.barBtnEditar.Id = 2;
            this.barBtnEditar.Name = "barBtnEditar";
            this.barBtnEditar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnEditar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnEditar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnEditar_ItemClick);
            // 
            // barBtnRemover
            // 
            this.barBtnRemover.Caption = "Remover";
            this.barBtnRemover.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnRemover.Glyph")));
            this.barBtnRemover.Id = 3;
            this.barBtnRemover.Name = "barBtnRemover";
            this.barBtnRemover.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnRemover.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnRemover_ItemClick);
            // 
            // barBtnAtualizar
            // 
            this.barBtnAtualizar.Caption = "Atualizar";
            this.barBtnAtualizar.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnAtualizar.Glyph")));
            this.barBtnAtualizar.Id = 4;
            this.barBtnAtualizar.Name = "barBtnAtualizar";
            this.barBtnAtualizar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnAtualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnAtualizar_ItemClick);
            // 
            // barBtnVisualizar
            // 
            this.barBtnVisualizar.Caption = "Visualizar Impressão";
            this.barBtnVisualizar.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnVisualizar.Glyph")));
            this.barBtnVisualizar.Id = 5;
            this.barBtnVisualizar.Name = "barBtnVisualizar";
            this.barBtnVisualizar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barBtnVisualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnVisualizar_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Início";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnNovo);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnEditar);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnRemover);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnAtualizar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barBtnVisualizar);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Imprimir e Exportar";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 579);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(965, 40);
            // 
            // XFrmCrudListView
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 619);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "XFrmCrudListView";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "List View";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        protected DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        protected DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        protected DevExpress.XtraBars.BarButtonItem barBtnEditar;
        protected DevExpress.XtraBars.BarButtonItem barBtnRemover;
        protected DevExpress.XtraBars.BarButtonItem barBtnAtualizar;
        protected DevExpress.XtraBars.BarButtonItem barBtnVisualizar;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        protected DevExpress.XtraBars.BarButtonItem barBtnNovo;
    }
}