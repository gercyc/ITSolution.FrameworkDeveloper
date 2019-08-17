namespace ITSolution.Framework.Web.Bacen
{
    partial class XFrmCambio
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
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.colMoeda = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colValorCompra = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colValorVenda = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bsCotacaoMonetaria = new System.Windows.Forms.BindingSource();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.colIdCotacaoMonetaria = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colDataCotacao = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colIdMoeda = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFonte1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdCotacaoMonetaria1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataCotacao1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorCompra1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorVenda1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdMoeda1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoeda1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFonte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGestorProprietario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomeAbreviado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomeCompleto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodicidade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnidadePadrao = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCotacaoMonetaria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // colMoeda
            // 
            this.colMoeda.AppearanceCell.Options.UseTextOptions = true;
            this.colMoeda.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colMoeda.AppearanceHeader.Options.UseTextOptions = true;
            this.colMoeda.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colMoeda.Caption = "%Moeda%";
            this.colMoeda.FieldName = "Moeda.NomeMoeda";
            this.colMoeda.Name = "colMoeda";
            this.colMoeda.Visible = true;
            this.colMoeda.VisibleIndex = 2;
            this.colMoeda.Width = 313;
            // 
            // colValorCompra
            // 
            this.colValorCompra.AppearanceCell.Options.UseTextOptions = true;
            this.colValorCompra.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colValorCompra.AppearanceHeader.Options.UseTextOptions = true;
            this.colValorCompra.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colValorCompra.Caption = "%Compra%";
            this.colValorCompra.DisplayFormat.FormatString = "n4";
            this.colValorCompra.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colValorCompra.FieldName = "ValorCompra";
            this.colValorCompra.Name = "colValorCompra";
            this.colValorCompra.Visible = true;
            this.colValorCompra.VisibleIndex = 0;
            this.colValorCompra.Width = 183;
            // 
            // colValorVenda
            // 
            this.colValorVenda.AppearanceCell.Options.UseTextOptions = true;
            this.colValorVenda.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colValorVenda.AppearanceHeader.Options.UseTextOptions = true;
            this.colValorVenda.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colValorVenda.Caption = "%Venda%";
            this.colValorVenda.DisplayFormat.FormatString = "n4";
            this.colValorVenda.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colValorVenda.FieldName = "ValorVenda";
            this.colValorVenda.Name = "colValorVenda";
            this.colValorVenda.Visible = true;
            this.colValorVenda.VisibleIndex = 1;
            this.colValorVenda.Width = 204;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bsCotacaoMonetaria;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(3, 26);
            this.gridControl1.MainView = this.tileView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1346, 419);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView1});
            // 
            // bsCotacaoMonetaria
            // 
            this.bsCotacaoMonetaria.DataSource = typeof(ITSolution.Framework.Web.Bacen.CotacaoMonetaria);
            // 
            // tileView1
            // 
            this.tileView1.Appearance.ItemFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tileView1.Appearance.ItemFocused.Options.UseBackColor = true;
            this.tileView1.Appearance.ItemNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(170)))), ((int)(((byte)(105)))));
            this.tileView1.Appearance.ItemNormal.Options.UseBackColor = true;
            this.tileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdCotacaoMonetaria,
            this.colDataCotacao,
            this.colValorCompra,
            this.colValorVenda,
            this.colIdMoeda,
            this.colMoeda});
            this.tileView1.GridControl = this.gridControl1;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsBehavior.Editable = false;
            this.tileView1.OptionsTiles.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(250, 130);
            this.tileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.tileView1.OptionsTiles.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            this.tileView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colIdMoeda, DevExpress.Data.ColumnSortOrder.Ascending)});
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            tileViewItemElement1.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement1.Column = this.colMoeda;
            tileViewItemElement1.Text = "colMoeda";
            tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            tileViewItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement2.Column = this.colValorCompra;
            tileViewItemElement2.Text = "colValorCompra";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement2.TextLocation = new System.Drawing.Point(80, 55);
            tileViewItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            tileViewItemElement3.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            tileViewItemElement3.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement3.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement3.Column = this.colValorVenda;
            tileViewItemElement3.Text = "colValorVenda";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            tileViewItemElement3.TextLocation = new System.Drawing.Point(80, -15);
            tileViewItemElement4.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            tileViewItemElement4.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            tileViewItemElement4.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement4.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement4.Column = null;
            tileViewItemElement4.Text = "Compra:";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement4.TextLocation = new System.Drawing.Point(0, 55);
            tileViewItemElement5.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            tileViewItemElement5.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            tileViewItemElement5.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement5.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement5.Column = null;
            tileViewItemElement5.Text = "Venda:";
            tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            tileViewItemElement5.TextLocation = new System.Drawing.Point(0, -15);
            this.tileView1.TileTemplate.Add(tileViewItemElement1);
            this.tileView1.TileTemplate.Add(tileViewItemElement2);
            this.tileView1.TileTemplate.Add(tileViewItemElement3);
            this.tileView1.TileTemplate.Add(tileViewItemElement4);
            this.tileView1.TileTemplate.Add(tileViewItemElement5);
            this.tileView1.ItemPress += new DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventHandler(this.tileView1_ItemPress);
            // 
            // colIdCotacaoMonetaria
            // 
            this.colIdCotacaoMonetaria.AppearanceCell.Options.UseTextOptions = true;
            this.colIdCotacaoMonetaria.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdCotacaoMonetaria.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdCotacaoMonetaria.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdCotacaoMonetaria.FieldName = "IdCotacaoMonetaria";
            this.colIdCotacaoMonetaria.Name = "colIdCotacaoMonetaria";
            // 
            // colDataCotacao
            // 
            this.colDataCotacao.AppearanceCell.Options.UseTextOptions = true;
            this.colDataCotacao.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDataCotacao.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataCotacao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDataCotacao.FieldName = "DataCotacao";
            this.colDataCotacao.Name = "colDataCotacao";
            this.colDataCotacao.Width = 121;
            // 
            // colIdMoeda
            // 
            this.colIdMoeda.AppearanceCell.Options.UseTextOptions = true;
            this.colIdMoeda.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdMoeda.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdMoeda.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdMoeda.Name = "colIdMoeda";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridControl2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1352, 730);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFonte1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1346, 20);
            this.panel1.TabIndex = 2;
            // 
            // lblFonte1
            // 
            this.lblFonte1.Location = new System.Drawing.Point(3, 6);
            this.lblFonte1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblFonte1.Name = "lblFonte1";
            this.lblFonte1.Size = new System.Drawing.Size(48, 13);
            this.lblFonte1.TabIndex = 2;
            this.lblFonte1.Text = "%fonte%";
            this.lblFonte1.Visible = false;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.bsCotacaoMonetaria;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl2.Location = new System.Drawing.Point(3, 449);
            this.gridControl2.MainView = this.gridView1;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1346, 279);
            this.gridControl2.TabIndex = 3;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdCotacaoMonetaria1,
            this.colDataCotacao1,
            this.colValorCompra1,
            this.colValorVenda1,
            this.colIdMoeda1,
            this.colMoeda1,
            this.colFonte,
            this.colFullName,
            this.colGestorProprietario,
            this.colNomeAbreviado,
            this.colNomeCompleto,
            this.colPeriodicidade,
            this.colShortName,
            this.colUnidadePadrao});
            this.gridView1.GridControl = this.gridControl2;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMoeda1, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDataCotacao1, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colIdCotacaoMonetaria1
            // 
            this.colIdCotacaoMonetaria1.AppearanceCell.Options.UseTextOptions = true;
            this.colIdCotacaoMonetaria1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdCotacaoMonetaria1.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdCotacaoMonetaria1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdCotacaoMonetaria1.FieldName = "IdCotacaoMonetaria";
            this.colIdCotacaoMonetaria1.Name = "colIdCotacaoMonetaria1";
            // 
            // colDataCotacao1
            // 
            this.colDataCotacao1.AppearanceCell.Options.UseTextOptions = true;
            this.colDataCotacao1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDataCotacao1.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataCotacao1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDataCotacao1.FieldName = "DataCotacao";
            this.colDataCotacao1.Name = "colDataCotacao1";
            this.colDataCotacao1.Visible = true;
            this.colDataCotacao1.VisibleIndex = 0;
            this.colDataCotacao1.Width = 70;
            // 
            // colValorCompra1
            // 
            this.colValorCompra1.AppearanceCell.Options.UseTextOptions = true;
            this.colValorCompra1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colValorCompra1.AppearanceHeader.Options.UseTextOptions = true;
            this.colValorCompra1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colValorCompra1.Caption = "Compra";
            this.colValorCompra1.FieldName = "ValorCompra";
            this.colValorCompra1.Name = "colValorCompra1";
            this.colValorCompra1.Visible = true;
            this.colValorCompra1.VisibleIndex = 1;
            this.colValorCompra1.Width = 74;
            // 
            // colValorVenda1
            // 
            this.colValorVenda1.AppearanceCell.Options.UseTextOptions = true;
            this.colValorVenda1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colValorVenda1.AppearanceHeader.Options.UseTextOptions = true;
            this.colValorVenda1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colValorVenda1.Caption = "Venda";
            this.colValorVenda1.FieldName = "ValorVenda";
            this.colValorVenda1.Name = "colValorVenda1";
            this.colValorVenda1.Visible = true;
            this.colValorVenda1.VisibleIndex = 2;
            this.colValorVenda1.Width = 74;
            // 
            // colIdMoeda1
            // 
            this.colIdMoeda1.AppearanceCell.Options.UseTextOptions = true;
            this.colIdMoeda1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdMoeda1.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdMoeda1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIdMoeda1.FieldName = "IdMoeda";
            this.colIdMoeda1.Name = "colIdMoeda1";
            // 
            // colMoeda1
            // 
            this.colMoeda1.AppearanceCell.Options.UseTextOptions = true;
            this.colMoeda1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colMoeda1.AppearanceHeader.Options.UseTextOptions = true;
            this.colMoeda1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colMoeda1.Caption = "Moeda";
            this.colMoeda1.FieldName = "Moeda.NomeMoeda";
            this.colMoeda1.Name = "colMoeda1";
            this.colMoeda1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colMoeda1.Visible = true;
            this.colMoeda1.VisibleIndex = 0;
            this.colMoeda1.Width = 80;
            // 
            // colFonte
            // 
            this.colFonte.AppearanceCell.Options.UseTextOptions = true;
            this.colFonte.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFonte.AppearanceHeader.Options.UseTextOptions = true;
            this.colFonte.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFonte.FieldName = "Fonte";
            this.colFonte.Name = "colFonte";
            this.colFonte.Visible = true;
            this.colFonte.VisibleIndex = 3;
            this.colFonte.Width = 80;
            // 
            // colFullName
            // 
            this.colFullName.AppearanceCell.Options.UseTextOptions = true;
            this.colFullName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFullName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFullName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 4;
            this.colFullName.Width = 180;
            // 
            // colGestorProprietario
            // 
            this.colGestorProprietario.AppearanceCell.Options.UseTextOptions = true;
            this.colGestorProprietario.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colGestorProprietario.AppearanceHeader.Options.UseTextOptions = true;
            this.colGestorProprietario.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colGestorProprietario.FieldName = "GestorProprietario";
            this.colGestorProprietario.Name = "colGestorProprietario";
            this.colGestorProprietario.Visible = true;
            this.colGestorProprietario.VisibleIndex = 5;
            this.colGestorProprietario.Width = 85;
            // 
            // colNomeAbreviado
            // 
            this.colNomeAbreviado.AppearanceCell.Options.UseTextOptions = true;
            this.colNomeAbreviado.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNomeAbreviado.AppearanceHeader.Options.UseTextOptions = true;
            this.colNomeAbreviado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNomeAbreviado.FieldName = "NomeAbreviado";
            this.colNomeAbreviado.Name = "colNomeAbreviado";
            this.colNomeAbreviado.Visible = true;
            this.colNomeAbreviado.VisibleIndex = 6;
            this.colNomeAbreviado.Width = 105;
            // 
            // colNomeCompleto
            // 
            this.colNomeCompleto.AppearanceCell.Options.UseTextOptions = true;
            this.colNomeCompleto.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNomeCompleto.AppearanceHeader.Options.UseTextOptions = true;
            this.colNomeCompleto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNomeCompleto.FieldName = "NomeCompleto";
            this.colNomeCompleto.Name = "colNomeCompleto";
            this.colNomeCompleto.Visible = true;
            this.colNomeCompleto.VisibleIndex = 7;
            this.colNomeCompleto.Width = 250;
            // 
            // colPeriodicidade
            // 
            this.colPeriodicidade.AppearanceCell.Options.UseTextOptions = true;
            this.colPeriodicidade.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPeriodicidade.AppearanceHeader.Options.UseTextOptions = true;
            this.colPeriodicidade.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPeriodicidade.FieldName = "Periodicidade";
            this.colPeriodicidade.Name = "colPeriodicidade";
            // 
            // colShortName
            // 
            this.colShortName.AppearanceCell.Options.UseTextOptions = true;
            this.colShortName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colShortName.AppearanceHeader.Options.UseTextOptions = true;
            this.colShortName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colShortName.FieldName = "ShortName";
            this.colShortName.Name = "colShortName";
            // 
            // colUnidadePadrao
            // 
            this.colUnidadePadrao.AppearanceCell.Options.UseTextOptions = true;
            this.colUnidadePadrao.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUnidadePadrao.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnidadePadrao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUnidadePadrao.FieldName = "UnidadePadrao";
            this.colUnidadePadrao.Name = "colUnidadePadrao";
            // 
            // XFrmCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "XFrmCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cotação Cambial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XFrmCambio_FormClosing);
            this.Shown += new System.EventHandler(this.XFrmCambio_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XFrmCambio_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCotacaoMonetaria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource bsCotacaoMonetaria;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl lblFonte1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colIdCotacaoMonetaria;
        private DevExpress.XtraGrid.Columns.TileViewColumn colDataCotacao;
        private DevExpress.XtraGrid.Columns.TileViewColumn colValorCompra;
        private DevExpress.XtraGrid.Columns.TileViewColumn colValorVenda;
        private DevExpress.XtraGrid.Columns.TileViewColumn colIdMoeda;
        private DevExpress.XtraGrid.Columns.TileViewColumn colMoeda;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIdCotacaoMonetaria1;
        private DevExpress.XtraGrid.Columns.GridColumn colDataCotacao1;
        private DevExpress.XtraGrid.Columns.GridColumn colValorCompra1;
        private DevExpress.XtraGrid.Columns.GridColumn colValorVenda1;
        private DevExpress.XtraGrid.Columns.GridColumn colIdMoeda1;
        private DevExpress.XtraGrid.Columns.GridColumn colMoeda1;
        private DevExpress.XtraGrid.Columns.GridColumn colFonte;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colGestorProprietario;
        private DevExpress.XtraGrid.Columns.GridColumn colNomeAbreviado;
        private DevExpress.XtraGrid.Columns.GridColumn colNomeCompleto;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodicidade;
        private DevExpress.XtraGrid.Columns.GridColumn colShortName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnidadePadrao;
    }
}