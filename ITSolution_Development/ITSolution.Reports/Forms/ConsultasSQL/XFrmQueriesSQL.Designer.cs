
namespace ITSolution.Reports.Forms.ConsultasSQL
{
    partial class XFrmQueriesSQL
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmQueriesSQL));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNewQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControlQueries = new DevExpress.XtraGrid.GridControl();
            this.sqlQueryItsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewQueris = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdQuery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoQuery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomeQuery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCorpoQuery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataCriacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataAlteracao = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQueries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQueryItsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQueris)).BeginInit();
            this.SuspendLayout();
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
            this.btnNewQuery,
            this.btnEditQuery,
            this.btnRemoveQuery,
            this.btnRefresh});
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEditQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRemoveQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnNewQuery
            // 
            this.btnNewQuery.Caption = "Nova consulta";
            this.btnNewQuery.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNewQuery.Glyph")));
            this.btnNewQuery.Id = 0;
            this.btnNewQuery.Name = "btnNewQuery";
            this.btnNewQuery.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnNewQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewQuery_ItemClick);
            // 
            // btnEditQuery
            // 
            this.btnEditQuery.Caption = "Editar consulta";
            this.btnEditQuery.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEditQuery.Glyph")));
            this.btnEditQuery.Id = 1;
            this.btnEditQuery.Name = "btnEditQuery";
            this.btnEditQuery.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnEditQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditQuery_ItemClick);
            // 
            // btnRemoveQuery
            // 
            this.btnRemoveQuery.Caption = "Remover consulta";
            this.btnRemoveQuery.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveQuery.Glyph")));
            this.btnRemoveQuery.Id = 2;
            this.btnRemoveQuery.Name = "btnRemoveQuery";
            this.btnRemoveQuery.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnRemoveQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoveQuery_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Atualizar";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 3;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(760, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 367);
            this.barDockControlBottom.Size = new System.Drawing.Size(760, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 320);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(760, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 320);
            // 
            // gridControlQueries
            // 
            this.gridControlQueries.DataSource = this.sqlQueryItsBindingSource;
            this.gridControlQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlQueries.Location = new System.Drawing.Point(0, 47);
            this.gridControlQueries.MainView = this.gridViewQueris;
            this.gridControlQueries.MenuManager = this.barManager1;
            this.gridControlQueries.Name = "gridControlQueries";
            this.gridControlQueries.Size = new System.Drawing.Size(760, 320);
            this.gridControlQueries.TabIndex = 4;
            this.gridControlQueries.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewQueris});
            // 
            // sqlQueryItsBindingSource
            // 
            this.sqlQueryItsBindingSource.DataSource = typeof(ITSolution.Framework.Common.BaseClasses.Reports.SqlQueryIts);
            // 
            // gridViewQueris
            // 
            this.gridViewQueris.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdQuery,
            this.colCodigoQuery,
            this.colNomeQuery,
            this.colCorpoQuery,
            this.colDataCriacao,
            this.colDataAlteracao});
            this.gridViewQueris.GridControl = this.gridControlQueries;
            this.gridViewQueris.Name = "gridViewQueris";
            // 
            // colIdQuery
            // 
            this.colIdQuery.FieldName = "IdQuery";
            this.colIdQuery.Name = "colIdQuery";
            // 
            // colCodigoQuery
            // 
            this.colCodigoQuery.Caption = "Código";
            this.colCodigoQuery.FieldName = "CodigoQuery";
            this.colCodigoQuery.Name = "colCodigoQuery";
            this.colCodigoQuery.Visible = true;
            this.colCodigoQuery.VisibleIndex = 0;
            this.colCodigoQuery.Width = 158;
            // 
            // colNomeQuery
            // 
            this.colNomeQuery.Caption = "Descrição";
            this.colNomeQuery.FieldName = "NomeQuery";
            this.colNomeQuery.Name = "colNomeQuery";
            this.colNomeQuery.Visible = true;
            this.colNomeQuery.VisibleIndex = 1;
            this.colNomeQuery.Width = 368;
            // 
            // colCorpoQuery
            // 
            this.colCorpoQuery.FieldName = "CorpoQuery";
            this.colCorpoQuery.Name = "colCorpoQuery";
            // 
            // colDataCriacao
            // 
            this.colDataCriacao.Caption = "Data de criação";
            this.colDataCriacao.FieldName = "DataCriacao";
            this.colDataCriacao.Name = "colDataCriacao";
            this.colDataCriacao.Visible = true;
            this.colDataCriacao.VisibleIndex = 2;
            this.colDataCriacao.Width = 216;
            // 
            // colDataAlteracao
            // 
            this.colDataAlteracao.FieldName = "DataAlteracao";
            this.colDataAlteracao.Name = "colDataAlteracao";
            // 
            // XFrmQueriesSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 390);
            this.Controls.Add(this.gridControlQueries);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "XFrmQueriesSQL";
            this.Text = "Consultas SQL";
            this.Shown += new System.EventHandler(this.XFrmQueriesSQL_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQueries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQueryItsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQueris)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnNewQuery;
        private DevExpress.XtraBars.BarButtonItem btnEditQuery;
        private DevExpress.XtraBars.BarButtonItem btnRemoveQuery;
        private DevExpress.XtraGrid.GridControl gridControlQueries;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewQueris;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private System.Windows.Forms.BindingSource sqlQueryItsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIdQuery;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoQuery;
        private DevExpress.XtraGrid.Columns.GridColumn colNomeQuery;
        private DevExpress.XtraGrid.Columns.GridColumn colCorpoQuery;
        private DevExpress.XtraGrid.Columns.GridColumn colDataCriacao;
        private DevExpress.XtraGrid.Columns.GridColumn colDataAlteracao;
    }
}