using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;
using System.Threading;
using ITSolution.Framework.ConnectionFactory;
using System.Diagnostics;
using System.Data.Entity;
using ITSolution.Framework.Util;
using ITSolution.Framework.Beans.Forms;

//Sobre async
//http://www.macoratti.net/14/02/c_asinc1.htm

namespace ITSolution.Framework.Beans.ProgressBar
{
    /// <summary>
    /// Classe responsavél por ilustrar e iniciar o EntityFramework
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class XFrmEntityFramework<T> : WaitForm where T : class
    {
        //O dbContext será aberto uma vez e o EF trata as excecoes automaticamente
        private DbContext contexto;
        //private Thread Ilustrador;//nao sera usada mais nesse form
        private Form FrmInvoke;
        public ConnectionFactoryIts ConnectionFactory { get; set; }
        //flags para alerta first barra
        public bool Started { get; set; }
        /// <summary>
        /// true se o contexto foi carregado com sucesso caso contrário false
        /// </summary>
        public bool Sucess { get; set; }
        /// <summary>
        /// true se houve falha no carregamento do texto caso contrário false
        /// </summary>
        public bool Failed { get; set; }

        //Delegates
        delegate void InvokerForm();
        delegate void SetTextCallback(string status);

        private XFrmEntityFramework()
        {
            InitializeComponent();
            //this.xFrmLogo = new XFrmLogoIts();
        }
      
        /// <summary>
        /// O form informado será uma Thread que será chamada pelo Application.RunFormInvoke
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="dbSet"></param>
        /// <param name="formInvoke"></param>
        public XFrmEntityFramework(DbContext ctx, Form formInvoke, 
            string applicationName = "Iniciando Aplicação")
            : this()
        {
            this.contexto = ctx;
            this.FrmInvoke = formInvoke;
            this.progressPanel1.Caption = applicationName;
        }

        private void FrmProgressEntityFrameWork_Shown(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(this.runEntityFramework)).Start();
        }


        /// <summary>
        /// Chama o form usando ShowDialog
        /// </summary>
        public void Run()
        {
            this.ShowDialog();
        }


        /// <summary>
        /// Ilustra os '...' no tempo de inicialização do entity framework
        /// </summary>
        private void runProgress()
        {
            try
            {
                var description = this.progressPanel1.Description;
                int j = 0;
                //nao demora nunca 500 secs
                while (true)//usava o Sucess aqui
                {
                    Thread.Sleep(200);
                    Trace.WriteLine("Ilustrando ...");
                    if (j > 6)
                    {
                        SetTextCallback status = new SetTextCallback(setDescriptonProgressPanel);
                        this.Invoke(status, new object[] { description });
                        j = 0;
                    }
                    else
                    {
                        SetTextCallback status = new SetTextCallback(setDescriptonProgressPanel);
                        this.Invoke(status, new object[] { progressPanel1.Description + "." });
                    }
                    j++;
                }
            }
            catch (System.InvalidOperationException ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                Environment.Exit(0);
            }
            Trace.WriteLine("Fim do progresso");
        }

        private async void runEntityFramework()
        {
            //this.Ilustrador = new Thread(runProgress);
            //this.Ilustrador.Start();
            //banco de dados e a conexao utilizada pelo EF
            var dbEf = this.contexto.Database;

            try
            {
                this.Started = true;
                Trace.WriteLine("Iniciando Contexto");

                //Inicia ou cria o banco
                dbEf.CreateIfNotExists();

                //conexao Sql
                await dbEf.Connection.OpenAsync();

                Trace.WriteLine("Connection: " + dbEf.Connection.State);

                try
                {
                    //faz uma consulta no EF
                    var first = await this.contexto.Set<T>().FirstOrDefaultAsync();
                }

                catch (InvalidOperationException ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
                catch (Exception ex)
                {
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                var lista = new List<String>();

                lista.Add("O contexto atual não corresponde a estrutura do banco de dados.");
                lista.Add("Contate o administrador para que atualização seja feita no banco de dados.\n");

                XFrmOptionPane.ShowListTextArea(lista, "Falha na inicialização do framework");

                this.Failed = true;
                //Environment.Exit(0);
                Application.Exit();

            }
            //seta os flags
            finally
            {
                //se nao deu errado
                if (!Failed)
                {
                    //termine a ilustracao da barra
                    this.Sucess = true;
                }
                Trace.WriteLine("Fechando conexao Sql: " + dbEf.Connection.State);
                dbEf.Connection.Close();
            }

            //a thread terminou
            if (this.progressPanel1.InvokeRequired)
            {
                //Essa laço tem o tempo de espera do Ilustrador do panel de progress
                //Sem ele a barra continuaria sendo pintada 
                //preciso invocar outra thread e thread anterior ainda nao terminou
                //while (Ilustrador.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
                //{
                //    Thread.Sleep(150);
                //    Trace.WriteLine("Aguarde...");
                //}

                this.Invoke(new SetTextCallback(setDescriptonProgressPanel), new object[] { "Iniciando aplicação ..." });

                Thread.Sleep(300);

                this.Invoke(new InvokerForm(runFormInvoke));
            }
        }

        /// <summary>
        /// Altera o label do panel
        /// </summary>
        /// <param name="status"></param>
        private void setDescriptonProgressPanel(string status)
        {
            progressPanel1.Description = status;

        }

        /// <summary>
        /// Ação de terminar a barra de progresso
        /// </summary>
        private void runFormInvoke()
        {
            this.Dispose();

            if (Sucess && FrmInvoke != null)
            {
                FrmInvoke.ShowDialog();
            }

        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);

            this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        //public enum WaitFormCommand        {        }

    }
}