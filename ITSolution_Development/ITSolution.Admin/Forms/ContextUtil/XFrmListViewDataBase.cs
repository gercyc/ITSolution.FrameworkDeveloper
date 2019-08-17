using System;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSolution.Framework.ConnectionFactory.SQLServer;
using ITSolution.Framework.ConnectionFactory;
using ITSolution.Framework.Entities;
using System.Data.SqlClient;

namespace ITSolution.Admin.Forms.ContextUtil
{
    /// <summary>
    /// Lista todos os bancos locais
    /// </summary>
    public partial class XFrmListViewDataBase : DevExpress.XtraEditors.XtraForm
    {

        public string DatabaseName { get; set; }
        public bool IsSelectedDatabase { get; private set; }
        private AppConfigIts app;

        #region Construtores

        public XFrmListViewDataBase(AppConfigIts app)
        {
            InitializeComponent();
            this.ActiveControl = this.cbDatabase;

            this.app = app;

            this.IsSelectedDatabase = false;

        }

        #endregion

        #region Metodos 

        public void Run()
        {
            //Show();
            this.ShowDialog();
        }


        #endregion

        #region Eventos
        private void btnSetDatabase_Click(object sender, EventArgs e)
        {
            var o = cbDatabase.SelectedItem;

            if (o != null)
            {
                this.DatabaseName = o.ToString();
                this.Dispose();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void XFrmListViewDataBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancelar_Click(null, null);
            else if (e.KeyCode == Keys.Enter)
                btnSetDatabase_Click(null, null);
        }


        private void XFrmListViewDataBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.DatabaseName))
                this.IsSelectedDatabase = true;


        }

        private async void XFrmListViewDataBase_Load(object sender, EventArgs e)
        {
            await Task.Run(() => loadDatabase());


        }
        #endregion Eventos

        private void loadDatabase()
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    var dbs = new ConnectionFactoryIts(app.ConnectionString).DataBases;
                    this.cbDatabase.Properties.Items.Clear();
                    this.cbDatabase.Properties.Items.AddRange(dbs);
                    this.cbDatabase.ShowPopup();
                }));
            }
            catch (SqlException)
            {

            }
        }

    }
}
