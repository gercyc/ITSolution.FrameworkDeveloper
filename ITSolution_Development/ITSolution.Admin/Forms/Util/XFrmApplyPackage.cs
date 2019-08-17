using ITSolution.Framework.ConnectionFactory;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSolution.Admin.Entidades.DaoManager;
using ITSolution.Framework.ConnectionFactory.SQLServer;
using ITSolution.Framework.GuiUtil;
using ITSolution.Framework.Listeners;
using ITSolution.Admin.Entidades.EntidadesBd;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Entities;
using ITSolution.Admin.Entidades.TaskManager;
using ITSolution.Framework.Dao.Contexto;

//http://www.devmedia.com.br/backgrounworker-e-progressbar-exibindo-uma-barra-de-progresso-em-c/32127

namespace ITSolution.Admin.Forms.Util
{

    public partial class XFrmApplyPackage : DevExpress.XtraEditors.XtraForm
    {
        private Task _taskApply;
        private TaskUpdateManager _taskManager;
        private CancellationTokenSource _tokenSource;
        private Package _pacote;
        //Diretorio que receberá as atualizações 
        private string _installDir;
        private bool _containsSql;
        private bool _containsDll;
        //diretorio temporario caso o pkg seja um .zip 
        private string _resourceDir;
        private AppConfigIts _appConfig;

        // Declare a delegate type for processing a log string
        private delegate void TaskLogStringDelegate(string log);
        // Declare a delegate type for processing a update log
        private delegate void TaskLogUpdateDelegate();
        // Declare a delegate type for processing a package
        private delegate void TaskLogExceptionDelegate(Exception ex);

        public XFrmApplyPackage()
        {
            InitializeComponent();
            init();
        }

        public XFrmApplyPackage(Package package) : this()
        {
            this.txtUpdateFile.Text = "Loading : {Package} " + package.IdPacote;
            this.wizardControl1.SetNextPage();
            loadPackage(package);
        }

        #region Metodos

        private void init()
        {
            //new WizardFocusButtonNext(this.wizardControl1).AddSelectedPageChanged();

            this.wizardControl1.EnableSelectedPageChanged();
            scintilla.ConfigureHighlightingSql();
            _taskManager = new TaskUpdateManager();
            _tokenSource = new CancellationTokenSource();
            //utiliza os dados do arquivo existente
            _appConfig = AppConfigManager.Configuration.AppConfig;
            this.ActiveControl = txtUpdateFile;
            txtUpdateFile.Focus();
            progressBarControl1.Properties.Step = 1;
            this.txtServerName.Text = _appConfig.ServerName;

            progressBarControl1.PerformStep();
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;

            if (_appConfig.ServerName.Equals("(local)"))
            {
                this.cbDatabase.Properties.Items.AddRange(new ConnectionLocalSql().DataBases);
                this.cbDatabase.SelectedItem = _appConfig.Database;
            }
            else
            {
                this.cbDatabase.Properties.Items.Add(_appConfig.Database);
                this.cbDatabase.SelectedIndex = 0;
            }

            if (!_appConfig.User.IsNullOrEmpty())
            {
                this.txtUser.Text = _appConfig.User;
                this.chAutenticacao.Checked = true;
            }

            if (!_appConfig.Password.IsNullOrEmpty())
            {
                this.txtPwd.Text = _appConfig.Password;
            }

        }

