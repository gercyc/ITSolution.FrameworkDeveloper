using ITSolution.Framework.ConnectionFactory;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using ITSolution.Framework.ConnectionFactory.SQLServer;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Entities;
using ITSolution.Admin.Entidades.TaskManager;
using ITSolution.Framework.Util;

//http://www.devmedia.com.br/backgrounworker-e-progressbar-exibindo-uma-barra-de-progresso-em-c/32127


namespace ITSolution.Admin.Forms.Util
{
    /// <summary>
    ///Form que sera enviado pro cliente aplicar o pacote de atualização
    ///Tbm é usado pra aplicação interna sem geração de pacote
    ///O pacote e o diretório de instalaçã do programa do cliente são detectados automaticamente
    /// </summary>
    public partial class XFrmClientUpdate : DevExpress.XtraEditors.XtraForm
    {
        private Task _tasks;
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        //Local do arquivo com as atualizações
        private string _resourceDir;
        //Diretorio que receberá as atualizações 
        private string _installDir;
        //Diretorio com as procedures
        private string _proceduresResource;
        //Arquivo com os inserts
        //esqueleto da string de conexão
        private string _connectionString = "Data Source=(local);Initial Catalog=database;Integrated Security=True;User ID=sa;Password=a123";
        private TaskUpdateManager _taskUpdateManager;
 
        private DbContextIts _ctx;
        private AppConfigIts appConfig;

        #region Construtores
        public XFrmClientUpdate()
        {
            InitializeComponent();
            init();
            string startup = Application.StartupPath;
            //altera o path para onde os recursos estão
            _proceduresResource = startup.Replace(@"bin\Debug", @"SQLs\procedures");
            //..\ITSolution\ITSolution.Admin\bin\Debug
            //..\ITE\ITE.Forms\bin\Debug\
            _resourceDir = startup.Replace(@"\ITSolution\ITSolution.Admin", @"ITE\ITE.Forms");

            appConfig = AppConfigManager.Configuration.AppConfig;

            if (appConfig.ServerName.Equals("(local)"))
            {
                cbDatabase.Properties.Items.AddRange(new ConnectionLocalSql().DataBases);
                this.cbDatabase.SelectedItem = appConfig.Database;
            }
            else
            {
                this.cbDatabase.Properties.Items.Add(appConfig.Database);
                this.cbDatabase.SelectedIndex = 0;
            }

            this.cbDatabase.SelectedItem = appConfig.Database;
            this.txtServerName.Text = appConfig.ServerName;

        }

        public XFrmClientUpdate(DbContextIts ctx) : this()
        {
            this._ctx = ctx;
            this._connectionString = ctx.NameOrConnectionString;
            cbDatabase.Properties.Items.Add( ctx.DatabaseName);

            pnlSql.Visible = true;
            cbDatabase.Properties.Items.Add(ctx.DatabaseName);
            var app = AppConfigManager.Configuration.AppConfig;

            txtServerName.Text = app.ServerName;
            cbDatabase.SelectedIndex = 0;
            this.pnlSql.Enabled = false;
            rChListTask.SetItemChecked(0, true);
        }
        #endregion

        #region Tarefas

        private void updateSoftware()
        {
            try
            {

                //extraindo atualização
                taskLogger("Iniciando atualização em: " + _installDir);
                var itemDlls = rChListTask.GetItemChecked(1);
                var itemDllsITE = rChListTask.GetItemChecked(2);
                var itemDllsITSolution = rChListTask.GetItemChecked(3);
                taskLogger("Atualizando DLLs ... ");

                /*Task.Run(new Action(() =>
                {
                    foreach (var f in FileManagerIts.ToFiles(...))
                    {
                        //vo mostrar so o nome  
                        taskLogger("Atualizando: " + Path.GetFileName(f));
                    }
                }));*/
                //realiza a tarefa enquanto a ilustração rola

                if (itemDllsITE)
                {
                    taskLogger("Atualizando ITE DLLs ... ");
                    _taskUpdateManager.UpdateDLLsITE(_resourceDir, _installDir);
                }
                if (itemDllsITSolution)
                {
                    taskLogger("Atualizando ITSolution DLLs ... ");
                    _taskUpdateManager.UpdateDLLsITSolution(_resourceDir, _installDir);
                }
                else
                    _taskUpdateManager.UpdateSystemDLLs(_resourceDir, _installDir);

            }
            catch (Exception ex)
            {
                try
                {
                    cancelation();
                    taskLogger("Falha no pacote de atualizações");
                    taskLogger(ex.Message);
                    LoggerUtilIts.ShowExceptionLogs(ex, this);
                }
                catch (OperationCanceledException oc)
                {
                    taskLogger("Operação cancelada: " + oc.Message);
                }
            }
        }

