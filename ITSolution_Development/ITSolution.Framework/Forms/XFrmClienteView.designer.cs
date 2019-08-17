namespace ITSolution.Framework.Beans.Forms
{
    partial class XFrmClienteView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param colName="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmClienteView));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewCliFor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidCliFor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomeCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcpfCnpj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnSelecionarCliente = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCliFor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(0, 47);
            this.gridControl1.MainView = this.gridViewCliFor;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(696, 414);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCliFor});
            // 
            // gridViewCliFor
            // 
            this.gridViewCliFor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidCliFor,
            this.colNomeCliente,
            this.colTipoCliente,
            this.colcpfCnpj,
            this.colRg});
            this.gridViewCliFor.GridControl = this.gridControl1;
            this.gridViewCliFor.Name = "gridViewCliFor";
            this.gridViewCliFor.OptionsBehavior.Editable = false;
            this.gridViewCliFor.OptionsFind.AlwaysVisible = true;
            this.gridViewCliFor.OptionsFind.FindNullPrompt = "Digite aqui sua pesquisa...";
            this.gridViewCliFor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewCliFor_KeyDown);
            this.gridViewCliFor.DoubleClick += new System.EventHandler(this.gridViewCliFor_DoubleClick);
            // 
            // colidCliFor
            // 
            this.colidCliFor.AppearanceCell.Options.UseTextOptions = true;
            this.colidCliFor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colidCliFor.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colidCliFor.AppearanceHeader.Options.UseTextOptions = true;
            this.colidCliFor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colidCliFor.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colidCliFor.Caption = "ID";
            this.colidCliFor.FieldName = "IdCliente";
            this.colidCliFor.Name = "colidCliFor";
            this.colidCliFor.OptionsColumn.AllowEdit = false;
            this.colidCliFor.OptionsColumn.FixedWidth = true;
            this.colidCliFor.OptionsColumn.ReadOnly = true;
            this.colidCliFor.Visible = true;
            this.colidCliFor.VisibleIndex = 0;
            this.colidCliFor.Width = 80;
            // 
            // colNomeCliente
            // 
            this.colNomeCliente.AppearanceCell.Options.UseTextOptions = true;
            this.colNomeCliente.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNomeCliente.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNomeCliente.AppearanceHeader.Options.UseTextOptions = true;
            this.colNomeCliente.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNomeCliente.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNomeCliente.Caption = "Nome";
            this.colNomeCliente.FieldName = "NomeCliente";
            this.colNomeCliente.Name = "colNomeCliente";
            this.colNomeCliente.OptionsColumn.AllowEdit = false;
            this.colNomeCliente.Visible = true;
            this.colNomeCliente.VisibleIndex = 1;
            this.colNomeCliente.Width = 346;
            // 
            // colTipoCliente
            // 
            this.colTipoCliente.AppearanceCell.Options.UseTextOptions = true;
            this.colTipoCliente.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTipoCliente.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTipoCliente.AppearanceHeader.Options.UseTextOptions = true;
            this.colTipoCliente.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTipoCliente.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTipoCliente.Caption = "Tipo Cliente";
            this.colTipoCliente.FieldName = "TipoCliente";
            this.colTipoCliente.Name = "colTipoCliente";
            this.colTipoCliente.OptionsColumn.AllowEdit = false;
            this.colTipoCliente.OptionsColumn.FixedWidth = true;
            this.colTipoCliente.Visible = true;
            this.colTipoCliente.VisibleIndex = 4;
            this.colTipoCliente.Width = 100;
            // 
            // colcpfCnpj
            // 
            this.colcpfCnpj.AppearanceCell.Options.UseTextOptions = true;
            this.colcpfCnpj.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcpfCnpj.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colcpfCnpj.AppearanceHeader.Options.UseTextOptions = true;
            this.colcpfCnpj.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcpfCnpj.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colcpfCnpj.Caption = "CPF/CNPJ";
            this.colcpfCnpj.FieldName = "CpfCnpj";
            this.colcpfCnpj.Name = "colcpfCnpj";
            this.colcpfCnpj.OptionsColumn.AllowEdit = false;
            this.colcpfCnpj.OptionsColumn.FixedWidth = true;
            this.colcpfCnpj.Visible = true;
            this.colcpfCnpj.VisibleIndex = 2;
            this.colcpfCnpj.Width = 150;
            // 
            // colRg
            // 
            this.colRg.AppearanceCell.Options.UseTextOptions = true;
            this.colRg.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRg.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRg.AppearanceHeader.Options.UseTextOptions = true;
            this.colRg.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRg.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRg.Caption = "RG";
            this.colRg.FieldName = "RG";
            this.colRg.Name = "colRg";
            this.colRg.Visible = true;
            this.colRg.VisibleIndex = 3;
            this.colRg.Width = 88;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 461);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = null;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(696, 20);
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
            this.barBtnSelecionarCliente});
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSelecionarCliente)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barBtnSelecionarCliente
            // 
            this.barBtnSelecionarCliente.Caption = "Selecionar";
            this.barBtnSelecionarCliente.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSelecionarCliente.Glyph")));
            this.barBtnSelecionarCliente.Id = 0;
            this.barBtnSelecionarCliente.Name = "barBtnSelecionarCliente";
            this.barBtnSelecionarCliente.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnSelecionarCliente.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSelecionarCliente_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(696, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 481);
            this.barDockControlBottom.Size = new System.Drawing.Size(696, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 434);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(696, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 434);
            // 
            // XFrmClienteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 504);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "XFrmClienteView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XFrmInfoCliente_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCliFor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCliFor;
        private DevExpress.XtraGrid.Columns.GridColumn colidCliFor;
        private DevExpress.XtraGrid.Columns.GridColumn colNomeCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colcpfCnpj;
        private DevExpress.XtraGrid.Columns.GridColumn colRg;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barBtnSelecionarCliente;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}