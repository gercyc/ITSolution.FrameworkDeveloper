namespace ITSolution.Scheduler.Forms
{
    partial class XFrmTaskCentral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XFrmTaskCentral));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNewTask = new DevExpress.XtraBars.BarButtonItem();
            this.btnDetTarefa = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintReportTask = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoverTarefa = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnStartExec = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControlTasks = new DevExpress.XtraGrid.GridControl();
            this.iTSSCHEDULERTASKBindingSource = new System.Windows.Forms.BindingSource();
            this.gridViewTasks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDtCriacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescricaoTarefa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaskStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDtInicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDtTermino = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTSSCHEDULERTASKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnNewTask,
            this.btnDetTarefa,
            this.btnPrintReportTask,
            this.btnRefresh,
            this.btnRemoverTarefa,
            this.btnCancel,
            this.btnStartExec});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(747, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnNewTask
            // 
            this.btnNewTask.Caption = "Nova tarefa";
            this.btnNewTask.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNewTask.Glyph")));
            this.btnNewTask.Id = 1;
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNewTask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewTask_ItemClick);
            // 
            // btnDetTarefa
            // 
            this.btnDetTarefa.Caption = "Detalhes da tarefa";
            this.btnDetTarefa.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDetTarefa.Glyph")));
            this.btnDetTarefa.Id = 2;
            this.btnDetTarefa.Name = "btnDetTarefa";
            this.btnDetTarefa.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDetTarefa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDetTarefa_ItemClick);
            // 
            // btnPrintReportTask
            // 
            this.btnPrintReportTask.Caption = "Relatório de execução";
            this.btnPrintReportTask.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrintReportTask.Glyph")));
            this.btnPrintReportTask.Id = 3;
            this.btnPrintReportTask.Name = "btnPrintReportTask";
            this.btnPrintReportTask.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Atualizar";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 4;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnRemoverTarefa
            // 
            this.btnRemoverTarefa.Caption = "Remover tarefa";
            this.btnRemoverTarefa.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRemoverTarefa.Glyph")));
            this.btnRemoverTarefa.Id = 5;
            this.btnRemoverTarefa.Name = "btnRemoverTarefa";
            this.btnRemoverTarefa.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRemoverTarefa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoverTarefa_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Suspender execução";
            this.btnCancel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancel.Glyph")));
            this.btnCancel.Id = 6;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // btnStartExec
            // 
            this.btnStartExec.Caption = "Iniciar execução";
            this.btnStartExec.Glyph = ((System.Drawing.Image)(resources.GetObject("btnStartExec.Glyph")));
            this.btnStartExec.Id = 7;
            this.btnStartExec.Name = "btnStartExec";
            this.btnStartExec.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnStartExec.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStartExec_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Ferramentas";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNewTask);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnStartExec);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCancel);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDetTarefa);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPrintReportTask);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRemoverTarefa);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 380);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(747, 31);
            // 
            // gridControlTasks
            // 
            this.gridControlTasks.DataSource = this.iTSSCHEDULERTASKBindingSource;
            this.gridControlTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTasks.Location = new System.Drawing.Point(0, 143);
            this.gridControlTasks.MainView = this.gridViewTasks;
            this.gridControlTasks.MenuManager = this.ribbon;
            this.gridControlTasks.Name = "gridControlTasks";
            this.gridControlTasks.Size = new System.Drawing.Size(747, 237);
            this.gridControlTasks.TabIndex = 2;
            this.gridControlTasks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTasks});
            // 
            // iTSSCHEDULERTASKBindingSource
            // 
            this.iTSSCHEDULERTASKBindingSource.DataSource = typeof(ITSolution.Scheduler.EntidadesBd.TaskIts);
            // 
            // gridViewTasks
            // 
            this.gridViewTasks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDtCriacao,
            this.colDescricaoTarefa,
            this.colTaskStatus,
            this.colDtInicio,
            this.colDtTermino});
            this.gridViewTasks.GridControl = this.gridControlTasks;
            this.gridViewTasks.Name = "gridViewTasks";
            this.gridViewTasks.OptionsBehavior.Editable = false;
            this.gridViewTasks.OptionsView.ShowGroupPanel = false;
            // 
            // colDtCriacao
            // 
            this.colDtCriacao.Caption = "Criada em";
            this.colDtCriacao.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colDtCriacao.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDtCriacao.FieldName = "DtCriacao";
            this.colDtCriacao.Name = "colDtCriacao";
            this.colDtCriacao.Visible = true;
            this.colDtCriacao.VisibleIndex = 0;
            this.colDtCriacao.Width = 112;
            // 
            // colDescricaoTarefa
            // 
            this.colDescricaoTarefa.Caption = "Descrição da tarefa";
            this.colDescricaoTarefa.FieldName = "DescricaoTarefa";
            this.colDescricaoTarefa.Name = "colDescricaoTarefa";
            this.colDescricaoTarefa.Visible = true;
            this.colDescricaoTarefa.VisibleIndex = 3;
            this.colDescricaoTarefa.Width = 259;
            // 
            // colTaskStatus
            // 
            this.colTaskStatus.Caption = "Status da execução";
            this.colTaskStatus.FieldName = "StatusTask";
            this.colTaskStatus.Name = "colTaskStatus";
            this.colTaskStatus.Visible = true;
            this.colTaskStatus.VisibleIndex = 4;
            this.colTaskStatus.Width = 119;
            // 
            // colDtInicio
            // 
            this.colDtInicio.Caption = "Início execução";
            this.colDtInicio.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colDtInicio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDtInicio.FieldName = "DtInicio";
            this.colDtInicio.Name = "colDtInicio";
            this.colDtInicio.Visible = true;
            this.colDtInicio.VisibleIndex = 1;
            this.colDtInicio.Width = 118;
            // 
            // colDtTermino
            // 
            this.colDtTermino.Caption = "Término execução";
            this.colDtTermino.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colDtTermino.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDtTermino.FieldName = "DtTermino";
            this.colDtTermino.Name = "colDtTermino";
            this.colDtTermino.Visible = true;
            this.colDtTermino.VisibleIndex = 2;
            this.colDtTermino.Width = 120;
            // 
            // XFrmTaskCentral
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 411);
            this.Controls.Add(this.gridControlTasks);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "XFrmTaskCentral";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Gerenciador de Tarefas";
            this.Shown += new System.EventHandler(this.XFrmTaskCentral_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTSSCHEDULERTASKBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.GridControl gridControlTasks;
        private System.Windows.Forms.BindingSource iTSSCHEDULERTASKBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTasks;
        private DevExpress.XtraGrid.Columns.GridColumn colDtInicio;
        private DevExpress.XtraGrid.Columns.GridColumn colDtTermino;
        private DevExpress.XtraGrid.Columns.GridColumn colDescricaoTarefa;
        private DevExpress.XtraGrid.Columns.GridColumn colTaskStatus;
        private DevExpress.XtraBars.BarButtonItem btnNewTask;
        private DevExpress.XtraBars.BarButtonItem btnDetTarefa;
        private DevExpress.XtraBars.BarButtonItem btnPrintReportTask;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnRemoverTarefa;
        private DevExpress.XtraGrid.Columns.GridColumn colDtCriacao;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarButtonItem btnStartExec;
    }
}