        private void executeDDL()
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                using (var cnn = createConnection())
                {
                    try
                    {
                        cnn.OpenConnection();

                        var connection = cnn.Connection;

                        Dictionary<string, bool> statusScripts = new Dictionary<string, bool>();
                        List<SqlCommand> commands = new List<SqlCommand>();
                        //cria a transacao
                        cnn.Transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted, "myTransaction");


                        //de tudo .sql q esta la dentro
                        var sqlFiles = FileManagerIts.ToFiles(_proceduresResource, new string[] { ".sql" }, true);

                        /*var sqlFiles = new FileManagerIts().ToFilesRecursive(_proceduresResource);
                        var sqls = sqlFiles.Where(file => file.ToString().EndsWith(".sql"));*/
                        foreach (var sql in sqlFiles)
                        {
                            var sqlFileName = Path.GetFileName(sql);
                            taskLogger("Executando script: " + sqlFileName);
                            var sqlQuery = FileManagerIts.GetDataStringFile(sql);
                            // split script on GO command
                            IEnumerable<string> commandStrings = Regex.Split(sqlQuery, @"^\s*GO\s*$",
                                                     RegexOptions.Multiline | RegexOptions.IgnoreCase);

                            
                            //executando cada script separado por GO
                            foreach (string commandString in commandStrings)
                            {
                                try
                                {
                                    if (commandString.Trim() != string.Empty)
                                    {
                                        var command = new SqlCommand(commandString, null);
                                        command.Transaction = cnn.Transaction;
                                        var result = cnn.ExecuteNonQuery(command);
                                        commands.Add(command);
                                        if (result.IsCompleted) //se executou o arquivo DDL..
                                        {
                                            //taskLogger("Comando " + commandString + " executado com sucesso.");
                                            taskLogger("Instrução " + sqlFileName + " executado com sucesso.");
                                            taskLogger("============================================================================");
                                            statusScripts.Add(commandString, true);
                                        }
                                    }
                                }
                                catch (SqlException sqlE)
                                {
                                    taskLogger("Error: " + sqlE.Number + "Comando: \n" + commandString + " \nLine: " + sqlE.LineNumber + " Message:" + sqlE.Message);
                                    statusScripts.Add(commandString, false);
                                }
                            }//fim
                        }

                        //se a lista de scripts executados tiver mais de um item falso
                        if (statusScripts.Where(s => s.Value == false).Count() == 0)
                        {
                            cnn.Transaction.Commit();
                            ts.Complete();
                        }
                        else
                        {
                            cnn.Transaction.Rollback();
                            throw new TransactionAbortedException();
                        }
                    }
                    catch (TransactionAbortedException traCanc)
                    {
                        taskLogger("Ocorreram erros no processo. Todas as alterações serao desfeitas.");
                        taskLogger("Erro: " + traCanc.Message);
                    }
                    catch (Exception ex)
                    {
                        taskLogger("Ocorreram erros no processo. Todas as alterações serao desfeitas.");
                        taskLogger("Erro: " + ex.Message);
                    }
                    finally
                    {
                        cnn.CloseConnection();
                    }
                }
            }
        }

        #endregion 

        #region Metodos

        private void init()
        {
            this.ActiveControl = txtInstallDir;
            txtInstallDir.Focus();
            progressBarControl1.Properties.Step = 1;

            progressBarControl1.PerformStep();
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;
            _taskUpdateManager = new TaskUpdateManager();
        }

        private ConnectionFactoryIts createConnection()
        {

          
            string serverName = txtServerName.Text;

            //altere a string somente se nao for um bd no azure
            if (!chAutenticacao.Checked)
            {

                //_connectionString,   cbDatabase.SelectedItem.ToString(), txtServerName.Text);

                return new ConnectionFactoryIts(appConfig.ConnectionString);
            }
            else
            {
                return new ConnectionFactoryIts(this._connectionString);
            }
        }

        private async void runTask()
        {
            //define o stilo padrao do progressbar
            //progressBar1.Style = ProgressBarStyle.Blocks;
            progressBarControl1.Increment(0);

            //desabilita os botões enquanto a tarefa é executada
            this.wizardPage2.AllowBack = false;
            //nao deixe avançar
            this.wizardPage2.AllowNext = false;
            //nao deixe cancelar
            this.wizardPage2.AllowCancel = false;

            var factory = Task.Factory;

            _tasks = new Task(() =>
            {
                if (rChListTask.GetItemChecked(0))
                    executeDDL();

                updateSoftware();

            });

            //executa o processo de forma assincrona.
            backgroundWorker1.RunWorkerAsync();

            await Task.Factory.StartNew(() => _tasks.Start());

        }

        private void cancelation(string status = null)
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

            taskLogger("Tarefas canceladas !");
            _tokenSource.Token.ThrowIfCancellationRequested();

        }

        private void autoDetectInstallDir()
        {

            longTask("Detectando diretório de instalação ...");
            string local = _taskUpdateManager.DetectInstallDir();


            this.folderInstallDir.SelectedPath = local;

            if (Directory.Exists(local))
            {
                this.txtInstallDir.BeginInvoke(
                    new Action(() =>
                    {
                        this.txtInstallDir.Text = this.folderInstallDir.SelectedPath;
                    }
                    ));

                lblStatus.BeginInvoke(new Action(() =>
                {
                    lblStatus.Text = "Path de instalação detectado automaticamente !";
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }));

            }

            else
            {

                lblStatus.BeginInvoke(new Action(() =>
                {
                    lblStatus.Text = "Path de instalação não encontrado";
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }));

            }


        }

        private void longTask(string status)
        {
            lblStatus.BeginInvoke(
               new Action(() =>
               {
                   lblStatus.Text = status;
               }
               ));
        }

        private void taskLogger(string log)
        {
            richLog.BeginInvoke(
               new Action(() =>
               {
                   richLog.AppendText(log);
                   richLog.AppendText("\n");
               }));
        }

        #endregion

        #region Eventos
        private void rChListTask_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            var stateSQL = rChListTask.GetItemChecked(0);
            var itemDlls = rChListTask.GetItemChecked(1);
            var itemDllsITE = rChListTask.GetItemChecked(2);
            var itemDllsITSolution = rChListTask.GetItemChecked(3);

            pnlSql.Visible = stateSQL;

            var index = rChListTask.SelectedIndex;

            switch (index)
            {
                //DLLs
                case 1:
                    rChListTask.SetItemChecked(2, false);
                    rChListTask.SetItemChecked(3, false);
                    break;
                //DLLs ITE
                case 2:

                    if (itemDlls && itemDllsITSolution)
                    {
                        rChListTask.SetItemChecked(1, false);
                        rChListTask.SetItemChecked(3, false);
                    }
                    else if (itemDlls)
                    {
                        rChListTask.SetItemChecked(1, false);
                    }
                    break;
                //DLLs ITSolution
                case 3:
                    if (itemDlls && itemDllsITE)
                    {
                        rChListTask.SetItemChecked(1, false);
                        rChListTask.SetItemChecked(2, false);
                    }
                    else if (itemDlls)
                    {
                        rChListTask.SetItemChecked(1, false);
                    }
                    break;
            }
            /*
                if (item.CheckState == CheckState.Checked)
                    item.CheckState = CheckState.Unchecked;
                else
                    item.CheckState = CheckState.Checked;
            */
        }

        private void btnSelecionarInstallDir_Click(object sender, EventArgs e)
        {
            var op = folderInstallDir.ShowDialog();

            if (op == DialogResult.OK)
            {
                this._installDir = folderInstallDir.SelectedPath;
                lblStatus.Text = "Atenção, diretório de instação setado manualmente";
                if (!Directory.Exists(_installDir))
                {

                    XMessageIts.Advertencia("Diretório de instalação não existe ou deixou de existir.",
                        "Acesso Negado !!!");
                }
                else
                {
                    this.txtInstallDir.Text = _installDir;
                }
            }
        }

        private void richLog_TextChanged(object sender, EventArgs e)
        {
            richLog.ScrollToCaret();
        }

        private void txtInstallDir_EditValueChanged(object sender, EventArgs e)
        {
            this._installDir = this.txtInstallDir.Text;
            folderInstallDir.SelectedPath = this._installDir;
        }

        private void txtInstallDir_Leave(object sender, EventArgs e)
        {
            txtInstallDir.Text = txtInstallDir.Text.Trim();

            if (!string.IsNullOrEmpty(txtInstallDir.Text))
                lblStatus.Text = "Atenção, diretório de instação setado manualmente";
        }

        private void txtInstallDir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.L)
                btnSelecionarInstallDir_Click(null, null);
        }

        private void XFrmUpdateITE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            { }

            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D)
            { }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.T)
            { }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F)
            { }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.U)
            { }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.G)
            { }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.I)
            { }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                txtInstallDir.Focus();

            else if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.A)
            {

                //var frm = new XFrmAppConfig(app);

                //frm.ShowDialog();

                //if (frm.AppConfig != null)
                //    this._connectionString = app.ConnectionString;
            }

        }


        private void btnConectar_Click(object sender, EventArgs e)
        {
            //mude a string somente se for Azure selecionado.
            if (chAutenticacao.Checked)
            {
                //itsolutiondev.database.windows.net
                this._connectionString =
                    String.Format("Server=tcp:{0},1433;Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=90;", txtServerName.Text, cbDatabase.Text, txtUsr.Text, txtPwd.Text);
            }

            using (var con = createConnection())
            {

                if (con.OpenConnection())
                {
                    XMessageIts.Mensagem("Conexão estabelecida com sucesso !");
                    //fecha a conexao pq so queria testar
                    con.CloseConnection();

                    this.wizardPage1.AllowNext = true;
                }
                else
                    XMessageIts.Erro("Falha ao estabelecer conexão com o banco de dados!");
            }
        }

        private void chAutenticacao_CheckedChanged(object sender, EventArgs e)
        {
            if (chAutenticacao.Checked)
            {
                lbUsr.Visible = true;
                lbPwd.Visible = true;
                txtUsr.Visible = true;
                txtPwd.Visible = true;
            }
            else
            {
                lbUsr.Visible = false;
                lbPwd.Visible = false;
                txtUsr.Visible = false;
                txtPwd.Visible = false;
            }
        }
        #endregion

        #region Wizard

        private void wizardPage1_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {

            //verificação para consistencia de tarefas
            string folder = txtInstallDir.Text;

            if (rChListTask.CheckedIndices.Count == 0)
            {
                XMessageIts.Advertencia("Informe pelo menos uma tarefa a ser executada!");
                //cancela o evento
                e.Valid = false;
            }
            else
            {
                var sql = rChListTask.GetItemChecked(0);
                var itemDlls = rChListTask.GetItemChecked(1);
                var itemDllsITE = rChListTask.GetItemChecked(2);
                var itemDllsITSolution = rChListTask.GetItemChecked(3);
                //se marquei para atualizar DLLs
                if (itemDlls || itemDllsITE || itemDllsITSolution)
                {
                    if (string.IsNullOrEmpty(folder))
                    {
                        //cancela o evento
                        e.Valid = false;
                        XMessageIts.Advertencia("Informe o diretório de instalação do programa !");
                    }
                    else if (!Directory.Exists(folder))
                    {
                        //cancela o evento
                        e.Valid = false;
                        XMessageIts.Advertencia("Diretório " + folder + " não existe !\n");
                    }
                }
                else if (sql && cbDatabase.SelectedItem == null)
                {
                    //cancela o evento
                    e.Valid = false;
                    XMessageIts.Advertencia("Informe o banco de dados para aplicar a atualização.");
                }
                else
                {
                    e.Valid = true;//ok
                }
            }
        }

        private void wizardControl1_CancelClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                cancelation();

            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Cancelado a pedido do usuário " + ex.Message);
            }
            this.Dispose();

        }

        private void wizardPage1_PageInit(object sender, EventArgs e)
        {
            if (!File.Exists(txtInstallDir.Text) || string.IsNullOrEmpty((txtInstallDir.Text)))
                Task.Run(() => autoDetectInstallDir());

            txtInstallDir.Focus();
        }

        private void wizardPage1_PageCommit(object sender, EventArgs e)
        {
            runTask();
        }

        private void wizardControl1_FinishClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Dispose();
        }

        private void completionWizardPage1_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            //inicia a aplicação
            if (chExibirArquivo.Checked)
                FileManagerIts.OpenFromSystem(Path.Combine(txtInstallDir.Text, "ITE.Forms.exe"));
        }

        #endregion

        #region Background Worker

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 1; !_tasks.IsCompleted; i++)
            {
                //Verifica se houve uma requisição para cancelar a operação.
                if (backgroundWorker1.CancellationPending)
                {
                    cancelation();

                    //para q o WorkerCompleted saiba que a tarefa foi cancelada.
                    e.Cancel = true;

                    //zera o percentual de progresso do backgroundWorker1.
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
                else if (i < 90)
                {
                    //incrementa o progresso do backgroundWorker 
                    //a cada passagem do loop.
                    this.backgroundWorker1.ReportProgress(i);
                }

                //1/5 de seg
                Thread.Sleep(200);
            }
            //completa a barrinha
            backgroundWorker1.ReportProgress(progressBarControl1.Properties.Maximum);


        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage != 0)
            {
                //contar pro label
                if (e.ProgressPercentage != 100)
                {
                    //Incrementa o valor da progressbar com o valor
                    //atual do progresso da tarefa.
                    progressBarControl1.Increment(1);

                }
                else
                {
                    progressBarControl1.Increment(progressBarControl1.Properties.Maximum);

                }
                //registra na barra
                progressBarControl1.Update();

                //informa o percentual na forma de texto
                lblPercent.Text = e.ProgressPercentage.ToString() + "%";
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.

                //caso a operação seja cancelada, informa ao usuario.
                taskLogger("Falha na conclusão das tarefa(s)!");


                //ativa o cancelar
                this.wizardPage2.AllowCancel = true;

                this.progressBarControl1.Decrement(progressBarControl1.Properties.Maximum);
                this.progressBarControl1.Update();

                //informa o percentual na forma de texto
                lblPercent.Text = "0%";
                //volta o cursor ao normal
                this.wizardPage2.Cursor = Cursors.Default;

            }
            else
            {
                wizardPage2.AllowCancel = true;
                wizardPage2.AllowNext = true;
                //informa que a tarefa foi concluida com sucesso.
                taskLogger("Tarefas concluída com sucesso!");
                wizardControl1.Enabled = true;
                //volta o cursor ao normal
                this.wizardPage2.Cursor = Cursors.Default;

                //cancela o voltar e cancelar 
                this.completionWizardPage1.AllowBack = false;
                this.completionWizardPage1.AllowCancel = false;
                this.completionWizardPage1.AllowFinish = true;

            }
        }



        #endregion


    }
}