        private void loadPackage(Package pacote)
        {
            this._pacote = pacote;
            this.wizardControl1.SelectedPageIndex = 1;
            try
            {
                groupControlInfoPackage.Visible = true;

                if (pacote.DataPublicacao.HasValue)
                {

                    lbDtPublish.Text = pacote.DataPublicacao.Value.ToShortDateString();
                    labelControl6.Text = pacote.NumeroPacote;
                    memoEditDesc.Text = pacote.Descricao;


                    if (pacote.Anexos.Any(a => a.Extensao == ".zip"))
                    {
                        var firstPkg = pacote.Anexos.FirstOrDefault();
                        string zipName = firstPkg.FileName;
                        //crie um temporario para receber os dados do pacote
                        this._resourceDir = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(zipName));
                        FileManagerIts.DeleteDirectory(_resourceDir);
                        FileManagerIts.CreateDirectory(_resourceDir);

                        try
                        {
                            //arquivo zip
                            string zipFile = Path.Combine(Path.GetTempPath(), zipName);

                            //gera o zip em disco
                            FileManagerIts.WriteBytesToFile(zipFile, firstPkg.DataFile);

                            //extrai os dados pro temporario
                            ZipUtil.ExtractToDirectory(zipFile, this._resourceDir);
                            //todos os arquivos
                            foreach (string item in FileManagerIts.ToFiles(this._resourceDir, new string[] { ".sql" }, true))
                            {
                                if (item.EndsWith(".sql"))
                                    _containsSql = true;
                                else if (item.EndsWith(".dll"))
                                    _containsDll = true;
                            }
                            //ja extrai o pacote e nao preciso dele no disco, os dados ja foram extraidos
                            FileManagerIts.DeleteFile(zipFile);
                        }
                        catch (Exception ex)
                        {
                            string msg = "Falha na verificação de integridade do pacote.";
                            XMessageIts.ExceptionMessageDetails(ex, msg);
                            LoggerUtilIts.GenerateLogs(ex, msg);
                        }

                    }
                    else
                    {
                        int countSql = pacote.Anexos.Count(a => a.Extensao == ".sql");
                        int countDll = pacote.Anexos.Count(a => a.Extensao == ".dll");


                        this._containsSql = countSql > 0;
                        this._containsDll = countDll > 0;
                    }
                    this.pnlSql.Visible = _containsSql;

                    if (_containsDll)
                    {
                        this.pnlDlls.Visible = true;
                        detectInstallDir();
                        //this.groupControlInfoPackage.Location = new Point(17, 251);
                        //this.groupControlInfoPackage.Size = new Size(806, 242);
                    }
                    else
                    {
                        this.pnlDlls.Visible = false;
                        //this.groupControlInfoPackage.Location = new Point(17, 159);
                        //this.groupControlInfoPackage.Size = new Size(806, 344);
                    }
                    wizardPage1.AllowNext = true;
                }
                else
                {
                    XMessageIts.Erro("O pacote selecionado não foi publicado e não pode ser aplicado.");
                }
            }
            catch (Exception ex)
            {
                string msg = "O pacote de atualização informado é inválido!"
                             + "\n\nContate o administrador para aplicar atualização.";

                XMessageIts.ExceptionMessageDetails(ex, msg, "Atenção");

                LoggerUtilIts.GenerateLogs(ex, msg);
            }


        }

        private ConnectionFactoryIts createConnection()
        {
            string serverName = txtServerName.Text;

            string database = cbDatabase.SelectedItem != null
                ? cbDatabase.SelectedItem.ToString() : "";
            string user = txtUser.Text;
            string pw = txtPwd.Text;

            this._appConfig = new AppConfigIts(_appConfig.ConnectionName, serverName, user, pw, database);

            return new ConnectionFactoryIts(_appConfig.ConnectionString);

        }

        private async void runTask()
        {
            //define o stilo padrao do progressbar
            //progressBar1.Style = ProgressBarStyle.Blocks;
            progressBarControl1.Increment(0);

            //limpa o texto
            scintilla.Text = "";

            this._tokenSource = new CancellationTokenSource();

            //desabilita os botões enquanto a tarefa é executada
            this.wizardPage2.AllowBack = false;
            //nao deixe avançar
            this.wizardPage2.AllowNext = false;
            //nao deixe cancelar
            this.wizardPage2.AllowCancel = false;

            //nao deixe selecionar outro pacote
            this.btnSelecionar.Enabled = false;
            var factory = Task.Factory;

            _taskApply = new Task(() =>
            {

                if (_containsSql)
                    if (chRoolbackTransaction.Checked)
                        executeDDL();
                    else
                        executeDDL_NON_TSQL();

                if (_containsDll)
                    updateDLLs();

            });

            await factory.StartNew(() => _taskApply.Start());

            //executa o processo de forma assincrona.
            backgroundWorker1.RunWorkerAsync();

        }

