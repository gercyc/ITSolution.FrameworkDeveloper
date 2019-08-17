namespace ITSolution.Reports.Forms.DesignerEditor
{
    partial class XFrmConfigSourceRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmConfigSourceRpt));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnAddConsulta = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditConsulta = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveSource = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetDatamember = new DevExpress.XtraBars.BarButtonItem();
            this.btnOk = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.reportDataSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdDataSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdReport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdQuery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatamember = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomeQuery = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataSourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.btnOk,
            this.btnRemoveSource,
            this.btnSetDatamember,
            this.btnEditConsulta,
            this.btnAddConsulta});
            this.barManager1.MaxItemId = 6;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddConsulta),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEditConsulta),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRemoveSource),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSetDatamember),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOk)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnAddConsulta
            // 
            this.btnAddConsulta.Caption = "Adicionar consulta";
            this.btnAddConsulta.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddConsulta.Glyph")));
            this.btnAddConsulta.Id = 5;
            this.btnAddConsulta.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddConsulta.LargeGlyph")));
            this.btnAddConsulta.Name = "btnAddConsulta";
            this.btnAddConsulta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddConsulta_ItemClick);
            // 
            // btnEditConsulta
            // 
            this.btnEditConsulta.Caption = "Editar consulta";
            this.btnEditConsulta.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEditConsulta.Glyph")));
            this.btnEditConsulta.Id = 4;
            this.btnEditConsulta.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnEditConsulta.LargeGlyph")));
            this.btnEditConsulta.Name = "btnEditConsulta";
            this.btnEditConsulta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditConsulta_ItemClick);
            // 
            // btnRemoveSource
            // 
            this.btnRemoveSource.Caption = "Remover";
            this.btnRemoveSource.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveSource.Glyph")));
            this.btnRemoveSource.Id = 2;
            this.btnRemoveSource.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveSource.LargeGlyph")));
            this.btnRemoveSource.Name = "btnRemoveSource";
            // 
            // btnSetDatamember
            // 
            this.btnSetDatamember.Caption = "Definir como datamember";
            this.btnSetDatamember.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSetDatamember.Glyph")));
            this.btnSetDatamember.Id = 3;
            this.btnSetDatamember.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSetDatamember.LargeGlyph")));
            this.btnSetDatamember.Name = "btnSetDatamember";
            // 
            // btnOk
            // 
            this.btnOk.Caption = "Ok";
            this.btnOk.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOk.Glyph")));
            this.btnOk.Id = 0;
            this.btnOk.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOk.LargeGlyph")));
            this.btnOk.Name = "btnOk";
            this.btnOk.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnOk.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOk_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(398, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 326);
            this.barDockControlBottom.Size = new System.Drawing.Size(398, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 295);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(398, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 295);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.reportDataSourceBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 31);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(398, 295);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // reportDataSourceBindingSource
            // 
            this.reportDataSourceBindingSource.DataSource = typeof(ITSolution.Framework.Common.BaseClasses.Reports.ReportDataSource);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdDataSource,
            this.colIdReport,
            this.colIdQuery,
            this.colDatamember,
            this.colNomeQuery});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colIdDataSource
            // 
            this.colIdDataSource.FieldName = "IdDataSource";
            this.colIdDataSource.Name = "colIdDataSource";
            // 
            // colIdReport
            // 
            this.colIdReport.FieldName = "IdReport";
            this.colIdReport.Name = "colIdReport";
            // 
            // colIdQuery
            // 
            this.colIdQuery.FieldName = "Consulta.CodigoQuery";
            this.colIdQuery.Name = "colIdQuery";
            this.colIdQuery.OptionsColumn.AllowEdit = false;
            this.colIdQuery.Visible = true;
            this.colIdQuery.VisibleIndex = 0;
            this.colIdQuery.Width = 77;
            // 
            // colDatamember
            // 
            this.colDatamember.FieldName = "Datamember";
            this.colDatamember.Name = "colDatamember";
            this.colDatamember.Visible = true;
            this.colDatamember.VisibleIndex = 2;
            this.colDatamember.Width = 85;
            // 
            // colNomeQuery
            // 
            this.colNomeQuery.Caption = "Nome query";
            this.colNomeQuery.FieldName = "Consulta.NomeQuery";
            this.colNomeQuery.Name = "colNomeQuery";
            this.colNomeQuery.OptionsColumn.AllowEdit = false;
            this.colNomeQuery.Visible = true;
            this.colNomeQuery.VisibleIndex = 1;
            this.colNomeQuery.Width = 218;
            // 
            // XFrmConfigSourceRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 349);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "XFrmConfigSourceRpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar fontes de dados";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataSourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnOk;
        private DevExpress.XtraBars.BarButtonItem btnRemoveSource;
        private DevExpress.XtraBars.BarButtonItem btnSetDatamember;
        private DevExpress.XtraBars.BarButtonItem btnEditConsulta;
        private DevExpress.XtraBars.BarButtonItem btnAddConsulta;
        private System.Windows.Forms.BindingSource reportDataSourceBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIdDataSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIdReport;
        private DevExpress.XtraGrid.Columns.GridColumn colIdQuery;
        private DevExpress.XtraGrid.Columns.GridColumn colDatamember;
        private DevExpress.XtraGrid.Columns.GridColumn colNomeQuery;
    }
}