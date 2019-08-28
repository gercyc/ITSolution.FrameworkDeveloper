using System;
using ITSolution.Framework.ConnectionFactory;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Util;
using ITSolution.Framework.Validador;
using System.Threading.Tasks;
using ITSolution.Framework.GuiUtil;
using System.Windows.Forms;
using System.Data;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Common.BaseClasses.CommonEntities;

namespace ITSolution.Admin.Forms.ContextUtil
{
    public partial class XFrmAppConfig : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private bool rebootoption;
        private string lastServerName;
        private AbstractUser _user;

        public AppConfigIts AppConfig { get; private set; }

        #region Construtores

        public XFrmAppConfig()
        {
            InitializeComponent();
            txtUser.Focus();
            this.barBtnAppConfig.Caption = "Criar Conexão";

            this.txtConnectionName.Leave += new System.EventHandler(this.txtConnection_Leave);
            this.txtServerName.Leave += new System.EventHandler(this.txtConnection_Leave);
            this.txtUser.Leave += new System.EventHandler(this.txtConnection_Leave);
            this.txtPassword.Leave += new System.EventHandler(this.txtConnection_Leave);
            this.cbDatabase.EditValueChanged += new System.EventHandler(this.txtConnection_Leave);
            this.lastServerName = "";
            //this.cbConnections.EditValueChanged += new System.EventHandler(this.txtConnection_Leave);
        }

        public XFrmAppConfig(AbstractUser user, AppConfigIts app, bool rebootoption = false) : this()
        {
            this._user = user;
            this.rebootoption = rebootoption;
            loadAppXml(AppConfigManager.Configuration.ConnectionConfigPath);
        }

        public XFrmAppConfig(string xmlFile) : this()
        {
            loadAppXml(xmlFile);

        }

        #endregion

        #region Metodos

        private void loadAppXml(string xmlFile)
        {

            this.barBtnAppConfig.Caption = "Alter Connection";


            AppConfigManager.Configuration.Load(xmlFile);

            this.cbConnections.Properties.Items.Clear();

            var connections = AppConfigManager.Configuration.AppConfigList;
            if (AppConfigManager.Configuration.IsReadOnly)
            {
                this.AppConfig = AppConfigManager.Configuration.AppConfig;

                this.lblXmlConnections.Visible = true;
                this.cbConnections.Visible = true;
                this.cbConnections.Properties.Items.AddRange(connections);
                this.cbConnections.Properties.ReadOnly = false;
                this.cbConnections.SetSelectItem(this.AppConfig);
                indexarDados(this.AppConfig);
            }
            else
            {
                this.cbConnections.Properties.ReadOnly = true;

                XMessageIts.Mensagem("Não foram encontradas conexões no arquivo .xml");
            }
        }

        private AppConfigIts indexarDados()
        {
            string serverName = txtServerName.Text;
            string connectionName = txtConnectionName.Text;
            string user = txtUser.Text;
            string pw = txtPassword.Text;
            string database = "" + cbDatabase.SelectedItem;
            //string integratedSecurity = cbAuthentication.SelectedIndex == 0
            //   ? "true"
            //   : "false"
            if (barToggleCriptografar.Checked)
                //criptografa a senha
                pw = ASCIIEncodingIts.Coded(pw);

            return new AppConfigIts(connectionName, serverName, user, pw, database);
        }

        private void indexarDados(AppConfigIts app)
        {
            txtServerName.Text = app.ServerName;
            txtConnectionName.Text = app.ConnectionName;
            txtUser.Text = app.User;
            txtPassword.Text = app.Password;

            if (app.User.IsNullOrEmpty())
                cbAuthentication.SelectedIndex = 0;
            else
                cbAuthentication.SelectedIndex = 1;

            if (!app.Database.IsNullOrEmpty())
            {
                cbDatabase.Properties.Items.Clear();
                cbDatabase.Properties.Items.Add(app.Database);
                cbDatabase.SelectedIndex = 0;
                radioDatabase.Checked = true;
            }
            else
            {
                cbDatabase.SelectedIndex = -1;
            }

        }

        private ConnectionFactoryIts createConnection()
        {
            var appConfig = indexarDados();

            if (barToggleCriptografar.Checked)
                appConfig.Password = ASCIIEncodingIts.Decoded(appConfig.Password);

            appConfig.RebuildConnectionString();

            return new ConnectionFactoryIts(appConfig.ConnectionString);
        }

        private bool testeConnection(AppConfigIts appCfg)
        {
            if (cbAuthentication.SelectedIndex == 1 && appCfg.User.IsNullOrEmpty())
            {
                XMessageIts.Advertencia("Usuário não informado !");
                return false;

            }
            if (cbAuthentication.SelectedIndex == 1 && appCfg.Password.IsNullOrEmpty())
            {
                XMessageIts.Advertencia("Senha não informada !");
                return false;

            }
            if (ValidadorDTO.ValidateWarningAll(appCfg))
            {
                var con = createConnection();
                //terminar
                if (con.OpenConnection())
                {
                    XMessageIts.Mensagem("Conexão bem sucedida !");
                    con.CloseConnection();
                    barBtnAppConfig.Enabled = true;
                    barBtnAddConnection.Enabled = true;
                    return true;
                }
            }
            barBtnAddConnection.Enabled = false;
            barBtnAppConfig.Enabled = false;
            return false;

        }

