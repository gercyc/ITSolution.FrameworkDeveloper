namespace ITSolution.Framework.Beans.Forms
{
    partial class XFrmWebServiceCNPJ
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmWebServiceCNPJ));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewSerializable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDataSituacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSituacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBairro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogradouro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMunicipio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbertura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNaturezaJuridica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFantasia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCnpj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUltimaAtualizacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComplemento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEfr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMotivoSituacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSituacaoEspecial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataSituacaoEspecial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCapitalSocial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExtra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mEditJSON = new DevExpress.XtraEditors.MemoEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barEd = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barBtnSerialiar = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnOk = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSerializable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEditJSON.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridViewSerializable;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1020, 415);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSerializable});
            // 
            // gridViewSerializable
            // 
            this.gridViewSerializable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDataSituacao,
            this.colNome,
            this.colUf,
            this.colTelefone,
            this.colSituacao,
            this.colBairro,
            this.colLogradouro,
            this.colNumero,
            this.colCep,
            this.colMunicipio,
            this.colAbertura,
            this.colNaturezaJuridica,
            this.colFantasia,
            this.colCnpj,
            this.colUltimaAtualizacao,
            this.colStatus,
            this.colTipo,
            this.colComplemento,
            this.colEmail,
            this.colEfr,
            this.colMotivoSituacao,
            this.colSituacaoEspecial,
            this.colDataSituacaoEspecial,
            this.colCapitalSocial,
            this.colExtra});
            this.gridViewSerializable.GridControl = this.gridControl1;
            this.gridViewSerializable.Name = "gridViewSerializable";
            this.gridViewSerializable.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            this.gridViewSerializable.OptionsView.ColumnAutoWidth = false;
            // 
            // colDataSituacao
            // 
            this.colDataSituacao.FieldName = "DataSituacao";
            this.colDataSituacao.Name = "colDataSituacao";
            this.colDataSituacao.Visible = true;
            this.colDataSituacao.VisibleIndex = 0;
            // 
            // colNome
            // 
            this.colNome.FieldName = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.Visible = true;
            this.colNome.VisibleIndex = 1;
            // 
            // colUf
            // 
            this.colUf.FieldName = "Uf";
            this.colUf.Name = "colUf";
            this.colUf.Visible = true;
            this.colUf.VisibleIndex = 2;
            // 
            // colTelefone
            // 
            this.colTelefone.FieldName = "Telefone";
            this.colTelefone.Name = "colTelefone";
            this.colTelefone.Visible = true;
            this.colTelefone.VisibleIndex = 3;
            // 
            // colSituacao
            // 
            this.colSituacao.FieldName = "Situacao";
            this.colSituacao.Name = "colSituacao";
            this.colSituacao.Visible = true;
            this.colSituacao.VisibleIndex = 4;
            // 
            // colBairro
            // 
            this.colBairro.FieldName = "Bairro";
            this.colBairro.Name = "colBairro";
            this.colBairro.Visible = true;
            this.colBairro.VisibleIndex = 5;
            // 
            // colLogradouro
            // 
            this.colLogradouro.FieldName = "Logradouro";
            this.colLogradouro.Name = "colLogradouro";
            this.colLogradouro.Visible = true;
            this.colLogradouro.VisibleIndex = 6;
            // 
            // colNumero
            // 
            this.colNumero.FieldName = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 7;
            // 
            // colCep
            // 
            this.colCep.FieldName = "Cep";
            this.colCep.Name = "colCep";
            this.colCep.Visible = true;
            this.colCep.VisibleIndex = 8;
            // 
            // colMunicipio
            // 
            this.colMunicipio.FieldName = "Municipio";
            this.colMunicipio.Name = "colMunicipio";
            this.colMunicipio.Visible = true;
            this.colMunicipio.VisibleIndex = 9;
            // 
            // colAbertura
            // 
            this.colAbertura.FieldName = "Abertura";
            this.colAbertura.Name = "colAbertura";
            this.colAbertura.Visible = true;
            this.colAbertura.VisibleIndex = 10;
            // 
            // colNaturezaJuridica
            // 
            this.colNaturezaJuridica.FieldName = "NaturezaJuridica";
            this.colNaturezaJuridica.Name = "colNaturezaJuridica";
            this.colNaturezaJuridica.Visible = true;
            this.colNaturezaJuridica.VisibleIndex = 11;
            // 
            // colFantasia
            // 
            this.colFantasia.FieldName = "Fantasia";
            this.colFantasia.Name = "colFantasia";
            this.colFantasia.Visible = true;
            this.colFantasia.VisibleIndex = 12;
            // 
            // colCnpj
            // 
            this.colCnpj.FieldName = "Cnpj";
            this.colCnpj.Name = "colCnpj";
            this.colCnpj.Visible = true;
            this.colCnpj.VisibleIndex = 13;
            // 
            // colUltimaAtualizacao
            // 
            this.colUltimaAtualizacao.FieldName = "UltimaAtualizacao";
            this.colUltimaAtualizacao.Name = "colUltimaAtualizacao";
            this.colUltimaAtualizacao.Visible = true;
            this.colUltimaAtualizacao.VisibleIndex = 14;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 15;
            // 
            // colTipo
            // 
            this.colTipo.FieldName = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.Visible = true;
            this.colTipo.VisibleIndex = 16;
            // 
            // colComplemento
            // 
            this.colComplemento.FieldName = "Complemento";
            this.colComplemento.Name = "colComplemento";
            this.colComplemento.Visible = true;
            this.colComplemento.VisibleIndex = 17;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 18;
            // 
            // colEfr
            // 
            this.colEfr.FieldName = "Efr";
            this.colEfr.Name = "colEfr";
            this.colEfr.Visible = true;
            this.colEfr.VisibleIndex = 19;
            // 
            // colMotivoSituacao
            // 
            this.colMotivoSituacao.FieldName = "MotivoSituacao";
            this.colMotivoSituacao.Name = "colMotivoSituacao";
            this.colMotivoSituacao.Visible = true;
            this.colMotivoSituacao.VisibleIndex = 20;
            // 
            // colSituacaoEspecial
            // 
            this.colSituacaoEspecial.FieldName = "SituacaoEspecial";
            this.colSituacaoEspecial.Name = "colSituacaoEspecial";
            this.colSituacaoEspecial.Visible = true;
            this.colSituacaoEspecial.VisibleIndex = 21;
            // 
            // colDataSituacaoEspecial
            // 
            this.colDataSituacaoEspecial.FieldName = "DataSituacaoEspecial";
            this.colDataSituacaoEspecial.Name = "colDataSituacaoEspecial";
            this.colDataSituacaoEspecial.Visible = true;
            this.colDataSituacaoEspecial.VisibleIndex = 22;
            // 
            // colCapitalSocial
            // 
            this.colCapitalSocial.FieldName = "CapitalSocial";
            this.colCapitalSocial.Name = "colCapitalSocial";
            this.colCapitalSocial.Visible = true;
            this.colCapitalSocial.VisibleIndex = 23;
            // 
            // colExtra
            // 
            this.colExtra.FieldName = "Extra";
            this.colExtra.Name = "colExtra";
            this.colExtra.Visible = true;
            this.colExtra.VisibleIndex = 24;
            // 
            // mEditJSON
            // 
            this.mEditJSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mEditJSON.Location = new System.Drawing.Point(0, 0);
            this.mEditJSON.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mEditJSON.Name = "mEditJSON";
            this.mEditJSON.Size = new System.Drawing.Size(1020, 142);
            toolTipTitleItem1.Text = "Atualização de dados cadastrais da empresa";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Mantenha-se atualizado quando o assunto são os dados das empresas que se relacion" +
    "am com você";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.mEditJSON.SuperTip = superToolTip1;
            this.mEditJSON.TabIndex = 1;
            this.mEditJSON.ToolTip = "JSON de dados";
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
            this.barBtnSerialiar,
            this.barEd,
            this.barStaticItem1,
            this.barBtnOk});
            this.barManager1.MaxItemId = 4;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barEd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSerialiar),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnOk)});
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "CNPJ:";
            this.barStaticItem1.Id = 2;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barEd
            // 
            this.barEd.Caption = "barEditItem1";
            this.barEd.Edit = this.repositoryItemTextEdit1;
            this.barEd.EditWidth = 142;
            this.barEd.Id = 1;
            this.barEd.Name = "barEd";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barBtnSerialiar
            // 
            this.barBtnSerialiar.Caption = "Serializar";
            this.barBtnSerialiar.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnSerialiar.Glyph")));
            this.barBtnSerialiar.Id = 0;
            this.barBtnSerialiar.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.barBtnSerialiar.Name = "barBtnSerialiar";
            this.barBtnSerialiar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBtnSerialiar.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.barBtnSerialiar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSerialiar_ItemClick);
            // 
            // barBtnOk
            // 
            this.barBtnOk.Caption = "OK";
            this.barBtnOk.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnOk.Glyph")));
            this.barBtnOk.Id = 3;
            this.barBtnOk.Name = "barBtnOk";
            this.barBtnOk.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnOk_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1020, 59);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 622);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1020, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 59);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 563);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1020, 59);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 563);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 59);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.mEditJSON);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1020, 563);
            this.splitContainerControl1.SplitterPosition = 142;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // XFrmWebServiceCNPJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 647);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "XFrmWebServiceCNPJ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebService de Dados de CNPJ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSerializable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEditJSON.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSerializable;
        private DevExpress.XtraEditors.MemoEdit mEditJSON;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barBtnSerialiar;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn colDataSituacao;
        private DevExpress.XtraGrid.Columns.GridColumn colNome;
        private DevExpress.XtraGrid.Columns.GridColumn colUf;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefone;
        private DevExpress.XtraGrid.Columns.GridColumn colSituacao;
        private DevExpress.XtraGrid.Columns.GridColumn colBairro;
        private DevExpress.XtraGrid.Columns.GridColumn colLogradouro;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colCep;
        private DevExpress.XtraGrid.Columns.GridColumn colMunicipio;
        private DevExpress.XtraGrid.Columns.GridColumn colAbertura;
        private DevExpress.XtraGrid.Columns.GridColumn colNaturezaJuridica;
        private DevExpress.XtraGrid.Columns.GridColumn colFantasia;
        private DevExpress.XtraGrid.Columns.GridColumn colCnpj;
        private DevExpress.XtraGrid.Columns.GridColumn colUltimaAtualizacao;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colComplemento;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colEfr;
        private DevExpress.XtraGrid.Columns.GridColumn colMotivoSituacao;
        private DevExpress.XtraGrid.Columns.GridColumn colSituacaoEspecial;
        private DevExpress.XtraGrid.Columns.GridColumn colDataSituacaoEspecial;
        private DevExpress.XtraGrid.Columns.GridColumn colCapitalSocial;
        private DevExpress.XtraGrid.Columns.GridColumn colExtra;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem barEd;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barBtnOk;
    }
}