        //Estou considerando que o pacote .zip é um pacote com dlls
        private void updateDLLs()
        {
            try
            {
                //pkg do arquivo zip
                var pkg = this._pacote.Anexos.FirstOrDefault();

                //nome do arquivo zip
                string zipResource = pkg.FileName;

                //extraindo atualização
                taskLog("Iniciando atualização: " + zipResource);

                if (Directory.Exists(_resourceDir))
                {
                    zipResource = _resourceDir;
                }
                else
                {
                    //raiz da instalação
                    var raiz = Path.GetPathRoot(_installDir);

                    //garante que o root de instalação e atualização sejam são iguais
                    //a atualização sera extraida no mesmo o root "=> Volume do disco Ex: C:
                    //Deve ser o mesmo root onde esta a instalação do programa
                    string resourceDir = Path.Combine(Path.GetPathRoot(raiz), "ite_package_update_" + Guid.NewGuid());

                    //cria o temporario para receber a atualização
                    FileManagerIts.CreateDirectory(resourceDir);

                    //agora eu tenho um diretorio entao gere um arquivo .zip
                    zipResource = resourceDir + "\\" + zipResource;

                    //gera o zip em disco
                    FileManagerIts.WriteBytesToFile(zipResource, pkg.DataFile);

                    //extrai as atualizações pra um temporario
                    ZipUtil.ExtractToDirectory(zipResource, resourceDir);
                }

                taskLog("Salvando instalação atual ...");
                //garante que exista somente um .bak 
                FileManagerIts.DeleteDirectory(_installDir + ".bak");

                //faz a copia o da instalaçao atual
                FileManagerIts.DirectoryCopy(_installDir, _installDir + ".bak");

                taskLog("Diretório pronto para receber atualização ...");

                taskLog("Atualizando diretórios e dlls ... ");

                Task.Run(new Action(() =>
                {

                    foreach (var f in new FileManagerIts().ToFilesRecursive(_resourceDir))
                    {
                        //vo mostrar so o nome o temporario q gerei nao eh importante
                        taskLog("Atualizando: " + Path.GetFileName(f));
                    }
                }));

                //ilustrar dps
                _taskManager.UpdateSoftware(_resourceDir, _installDir);

                //apague o temporário
                FileManagerIts.DeleteDirectory(_resourceDir);

            }
            catch (Exception ex)
            {
                try
                {
                    cancelation();

                    taskLog("Falha no pacote de atualizações");
                    taskLog(ex.Message);
                    LoggerUtilIts.ShowExceptionLogs(ex, this);
                }

                catch (OperationCanceledException oc)
                {
                    Console.WriteLine("Operação cancelada=> " + oc.Message);
                }
            }
        }

        private List<AnexoPackage> getQueriesSql()
        {
            var sqls = new List<AnexoPackage>();

            if (Directory.Exists(_resourceDir))
            {
                //de tudo .sql q esta la dentro
                var sqlFiles = FileManagerIts.ToFiles(_resourceDir, new string[] { ".sql" }, true);

                foreach (var item in sqlFiles)
                {
                    sqls.Add(new AnexoPackage(item));
                }
            }
            else
            {
                //se nao existe entao olhe pros anexos
                sqls = this._pacote.Anexos.Where(a => a.Extensao == ".sql")
                            .ToList();
            }
            return sqls;
        }

