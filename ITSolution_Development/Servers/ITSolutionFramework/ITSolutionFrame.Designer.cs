namespace ITSolutionFramework
{
    partial class ITSolutionFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ITSolutionFrame));
            this.taskIcon = new System.Windows.Forms.NotifyIcon();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.itsServerInfoBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTypedClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInstance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsOnline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUrl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itsServerInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // taskIcon
            // 
            this.taskIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("taskIcon.Icon")));
            this.taskIcon.Text = "notifyIcon1";
            this.taskIcon.Visible = true;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.itsServerInfoBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 20);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(655, 241);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // itsServerInfoBindingSource
            // 
            this.itsServerInfoBindingSource.DataSource = typeof(ITSolution.Framework.Common.BaseClasses.ItsServerInfo);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTypedClass,
            this.colInstance,
            this.colIsOnline,
            this.colHost,
            this.colUrl,
            this.colMessage});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            // 
            // colTypedClass
            // 
            this.colTypedClass.FieldName = "TypedClass";
            this.colTypedClass.Name = "colTypedClass";
            this.colTypedClass.Visible = true;
            this.colTypedClass.VisibleIndex = 0;
            // 
            // colInstance
            // 
            this.colInstance.FieldName = "Instance";
            this.colInstance.Name = "colInstance";
            this.colInstance.Visible = true;
            this.colInstance.VisibleIndex = 1;
            // 
            // colIsOnline
            // 
            this.colIsOnline.FieldName = "IsOnline";
            this.colIsOnline.Name = "colIsOnline";
            this.colIsOnline.Visible = true;
            this.colIsOnline.VisibleIndex = 2;
            // 
            // colHost
            // 
            this.colHost.FieldName = "Host";
            this.colHost.Name = "colHost";
            this.colHost.Visible = true;
            this.colHost.VisibleIndex = 3;
            // 
            // colUrl
            // 
            this.colUrl.FieldName = "Url";
            this.colUrl.Name = "colUrl";
            this.colUrl.Visible = true;
            this.colUrl.VisibleIndex = 4;
            // 
            // colMessage
            // 
            this.colMessage.FieldName = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 38);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(659, 263);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Servidores Online";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(610, 308);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(61, 23);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Trace";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(14, 308);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(590, 122);
            this.memoEdit1.TabIndex = 6;
            // 
            // ITSolutionFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 442);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupControl1);
            this.Name = "ITSolutionFrame";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itsServerInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon taskIcon;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.BindingSource itsServerInfoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTypedClass;
        private DevExpress.XtraGrid.Columns.GridColumn colInstance;
        private DevExpress.XtraGrid.Columns.GridColumn colIsOnline;
        private DevExpress.XtraGrid.Columns.GridColumn colHost;
        private DevExpress.XtraGrid.Columns.GridColumn colUrl;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
    }
}