        private void addConnection(AppConfigIts app)
        {
            if (!AppConfigManager.Configuration.Contains(app))
            {
                AppConfigManager.Configuration.Add(app);
                this.Dispose();
            }
            else
            {
                XMessageIts.Advertencia("Já existe uma conexão nomeada \"" + app.ConnectionName + "\"", "Aviso");
            }
        }
        #endregion

        #region Eventos

        private void txtConnection_Leave(object sender, EventArgs e)
        {
            barBtnAppConfig.Enabled = false;
        }

        private void barBtnAppConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var app = indexarDados();
            if (this.AppConfig == null)
                addConnection(app);
            else
            {

                if (AppConfigManager.Configuration.Alter(app))
                {
                    bool reboot = true;
                    if (rebootoption)
                    {
                        if(_user != null)
                        {
                            if (_user.NomeUtilizador == "admin" || _user.NomeUtilizador == "filipe")
                                reboot = false;
                        }
                        //permissao para reboot
                        if (reboot)
                        {
                            MessageBoxTick.Show("Conexão \"" + app.ConnectionName + "\" configurada com sucesso.\n" +
                                "Sua aplicação será reiniciada !",
                                "!!! Atenção !!!", 5);

                            Application.Restart();
                        }
                    }
                    else
                    {
                        XMessageIts.Mensagem("Conexão \"" + app.ConnectionName + "\" configurada com sucesso !", "Aviso");

                    }
                    this.Dispose();
                }
            }
        }

        private void barBtnAddConnection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.AppConfig = null;
            indexarDados(new AppConfigIts());
            cbConnections.Visible = false;
            txtConnectionName.Focus();
            barBtnAppConfig.Caption = "Create Connection";
            lblXmlConnections.Visible = false;
        }

        private void barBtnTestarConexao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            testeConnection(indexarDados());
        }

        private void barBtnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.AppConfig = null;
            this.Dispose();

        }

        private void radioDatabase_CheckedChanged(object sender, EventArgs e)
        {
            cbDatabase.ReadOnly = false;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioServerName.SelectedIndex == 1)
            {
                this.txtServerName.Text = RedeUtil.GetHostName();
            }
            else if (radioServerName.SelectedIndex == 2)
            {
                this.txtServerName.Text = RedeUtil.GetLocalIPAddress();
            }
        }

        private void txtServerName_Leave(object sender, EventArgs e)
        {
            string server = txtServerName.Text;
            if (!server.IsNullOrEmpty() && !lastServerName.Equals(server))
            {
                this.lastServerName = server;

                Task.Run(() => refreshDatabase());
            }
        }

        private void cbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbAuthentication.SelectedIndex == 0)
            {
                this.txtUser.Text = "";
                this.txtUser.ReadOnly = true;
                this.txtPassword.Text = "";
                this.txtPassword.ReadOnly = true;
            }
            else
            {
                this.txtUser.ReadOnly = false;
                this.txtPassword.ReadOnly = false;
            }

        }

        private void barBtnLoadConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (openFileAppXml.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string xmlFile = openFileAppXml.FileName;

                if (!xmlFile.ToLower().EndsWith(".xml"))
                {
                    XMessageIts.Advertencia("Selecione o arquivo de configuração .xml");
                }
                else if (FileManagerIts.IsEmpty(xmlFile))
                {
                    XMessageIts.Erro("Arquivo de configuração está vazio.");
                }
                else
                {
                    loadAppXml(xmlFile);
                }
            }
        }

        private void cbConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            object app = cbConnections.SelectedItem;
            if (app != null)
            {
                this.AppConfig = app as AppConfigIts;
                indexarDados(this.AppConfig);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Task.Run(() => refreshDatabase());
        }

        private void cbDatabase_DoubleClick(object sender, EventArgs e)
        {
            if (cbDatabase.Properties.Items.Count == 0)
                btnRefresh_Click(null, null);
        }

        private void refreshDatabase()
        {
            //nao funciona no azure melhorar isso depois
            try
            {

                cbDatabase.BeginInvoke(new Action(() =>
                {
                    cbDatabase.Text = "Procurando ...";

                }));

                var databases = loadDatabase();

                //Task<DataTable> datasources = databases.ContinueWith((i) => loadDatabaseDetails());
                //datasources.Wait();

                cbDatabase.BeginInvoke(new Action(() =>
                {
                    cbDatabase.ReadOnly = false;
                    cbDatabase.Properties.Items.AddRange(databases);
                    //lookUpEdit1.Properties.DataSource = datasources.Result;

                    if (databases.Length > 1)
                        cbDatabase.Text = "Selecione";
                    else
                        cbDatabase.SelectedIndex = 0;
                }));


                //if (this.InvokeRequired)
                //{
                //    this.Invoke(new MethodInvoker(delegate
                //    {
                //    }));

                //}

            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionMessage(ex);
            }
        }

        private string[] loadDatabase()
        {
            using (var connection = createConnection())
            {
                return connection.DataBases;
            }

        }

        private DataTable loadDatabaseDetails()
        {
            using (var connection = createConnection())
            {
                return ConnectionFactoryIts.GetDataSources();
            }
        }

        #endregion


    }
}