        private void executeDDL()
        {
            try
            {
                //eventos a serem disparados
                TaskLogStringDelegate taskLogDelegate = new TaskLogStringDelegate(taskLog);
                TaskLogExceptionDelegate taskLogExceptionDelegate = new TaskLogExceptionDelegate(addPkgError);
                TaskLogUpdateDelegate taskLogUpdateDelegate = new TaskLogUpdateDelegate(addPkgInfo);

                using (var connection = createConnection())
                {

                    var sqls = getQueriesSql();

                    connection.BeginTransaction();

                    foreach (var sql in sqls)
                    {
                        taskLog("Script file: " + sql.FileName);
                        taskLog("'============================================================================'");
                        string querySql = StringUtilIts.GetStringFromBytes(sql.DataFile);

                        try
                        {
                            StringBuilder queryLog = new StringBuilder();
                            queryLog.Append("Preparing Command: ...\n");
                            queryLog.Append("'============================================================================'\n");
                            queryLog.Append(querySql);
                            queryLog.Append("\n");
                            queryLog.Append("'============================================================================'");

                            //passa o parametro e dispara o delegate
                            taskLogDelegate.DynamicInvoke(queryLog.ToString());

                            //add comando para execução
                            connection.AddTransaction(querySql);

                            //delay para garantir a geração do log na tela
                            Thread.Sleep(100);


                        }

                        catch (Exception ex)
                        {

                            string scriptError = "Error in file: " + sql.FileName;
                            //passa o parametro e dispara o delegate
                            taskLogDelegate.DynamicInvoke(scriptError);

                            //dispara o delegate para add update info do erro
                            taskLogExceptionDelegate.DynamicInvoke(ex);

                            //delay para garantir a geração do log na tela
                            Thread.Sleep(100);

                            //para a porra toda
                            cancelation();

                        }
                    }

                    try
                    {
                        StringBuilder queryLog = new StringBuilder();

                        queryLog.Append("/****************************************************************************/\n");
                        queryLog.Append("Executing Query ...\n");
                        queryLog.Append("'****************************************************************************'\n");
                        //limpa o log builder
                        queryLog.Clear();

                        queryLog.Append("'============================================================================'\n");
                        queryLog.Append("Query executed sucessfully !\n");
                        queryLog.Append("'============================================================================'\n");

                        //delay para garantir a geração do log na tela
                        Thread.Sleep(100);

                        //passa o parametro e dispara o delegate
                        taskLogDelegate.DynamicInvoke(queryLog.ToString());

                        //efetiva transação
                        connection.CommitTransaction();

                        //se consegui chegar aqui ta tudo ok
                        taskLogUpdateDelegate.DynamicInvoke();
                    }
                    catch (Exception ex)
                    {

                        StringBuilder logScreen = new StringBuilder("Falha ao efetivar a transação.");
                        logScreen.Append("Mensagem: " + LoggerUtilIts.GetInnerException(ex));

                        //defaz todas as alterações
                        connection.RollbackTransaction();
                    }



                }
            }
            catch (OperationCanceledException oc)
            {
                StringBuilder queryLog = new StringBuilder();
                queryLog.Append("'****************************************************************************'\n");
                queryLog.Append("Failed sql statement.\n");
                queryLog.Append("'****************************************************************************'\n");
                queryLog.Append(oc.Message);

                taskLog(queryLog.ToString());
            }

        }

        //salva o metodo o original
        private void executeDDL_NON_TSQL()
        {
            try
            {
                using (var cnn = createConnection())
                {
                    TaskLogStringDelegate taskLogDelegate = new TaskLogStringDelegate(taskLog);
                    TaskLogExceptionDelegate taskLogExceptionDelegate = new TaskLogExceptionDelegate(addPkgError);
                    TaskLogUpdateDelegate taskLogUpdateDelegate = new TaskLogUpdateDelegate(addPkgInfo);
                    var sqls = getQueriesSql();

                    foreach (var sql in sqls)
                    {
                        taskLog("Script file: " + sql.FileName + "\n");

                        string sqlQuery = StringUtilIts.GetStringFromBytes(sql.DataFile);

                        try
                        {
                            cnn.ExecuteNonQueryTransaction(sqlQuery, taskLogDelegate);

                            Thread.Sleep(500);
                        }

                        catch (Exception ex)
                        {
                            //dispara o delegate para add update info do erro
                            taskLogExceptionDelegate.DynamicInvoke(ex);

                            //para a porra toda
                            cancelation();

                        }
                    }
                    taskLogUpdateDelegate.DynamicInvoke();

                }
            }
            catch (OperationCanceledException oc)
            {
                StringBuilder queryLog = new StringBuilder();
                queryLog.Append("'****************************************************************************'\n");
                queryLog.Append("Failed sql statement.\n");
                queryLog.Append("'****************************************************************************'\n");
                queryLog.Append(oc.Message);

                taskLog(queryLog.ToString());
            }

        }

