namespace ITSolution.Framework.Beans.Forms
{
    partial class XFrmFindEntity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmFindEntity));
            this.gridControlResults = new DevExpress.XtraGrid.GridControl();
            this.gridViewResults = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.txtFindString = new DevExpress.XtraBars.BarEditItem();
            this.repTextEdiFind = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnBuscar = new DevExpress.XtraBars.BarButtonItem();
            this.btnSelectItem = new DevExpress.XtraBars.BarButtonItem();
            this.batBtnActionPerformed = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnAtualizar = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTextEdiFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlResults
            // 
            this.gridControlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlResults.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlResults.Location = new System.Drawing.Point(0, 38);
            this.gridControlResults.MainView = this.gridViewResults;
            this.gridControlResults.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlResults.Name = "gridControlResults";
            this.gridControlResults.Size = new System.Drawing.Size(847, 506);
            this.gridControlResults.TabIndex = 0;
            this.gridControlResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewResults});
            this.gridControlResults.DoubleClick += new System.EventHandler(this.gridControlResults_DoubleClick);
            this.gridControlResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControlResults_KeyDown);
            // 
            // gridViewResults
            // 
            this.gridViewResults.GridControl = this.gridControlResults;
            this.gridViewResults.Name = "gridViewResults";
            this.gridViewResults.OptionsBehavior.Editable = false;
            this.gridViewResults.OptionsView.ColumnAutoWidth = false;
            this.gridViewResults.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewResults.OptionsView.ShowGroupPanel = false;
            // 
            // barManager1
            // 
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.txtFindString,
            this.btnBuscar,
            this.btnSelectItem,
            this.barBtnAtualizar,
            this.batBtnActionPerformed,
            this.barBtnCancelar});
            this.barManager1.MaxItemId = 8;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repTextEdiFind});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.txtFindString),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBuscar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSelectItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.batBtnActionPerformed),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnCancelar),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnAtualizar)});
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Filtrar:";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // txtFindString
            // 
            this.txtFindString.Edit = this.repTextEdiFind;
            this.txtFindString.EditWidth = 255;
            this.txtFindString.Id = 1;
            this.txtFindString.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F));
            this.txtFindString.Name = "txtFindString";
            this.txtFindString.EditValueChanged += new System.EventHandler(this.txtFindString_EditValueChanged);
            // 
            // repTextEdiFind
            // 
            this.repTextEdiFind.AutoHeight = false;
            this.repTextEdiFind.Name = "repTextEdiFind";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Caption = "Buscar";
            this.btnBuscar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Glyph")));
            this.btnBuscar.Id = 2;
            this.btnBuscar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L));
            this.btnBuscar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnBuscar.LargeGlyph")));
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnBuscar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBuscar_ItemClick);
            // 
            // btnSelectItem
            // 
            this.btnSelectItem.Caption = "Selecionar";
            this.btnSelectItem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSelectItem.Glyph")));
            this.btnSelectItem.Id = 3;
            this.btnSelectItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSelectItem.LargeGlyph")));
            this.btnSelectItem.Name = "btnSelectItem";
            this.btnSelectItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSelectItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelectItem_ItemClick);
            // 
            // batBtnActionPerformed
            // 
            this.batBtnActionPerformed.Glyph = ((System.Drawing.Image)(resources.GetObject("batBtnActionPerformed.Glyph")));
            this.batBtnActionPerformed.Id = 5;
            this.batBtnActionPerformed.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("batBtnActionPerformed.LargeGlyph")));
            this.batBtnActionPerformed.Name = "batBtnActionPerformed";
            this.batBtnActionPerformed.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.batBtnActionPerformed.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.batBtnActionPerformed_ItemClick);
            // 
            // barBtnCancelar
            // 
            this.barBtnCancelar.Caption = "Cancelar";
            this.barBtnCancelar.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnCancelar.Glyph")));
            this.barBtnCancelar.Id = 6;
            this.barBtnCancelar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnCancelar.LargeGlyph")));
            this.barBtnCancelar.Name = "barBtnCancelar";
            this.barBtnCancelar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCancelar_ItemClick);
            // 
            // barBtnAtualizar
            // 
            this.barBtnAtualizar.Caption = "Atualizar";
            this.barBtnAtualizar.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnAtualizar.Glyph")));
            this.barBtnAtualizar.Id = 4;
            this.barBtnAtualizar.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.barBtnAtualizar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnAtualizar.LargeGlyph")));
            this.barBtnAtualizar.Name = "barBtnAtualizar";
            this.barBtnAtualizar.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.barBtnAtualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnAtualizar_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(847, 38);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 544);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(847, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 38);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 506);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(847, 38);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 506);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            // 
            // XFrmFindEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 566);
            this.Controls.Add(this.gridControlResults);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "XFrmFindEntity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Localizar:";
            this.Shown += new System.EventHandler(this.XFrmFindEntity_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XFrmFindEntity_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.XFrmFindEntity_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTextEdiFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlResults;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewResults;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem txtFindString;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repTextEdiFind;
        private DevExpress.XtraBars.BarButtonItem btnBuscar;
        private DevExpress.XtraBars.BarButtonItem btnSelectItem;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barBtnAtualizar;
        private DevExpress.XtraBars.BarButtonItem batBtnActionPerformed;
        private DevExpress.XtraBars.BarButtonItem barBtnCancelar;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
    }
}