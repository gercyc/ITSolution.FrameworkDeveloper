using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.ConnectionFactory.SQLServer;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;

//http://www.devmedia.com.br/backgrounworker-e-progressbar-exibindo-uma-barra-de-progresso-em-c/32127

namespace ITSolution.Framework.Forms
{

    public partial class XFrmBackupSql : DevExpress.XtraEditors.XtraForm
    {
        private Task _taskBackup;
        private readonly CancellationTokenSource _token = new CancellationTokenSource();
        private readonly AppConfigIts _appConfig;
        private bool _finish;
        private XFrmBackupSql()
        {
            InitializeComponent();
            progressBarControl1.Properties.Step = 1;

        }

        public XFrmBackupSql(AppConfigIts app) : this()
        {
            this._appConfig = app;

            string dirBackup = Path.Combine(Application.StartupPath, "Backups ITE\\");

            this.folderBrowserDialog1.SelectedPath = dirBackup;
            this.txtPathBackup.Text = dirBackup + _appConfig.Database + "_" + DataUtil.ToDateSql() + ".bak";

            if (!Directory.Exists(dirBackup))
                Directory.CreateDirectory(dirBackup);

            this.lblDatabase.Visible = false;
            this.cbDatabase.Visible = false;

        }

        private async void backupDatabase()
        {

            //define o stilo padrao do progressbar
            //progressBar1.Style = ProgressBarStyle.Blocks;
            progressBarControl1.Increment(0);

            //desabilita os botões enquanto a tarefa é executada
            //nao deixe voltar
            this.wizardPage2.AllowBack = false;

            this.wizardPage2.AllowNext = false;
            //this.wizardPage2.AllowCancel = false;

            _taskBackup = new Task(() =>
            {
                //var conn = ConfigurationManager.ConnectionStrings["Balcao"].ConnectionString;

                string pathbackup = folderBrowserDialog1.SelectedPath;
                _finish = SqlUtil.Instance.Backup.BackupFullCompressFromDatabase(_appConfig, pathbackup);
                //_finish = SqlUtil.Instance.Backup.BackupNativoFullFromDatabase(_appConfig, pathbackup);

            });

            //executa o processo de forma assincrona.
            backgroundWorker1.RunWorkerAsync();

            /*var taskAux =*/ await Task.Factory.StartNew(() => _taskBackup.Start());

            if (!_finish )
            {
                _token.Cancel();
            }

        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            var op = folderBrowserDialog1.ShowDialog();

            if (_appConfig.Database != null)
            {
                if (op == DialogResult.OK)
                {
                    string pathBackup = Path.Combine(folderBrowserDialog1.SelectedPath, _appConfig.Database + ".bak");

                    string dirBackup = "" + Path.GetDirectoryName(pathBackup);

                    if (dirBackup.Contains(@"C:\") || dirBackup.Equals(FileManagerIts.DeskTopPath))
                    {
                        XMessageIts.Advertencia("O local selecionado não pode ser o local de backup.",
                            "Local não permitido !!!");
                        folderBrowserDialog1.SelectedPath = Path.GetDirectoryName(txtPathBackup.Text);

                    }
                    else
                    {
                        this.txtPathBackup.Text = pathBackup;
                    }
                }
            }
        }

        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            _appConfig.Database = cbDatabase.SelectedItem != null ? cbDatabase.SelectedItem.ToString() : null;
        }

        #region Controle Wizard 

        private void wizardPage1_PageCommit(object sender, EventArgs e)
        {
            //tudo ok e la vamos nos
            backupDatabase();
        }

        private void wizardPage1_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            string folder = Path.GetDirectoryName(txtPathBackup.Text);

            if (string.IsNullOrEmpty(folder))
            {
                //cancela o evento
                e.Valid = false;
                XMessageIts.Advertencia("Informe o diretório para backup !");
            }
            else if (!Directory.Exists(folder))
            {
                //cancela o evento
                e.Valid = false;
                XMessageIts.Advertencia("Diretório " + folder + " não existe !\n");
            }
            else if (string.IsNullOrEmpty(_appConfig.Database))
            {
                //cancela o evento
                e.Valid = false;

                XMessageIts.Advertencia("Banco de dados não informado");

            }
            else
            {
                this.folderBrowserDialog1.SelectedPath = folder;
            }
        }

        private void wizardControl1_CancelClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cancelation();
        }

        private void cancelation(string status = null)
        {
            //Cancelamento da tarefa 
            if (backgroundWorker1.IsBusy)//se o backgroundWorker1 estiver ocupado
            {
                try
                {

                    // notifica a thread que o cancelamento foi solicitado.
                    // Cancela a tarefa DoWork 
                    backgroundWorker1.CancelAsync();

                    _token.Cancel();

                    lblMsg.BeginInvoke(
                      new Action(() =>
                      {
                          if (status == null)
                              status = "Backup cancelado !";

                          lblMsg.Text = status;
                      }
                   ));

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        private void completionWizardPage1_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            if (chExibirArquivo.Checked)
                FileManagerIts.OpenFromSystem(Path.GetDirectoryName(txtPathBackup.Text));
        }

        #endregion

        #region BackgroundWorker
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int max = progressBarControl1.Properties.Maximum;
            for (int i = 1; !_taskBackup.IsCompleted; i++)
            {
                Console.WriteLine(i);
                //Verifica se houve uma requisição para cancelar a operação.
                if (backgroundWorker1.CancellationPending)
                {
                    cancelation();

                    //avisa o WorkerCompleted saiba que a tarefa foi cancelada.
                    e.Cancel = true;

                    //zera o percentual de progresso do backgroundWorker1.
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
                else if (i < max)
                {
                    //incrementa o progresso do backgroundWorker 
                    //a cada passagem do loop.
                    this.backgroundWorker1.ReportProgress(i);
                }

                //dura 1 seg
                Thread.Sleep(150);

            }

            if (_finish)
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
            if (e.Cancelled)
            {
                //caso a operação seja cancelada, informa ao usuario.
                lblMsg.Text = "Falha durante processo de backup!";

                //deixa o cara voltar a tela anterior
                this.wizardPage2.AllowBack = true;

                //atica o cancelar
                this.wizardPage2.AllowCancel = true;

                //nao deixa o doidao seguir nao neh doido
                this.wizardPage2.AllowNext = false;

                this.progressBarControl1.Increment(0);
                this.progressBarControl1.Update();

                //informa o percentual na forma de texto
                lblPercent.Text = "0%";
                //volta o cursor ao normal
                this.wizardPage2.Cursor = Cursors.Default;
            }
            else if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.

            }
            else
            {
                //informa que a tarefa foi concluida com sucesso.
                lblMsg.Text = "Backup concluído com sucesso!";
                this.wizardControl1.Enabled = true;
                //volta o cursor ao normal
                this.wizardPage2.Cursor = Cursors.Default;

                //e ja manda pra proxima pagina
                this.wizardControl1.SetNextPage();

                //deixa cancelar nao
                //no máximo deixa ele espiar a tela anterior
                this.completionWizardPage1.AllowCancel = false;
            }
        }

        #endregion

        private void TarefaLonga(int p)
        {
            for (int i = 0; i <= 10; i++)
            {
                // faz a thread dormir por "p" milissegundos a cada passagem do loop
                Thread.Sleep(p);

                lblMsg.BeginInvoke(
                   new Action(() =>
                   {
                       lblMsg.Text = "Tarefa em progresso ...";
                   }
                ));

            }
        }

    }
}