        private void addPkgError(Exception ex)
        {
            this.wizardPage1.BeginInvoke(new Action(() =>
            {//outros
                this.wizardPage1.AllowBack = false;
                this.wizardPage1.AllowNext = true;
            }));
            completionWizardPage1.BeginInvoke(new Action(() =>
            {
                completionWizardPage1.FinishText = "As atualizações foram canceladas";

            }));
            scintilla.BeginInvoke(new Action(() =>
            {
                string log = ex.Message + "\n\rCommand:\n" + ex.InnerException.Message;

                taskLog(log);
                UpdateInfo updateInfo = new UpdateInfo(this._pacote, log, TypeStatusUpdate.Erro);
                new UpdateInfoManager().AddInformationUpdate(this._pacote, updateInfo, _appConfig);
            }));
        }

        private void addPkgInfo()
        {
            scintilla.BeginInvoke(new Action(() =>
            {

                UpdateInfo updateInfo = new UpdateInfo(this._pacote, scintilla.Text, TypeStatusUpdate.Ok);
                new UpdateInfoManager().AddInformationUpdate(this._pacote, updateInfo, _appConfig);
            }));

        }

        /// <summary>
        /// Add texto no scintilla e uma quebra de linha.
        /// </summary>
        /// <param name="log"></param>
        private void taskLog(string log)
        {
            scintilla.BeginInvoke(
              new Action(() =>
              {
                  scintilla.ReadOnly = false;
                  scintilla.AppendText(log);
                  scintilla.AppendText("\n");
                  scintilla.LineScroll(scintilla.Lines.Count, 0);
                  scintilla.ReadOnly = true;
              }));

        }

