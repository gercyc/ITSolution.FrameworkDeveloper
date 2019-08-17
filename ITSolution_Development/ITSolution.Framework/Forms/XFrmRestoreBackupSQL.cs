using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSolution.Framework.ConnectionFactory.SQLServer;
using ITSolution.Framework.Mensagem;

namespace ITSolution.Framework.Forms
{
    public partial class XFrmRestoreBackupSql : DevExpress.XtraEditors.XtraForm
    {
        public string Database { get; private set; }
        private Task _taskBackup;
        private bool _finish;
        private readonly CancellationTokenSource _token = new CancellationTokenSource();

        public XFrmRestoreBackupSql()
        {
            InitializeComponent();

            progressBarControl1.Properties.Step = 1;

            this.txtPathBackup.Text = @"D:\";
            this.openFileDialog1.InitialDirectory = txtPathBackup.Text;

            //this.lblDatabase.Visible = false;
            //this.cbDatabase.Visible = false;
            //this.txtPathBackup.ReadOnly = false;

        }

        public XFrmRestoreBackupSql(string database) : this()
        {
            this.Database = database;
            this.cbDatabase.ReadOnly = true;
            this.cbDatabase.Visible = false;
            this.lblDatabase.Visible = false;
        }

        public void SelectDatabase()
        {
            this.Database = null;
            this.cbDatabase.ReadOnly = false;
            this.cbDatabase.Visible = true;
            this.lblDatabase.Visible = true;
        }

        private async void restoreBackupDatabase()
        {
            //define o stilo padrao do progressbar
            //progressBar1.Style = ProgressBarStyle.Blocks;
            progressBarControl1.Increment(0);

            //desabilita os botões enquanto a tarefa é executada
            this.wizardPage2.AllowBack = false;
            this.wizardPage2.AllowNext = false;
            this.wizardPage2.AllowCancel = false;

            this._taskBackup = new Task(() =>
            {
                string bak = txtPathBackup.Text;

                try
                {
                    _finish = SqlUtil.Instance.Restore
                        .RestoreBackupFullFromDatabase(Database, bak);
                }
                catch (InvalidOperationException ex)
                {
                    XMessageIts.ExceptionMessage(ex);
                }

                //if (this.Database.Equals(DbContextIts.DATABASENAME))
                //{
                //    XMessageIts.Erro("A base de dados selecionada não pode ser restaurada!\n"
                //         + "porque está sendo usada.", "Atenção");
                //    finish = false;
                //}

            });

            //executa o processo de forma assincrona.
            backgroundWorker1.RunWorkerAsync();

            await Task.Factory.StartNew(() => _taskBackup.Start());

            if (!_finish)
            {
                _token.Cancel();
            }

        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            var op = openFileDialog1.ShowDialog();

            if (op == DialogResult.OK)
            {
                string pathBackup = Path.Combine(openFileDialog1.FileName);


                if (!pathBackup.EndsWith(".bak"))
                {
                    XMessageIts.Advertencia("Arquivo de backup inválido.", "Acesso Negado !!!");
                }
                else
                {
                    this.txtPathBackup.ReadOnly = false;
                    this.txtPathBackup.Text = pathBackup;
                    this.txtPathBackup.ReadOnly = true;
                }
            }
        }

        private void XFrmRestoreBackupSQL_Load(object sender, EventArgs e)
        {
            Task.Run(() => onLoad());
        }

        private void onLoad()
        {
            if (Database == null)
            {
                var databases = new ConnectionLocalSql().DataBases;

                cbDatabase.BeginInvoke(new Action(() =>
                {
                    cbDatabase.Properties.Items.AddRange(databases);
                }));
            }
        }

        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = cbDatabase.SelectedItem != null ? cbDatabase.SelectedItem.ToString() : null;

            if (db != null)
            {
                this.Database = db;
            }
        }

        #region Controle Wizard 

        private void wizardPage1_PageCommit(object sender, EventArgs e)
        {
            //tudo ok e la vamos nos
            restoreBackupDatabase();
        }

        private void wizardPage1_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            string file = txtPathBackup.Text;

            if (string.IsNullOrEmpty(file))
            {
                //cancela o evento
                e.Valid = false;
                XMessageIts.Advertencia("Informe o arquivo de backup !");
            }
            else if (!File.Exists(file))
            {
                //cancela o evento
                e.Valid = false;
                XMessageIts.Advertencia("Arquivo \"" + file + "\" não existe !\n");
            }
            else if (string.IsNullOrWhiteSpace(this.Database))
            {
                //cancela o evento
                e.Valid = false;
                XMessageIts.Advertencia("O nome da base de dados não ser nulo ou conter espaço nem possuir caracteres especiais");
            }
            else
            {
                this.openFileDialog1.FileName = txtPathBackup.Text;
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
                // notifica a thread que o cancelamento foi solicitado.
                // Cancela a tarefa DoWork 
                backgroundWorker1.CancelAsync();

                _token.Cancel();

                lblMsg.BeginInvoke(
                  new Action(() =>
                  {
                      if (status == null)
                          status = "Restauração cancelada !";
                      lblMsg.Text = status;
                  }
               ));
            }
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
                lblMsg.Text = "Falha na restauração!";

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
                lblMsg.Text = "Restauração concluída com sucesso!";
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

    }
}