using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;
using ITSolution.Framework.Beans.Forms;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



//Sobre async
//http://www.macoratti.net/14/02/c_asinc1.htm

namespace ITSolution.Framework.Beans.ProgressBar
{
    /// <summary>
    /// Classe responsavél por ilustrar o tempo de espera do carregamento do Entity Framework
    /// </summary>
    public partial class WaitEntityFramework : WaitForm
    {
        //flags para alerta first barra
        public static bool Started { get; set; }
        /// <summary>
        /// true se o contexto foi carregado com sucesso caso contrário false
        /// </summary>
        public static bool Sucess { get; set; }
        /// <summary>
        /// true se houve falha no carregamento do contexto caso contrário false
        /// </summary>
        public static bool Failed { get; set; }

        //Delegates
        delegate void InvokerForm();
        delegate void SetTextCallback(string status);

        public static string ApplicationName { get; set; }
        public WaitEntityFramework()
        {
            InitializeComponent();
            if (!String.IsNullOrWhiteSpace(ApplicationName))
                this.progressPanel1.Description = ApplicationName;

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 2013 Light Gray";
        }

        /// <summary>
        /// Inicia uma tarefa do tipo void
        /// Necessário bloqueo do componente a ser manipulado
        /// O form já deve ter sido exibido
        ///Ex:
        ///this.Invoke(new MethodInvoker(delegate
        ///{
        ///     ....
        ///}));
        /// </summary>
        /// <param name="task"></param>
        public static async void StartTask(Task task, Form frmInvoke)
        {
            SplashScreenManager.ShowForm(typeof(XFrmWait));

            await Task.Run(() => task);

            SplashScreenManager.CloseForm();

            frmInvoke.ShowDialog();

        }

        /// <summary>
        /// Inicia o entityframework e invoca o form informado se a inicialização foi bem sucedida.
        /// </summary>
        /// <param name="task"></param>
        public static async Task<bool> StartTask<T>(Task<DbContextIts> task) where T : class
        {
            SplashScreenManager.ShowForm(typeof(WaitEntityFramework));

            try
            {
                Console.WriteLine("Wait Entityframework initializate ...");
                await Task.Run(() => task);
                Trace.WriteLine("Iniciando Contexto");
                var dbEf = task.Result.Database;

                //verifica e cria o banco caso ele nao exista
                dbEf.CreateIfNotExists();

                //realiza a conexao com o sql
                await dbEf.Connection.OpenAsync();

                //Flag que foi iniciado com sucesso
                Sucess = true;

                Trace.WriteLine("Connection Status: " + dbEf.Connection.State);
                try
                {
                    //faz uma consulta no EF
                    var list = task.Result.Set<T>().ToList<T>();
                    Console.WriteLine(list.ToString());
                    Thread.Sleep(150);
                }
                catch (Exception ex)
                {
                    //Nao importa
                    LoggerUtilIts.ShowExceptionLogs(ex);

                    XMessageIts.ExceptionMessageDetails(ex, "Falha na inicialização!");
                }

            }
            catch (Exception ex)
            {
                //Flag de erro
                Failed = true;
                LoggerUtilIts.ShowExceptionLogs(ex);
                var lista = new List<string>();

                lista.Add("O contexto atual não corresponde a estrutura do banco de dados.");
                lista.Add("Contate o administrador para que atualização seja feita no banco de dados.\n");

                XFrmOptionPane.ShowListTextArea(lista, "Falha na inicialização do Entity framework");
            }
            //seta os flags
            finally
            {
                Trace.WriteLine("Fechando conexao Sql: " + task.Result.Database.Connection.State);
                task.Result.Database.Connection.Close();
            }

            //termine a barra
            SplashScreenManager.CloseForm();

            if (Failed)
            {
                //Termine a aplicação em caso de erros
                Environment.Exit(0);
                //Application.Exit();
            }
            else
                Console.WriteLine("Entity framework iniciado com sucesso");


            return Sucess;
        }

        /// <summary>
        /// Inicia o entityframework e invoca o form informado se a inicialização foi bem sucedida.
        /// </summary>
        /// <param name="connectionString"></param>
        /// Form a ser chamado
        public static async Task<bool> Start<T>(string connectionString) where T : class
        {
            SplashScreenManager.ShowForm(typeof(WaitEntityFramework));
            var context = new GenericContextIts<T>(connectionString);

            try
            {
                Trace.WriteLine("Iniciando Contexto");
                var dbEf = context.Database;

                //verifica e cria o banco caso ele nao exista
                dbEf.CreateIfNotExists();

                //realiza a conexao com o sql
                await dbEf.Connection.OpenAsync();

                //Flag que foi iniciado com sucesso
                Sucess = true;

                Trace.WriteLine("Connection Status: " + dbEf.Connection.State);
                try
                {
                    //faz uma consulta no EF
                    var list = context.Set<T>().ToList<T>();
                    Console.WriteLine(list.ToString());
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    //Nao importa
                    LoggerUtilIts.ShowExceptionLogs(ex);
                }

            }
            catch (Exception ex)
            {
                //Flag de erro
                Failed = true;
                LoggerUtilIts.ShowExceptionLogs(ex);
                var lista = new List<string>();

                lista.Add("O contexto atual não corresponde a estrutura do banco de dados.");
                lista.Add("Contate o administrador para que atualização seja feita no banco de dados.\n");

                XFrmOptionPane.ShowListTextArea(lista, "Falha na inicialização do Entity framework");


            }
            //seta os flags
            finally
            {
                Trace.WriteLine("Fechando conexao Sql: " + context.Database.Connection.State);
                context.Database.Connection.Close();
            }


            if (Failed)
            {
                //Termine a aplicação em caso de erros
                Environment.Exit(0);
                Application.Exit();
            }
            //termine a barra
            SplashScreenManager.CloseForm();
            return Sucess;
        }

        private void WaitEntityFramework_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (this.progressPanel1.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
               {
                   this.progressPanel1.Caption = "  Iniciando ...";

               }));
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

        public enum WaitFormCommand { }

    }
}