        private void detectInstallDir()
        {

            lblStatus.BeginInvoke(
                new Action(() =>
                    {
                        lblStatus.Text = "Detectando diretório de instalação ...";
                    }
                ));
            var discos = FileManagerIts.ToDiskUnit();

            string local = _taskManager.DetectInstallDir();

            this.openFileITE.FileName = local;

            if (Directory.Exists(local))
            {
                this.txtInstallDir.BeginInvoke(
                    new Action(() =>
                    {
                        this.txtInstallDir.Text = local;
                    }
                ));

                this.lblStatus.BeginInvoke(new Action(() =>
                     {
                         lblStatus.Text = "Path de instalação detectado automaticamente !";
                         lblStatus.Visible = true;
                         lblStatus.ForeColor = System.Drawing.Color.Green;
                     }
                ));
                this._installDir = local;
            }

            else
            {

                lblStatus.BeginInvoke(new Action(() =>
                    {
                        lblStatus.Text = "Path de instalação não detectado";
                        lblStatus.Visible = true;
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                ));

            }
        }

        private void cancelation()
        {
            _tokenSource.Cancel();
            //Cancelamento da tarefa 

            // notifica a thread que o cancelamento foi solicitado.
            // Cancela a tarefa DoWork 
            progressBarControl1.BeginInvoke(new Action(() =>
            {
                progressBarControl1.EditValue = 0;
                progressBarControl1.Decrement(100);
                progressBarControl1.Refresh();

            }));

            backgroundWorker1.CancelAsync();

            _tokenSource.Token.ThrowIfCancellationRequested();

        }

        #endregion

        #region Eventos


        private void scintilla_TextChanged(object sender, EventArgs e)
        {
            scintilla.LineFromPosition(scintilla.Lines.Count);
        }

        private void btnSelecionarUpdateFile_Click(object sender, EventArgs e)
        {
            var op = openFilePkg.ShowDialog();

            if (op == DialogResult.OK)
            {

                string pkgFile = openFilePkg.FileName;
                txtUpdateFile.Text = pkgFile;

                try
                {
                    var bytesFile = FileManagerIts.GetBytesFromFile(openFilePkg.FileName);
                    this._pacote = SerializeIts.DeserializeObject<Package>(bytesFile);
                    loadPackage(this._pacote);
                }
                catch (Exception ex)
                {
                    string msg = "O pacote de atualização informado é inválido!"
                        + "\n\nContate o administrador para aplicar atualização.";

                    XMessageIts.ExceptionMessageDetails(ex, msg, "Atenção");

                    LoggerUtilIts.GenerateLogs(ex, msg);
                }

            }
        }

        private void btnSelecionarITE_Click(object sender, EventArgs e)
        {
            var op = openFileITE.ShowDialog();

            if (op == DialogResult.OK)
            {
                //use o diretorio do .exe informado
                this._installDir = Path.GetDirectoryName(openFileITE.FileName);
                this.txtInstallDir.Text = _installDir;
                this.lblStatus.Text = "Atenção, diretório de instação setado manualmente";
            }
        }

        private void XFrmApplyPackage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Directory.Exists(_resourceDir))
                FileManagerIts.DeleteDirectory(_resourceDir);
        }

        private void chkAutenticacao_CheckedChanged(object sender, EventArgs e)
        {
            if (chAutenticacao.Checked)
            {
                lbUsr.Visible = true;
                lbPwd.Visible = true;
                txtUser.Visible = true;
                txtPwd.Visible = true;
            }
            else
            {
                lbUsr.Visible = false;
                lbPwd.Visible = false;
                txtUser.Visible = false;
                txtPwd.Visible = false;
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            bool validado = false;

            //se for servidor local, valide.
            if (txtServerName.Text == "(local)")
                validado = true;
            //mude a string somente se for Azure selecionado.
            if (chAutenticacao.Checked)
            {
                string user = txtUser.Text;
                string pw = txtPwd.Text;

                if (string.IsNullOrEmpty(user))
                {
                    XMessageIts.Advertencia("Informe o usuário da conexão !");
                }
                else if (string.IsNullOrEmpty(pw))
                {
                    XMessageIts.Advertencia("Informe a senha de conexão !");
                }
                else
                {
                    validado = true;
                }

                // this.connectionString = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=90;", txtServerName.Text, cbDatabase.Text, user, pw);
            }

            if (cbDatabase.SelectedItem == null)
            {
                XMessageIts.Advertencia("Informe a base dados!");
            }

            if (validado)
            {
                //testa a conexao
                using (var con = createConnection())
                {

                    if (con.OpenConnection())
                    {
                        XMessageIts.Mensagem("Conexão estabelecida com sucesso !");

                        //fecha a conexao pq so queria testar
                        con.CloseConnection();

                        //verifica se o pacote já esta aplicado

                        var status = new UpdateInfoManager().GetStatusPacote(this._pacote, this._appConfig);

                        if (status == TypeStatusUpdate.Ok)
                        {
                            XMessageIts.Mensagem("Pacote de atualização já aplicado!");
                            this.wizardPage1.AllowNext = false;
                        }
                        //se deu erro pode tentar de novo
                        else if (status == TypeStatusUpdate.Erro)
                        {
                            this.wizardPage1.AllowNext = true;
                        }
                        //senao o pacote nao foi aplicado, então eh possivel continuar.
                        else
                        {
                            this.wizardPage1.AllowNext = true;
                        }

                    }
                    else
                        XMessageIts.ExceptionMessageDetails(null, "Falha ao estabelecer conexão com o banco de dados!");
                }
            }

        }

        private void txtServerName_Leave(object sender, EventArgs e)
        {
            if (!txtServerName.Text.IsNullOrEmpty())
            {
                //apaguei os campos
                cbDatabase.Properties.Items.Clear();
                cbDatabase.Text = "";
                txtUser.Text = "";
                txtPwd.Text = "";

                using (var con = createConnection())
                {
                    cbDatabase.Properties.Items.AddRange(con.DataBases);
                    cbDatabase.SelectedIndex = -1;
                }
            }
        }

        private void XFrmApplyPackage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A && this.btnSelecionar.Enabled)
                btnSelecionarUpdateFile_Click(null, null);

        }

        #endregion

        #region Wizard

        private void wizardPage1_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            string folder = txtInstallDir.Text;

            if (_pacote == null)
            {
                //cancela o evento
                e.Valid = false;
                XMessageIts.Advertencia("Informe o pacote de atualização a ser aplicado !");
            }
            //informe o diretorio de instalacao se existir um pacote de dlls
            else if (_containsDll)
            {
                if (string.IsNullOrEmpty(folder))
                {
                    //cancela o evento
                    e.Valid = false;
                    XMessageIts.Advertencia("Informe o diretório de instalação do programa !");
                }
                //se eu informe o diretorio confirme se ele existe
                else if (!Directory.Exists(folder))
                {
                    //cancela o evento
                    e.Valid = false;
                    XMessageIts.Advertencia("Diretório de instalação não existe ou deixou de existir.",
                        "Acesso Negado !!!");
                }
            }
            else if (_containsSql && cbDatabase.SelectedItem == null)
            {
                //cancela o evento
                e.Valid = false;
                XMessageIts.Advertencia("Informe o banco de dados para aplicar a atualização.");
            }

        }

        private void wizardControl1_CancelClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Dispose();
        }

        private void wizardPage1_PageCommit(object sender, EventArgs e)
        {
            runTask();
        }

        private void wizardControl1_FinishClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Dispose();
        }

        #endregion

        #region Background Worker

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int max = progressBarControl1.Properties.Maximum;
            for (int i = 1; !_taskApply.IsCompleted; i++)
            {
                //Verifica se houve uma requisição para cancelar a operação.
                if (backgroundWorker1.CancellationPending)
                {
                    //avisa o WorkerCompleted saiba que a tarefa foi cancelada.
                    e.Cancel = true;

                    //zera o percentual de progresso do backgroundWorker1.
                    //backgroundWorker1.ReportProgress(0);
                    return;
                }
                else if (i < max)
                {
                    //incrementa o progresso do backgroundWorker 
                    //a cada passagem do loop.
                    this.backgroundWorker1.ReportProgress(i);
                }

                if (chRoolbackTransaction.Checked)
                    //dura 1/10 seg
                    Thread.Sleep(100);

                else
                    //dura 1/10 seg
                    Thread.Sleep(1500);
         
            }

            if (_taskApply.IsCompleted)
                //completa a barrinha
                backgroundWorker1.ReportProgress(max);
            else
                //avisa o WorkerCompleted saiba que a tarefa foi cancelada.
                e.Cancel = true;

        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage != 0)
            {
                //contar pro label
                if (e.ProgressPercentage != progressBarControl1.Properties.Maximum)
                {
                    //Incrementa o valor da progressbar com o valor
                    //atual do progresso da tarefa.
                    progressBarControl1.Increment(1);

                }
                else
                {
                    progressBarControl1.Increment(progressBarControl1.Properties.Maximum);
                    this.wizardPage2.AllowNext = true;
                }
                //registra na barra
                progressBarControl1.Update();

                //informa o percentual na forma de texto
                lblPercent.Text = e.ProgressPercentage.ToString() + "%";
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_tokenSource.IsCancellationRequested || e.Cancelled || e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                //caso a operação seja cancelada, informa ao usuario.
                //taskLog("Operação cancelada!\n");
                //permita tentar novamente
                this.wizardPage1.AllowNext = true;

                this.wizardPage2.AllowCancel = true;
                this.wizardPage2.AllowBack = true;
                this.wizardPage2.AllowNext = false;

                this.progressBarControl1.Decrement(progressBarControl1.Properties.Maximum);
                this.progressBarControl1.Update();

                //volta o cursor ao normal
                this.wizardPage2.Cursor = Cursors.Default;


            }
            else
            {
                //informa que a tarefa foi concluida com sucesso.
                taskLog("Tarefas concluídas com sucesso!");

                wizardControl1.Enabled = true;
                //volta o cursor ao normal
                this.wizardPage2.Cursor = Cursors.Default;

                this.wizardPage2.AllowNext = true;

                //permita tentar novamente
                this.wizardPage1.AllowBack = false;

                //e ja manda pra proxima pagina
                //preciso ver o log
                //this.wizardControl1.SetNextPage();

                //cancela o voltar e cancelar 
                this.completionWizardPage1.AllowBack = false;
                this.completionWizardPage1.AllowCancel = false;
                this.completionWizardPage1.AllowFinish = true;

            }
        }

        #endregion


    }
}
