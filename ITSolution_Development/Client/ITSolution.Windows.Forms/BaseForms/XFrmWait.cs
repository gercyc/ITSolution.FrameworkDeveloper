using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;
using System.Threading;
using System.Threading.Tasks;
using ITSolution.Framework.Util;
using DevExpress.XtraSplashScreen;
using ITSolution.Framework.Mensagem;

namespace ITSolution.Framework.Windows.Forms.BaseForms
{
    public partial class XFrmWait : WaitForm
    {
        #region Variaveis e propriedades get set
        public bool Started { get; set; }
        public bool Sucess { get; set; }
        public bool Failed { get; set; }
        public bool Cancel { get; set; }

        /// <summary>
        /// Nome da tarefa a ser exibido no caption
        /// </summary>
        private static string TaskName { get; set; }

        /// <summary>
        /// Tempo minimo de exibição do form em milisegundos
        /// </summary>
        public static int TaskInterval { get; set; }

        //private int reticencia;

        #endregion

        /// <summary>
        /// O delegate void recebe por padrao um função sem retorno (void)
        /// </summary>
        private delegate void RunTask();

        #region Construtores
        public XFrmWait()
        {
            InitializeComponent();

            TaskInterval = 1000;

            if (TaskName == null)
                TaskName = "Executando tarefa ...";

            //Nao cabe na tela
            //if (TaskName.Length > 26)
            //  TaskName = TaskName.Substring(0, 25);

            this.Size = resizeScreen(TaskName);


            this.Failed = false;
            this.Cancel = false;
            this.Started = false;
            this.Sucess = false;

            this.progressPanel1.Caption = TaskName;
            this.progressPanel1.Description = "Por favor aguarde";

        }

        #endregion

        #region Eventos

        private void XFrmWait_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Sucess = true;
            //volta o padrao do label
            XFrmWait.TaskName = "Executando tarefa ....";

            //Exiba
            this.progressPanel1.BeginInvoke(new Action(() =>
            {
                this.progressPanel1.Caption = "Tarefa concluída";
            }));
            //o form nao eh chamado de forma convencional com new 
            //entao nao posso da Invoke ou BeginInvoke
            //this.progressPanel1.BeginInvoke(new RunTask(InvokeMethod));
            //this.Invoke(new MethodInvoker(delegate
            //{
            //    this.progressPanel1.Caption = "Tarefa concluída";
            //}));
            Thread.Sleep(150);


        }

        private void XFrmWait_Shown(object sender, EventArgs e)
        {
            //monitora a tarefa
            Task.Factory.StartNew(() => loggerOut());
        }


        private void XFrmWait_Paint(object sender, PaintEventArgs e)
        {
        }

        private void XFrmWait_Load(object sender, EventArgs e)
        {
            int i = TaskName.Length;

            if (TaskName != null && i > 15)
            {

                while (i < TaskName.Length)
                {
                    this.Width = Width + 2;
                }
                this.Refresh();
            }
        }

        #endregion


        #region Metódos Internos

        /// <summary>
        /// Gera logs na saida padrão se a tarefa esta sendo executada
        /// </summary>
        private void loggerOut()
        {
            // Access thread-sensitive resources.
            try
            {
                //enquanto o form esta exibido
                while (this.Visible)
                {
                    //Isso manda um repaint na barra nao eh a intencao
                    /*RunTask task = new RunTask(PaintProgress);
                    string text = progressPanel1.Description + ".";

                    this.Invoke(task, new object[] { text });
                    reticencia++;*/

                    Thread.Sleep(150);
                    Console.WriteLine("Tarefa em execução ...");
                }

                //this.progressPanel1.BeginInvoke(new RunTask(InvokeMethod));
                /// <summary>
                /// Ação de terminar a barra de progresso
                /// </summary>


            }
            catch (Exception ex)
            {
                this.Failed = true;
                LoggerUtilIts.ShowExceptionLogs(ex);
            }


            Console.WriteLine("Fim do progresso\nTarefa concluída");
        }

        /// <summary>
        /// Resize message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private Size resizeScreen(string message)
        {
            Graphics g = this.CreateGraphics();
            int width = this.Width;
            Font fonte = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            SizeF size = g.MeasureString(message, fonte);

            if (message.Length < 20)
            {
                if ((int)size.Width > width)
                {
                    width = 350;
                }
            }

            for (int i = 20; i < message.Length; i++)
            {
                width = width + 2;
            }

            return new Size(width, this.Height);
        }

        #endregion

        #region Tarefas assincronas sem retorno (void)
        //Chamado internamente
        private async static void startTask(Task task, string taskName = null, Form form = null)
        {
            if (form != null)
                form.Enabled = false;
            TaskName = taskName;



            try
            {
                //enfilera a tarefa
                Task taskWork = Task.Run(() => task);
                //exibie a barra de progresso
                try { SplashScreenManager.ShowForm(form, typeof(XFrmWait)); }
                catch (Exception ex)
                {
                    /*Nao importa*/
                    Console.WriteLine("Exceção lançada ao exibir SplashScreenManager =>  TaskName->" + taskName
                        + "\nmsg -> " + ex.Message);
                }
                //espera a task acabar
                await taskWork;
                //delay
                Thread.Sleep(100);

                //termine a barra de progresso
                try { SplashScreenManager.CloseForm(); }
                catch (Exception ex)
                {
                    /*Nao importa*/
                    Console.WriteLine("Exceção lançada ao fechar SplashScreenManager =>  TaskName->" + taskName
                        + "\nmsg -> " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                LoggerUtilIts.GenerateLogs(ex, "Tarefa : " + taskName);
                XMessageIts.ExceptionMessageDetails(ex, "Falha na execução da tarefa!");
            }



            if (form != null)
                form.Enabled = true;
        }

        /// <summary>
        /// Inicia uma tarefa do tipo void
        /// Opcional bloqueio do componente a ser manipulado
        ///Ex:
        ///this.Invoke(new MethodInvoker(delegate
        ///{
        ///     Code here
        ///}));
        /// </summary>
        /// <param name="task"></param>Tarefa
        /// <param name="taskName"></param>Mensagem
        public static void StartTask(Task task, string taskName = null)
        {
            startTask(task, taskName);
        }

        ///  <summary>
        ///  Inicia uma tarefa do tipo void
        ///  Opcional bloqueio do componente a ser manipulado
        /// Ex:
        /// this.Invoke(new MethodInvoker(delegate
        /// {
        ///      Code here
        /// }));
        ///  </summary>
        ///  <param name="task"></param>
        /// <param name="form"></param>
        public static void StartTask(Task task, Form form)
        {
            startTask(task, null, form);

        }

        ///  <summary>
        ///  Inicia uma tarefa do tipo void
        ///  Opcional bloqueio do componente a ser manipulado
        /// Ex:
        /// this.Invoke(new MethodInvoker(delegate
        /// {
        ///      Code here
        /// }));
        ///  </summary>
        ///  <param name="task"></param>Tarefa
        ///  <param name="taskName"></param>
        /// <param name="form"></param>
        /// Mensagem
        public static void StartTask(Task task, string taskName, Form form)
        {
            //try { SplashScreenManager.ShowForm(form, typeof(XFrmWait)); }
            //catch
            //{ /*Nao importa*/ }

            //await Task.Run(() => task);

            //try { SplashScreenManager.CloseForm(); }
            //catch
            //{ /*Nao importa*/}
            startTask(task, taskName, form);

        }

        #endregion

        #region Tarefas assincronas com retorno (T)
        //Chamado internamente
        private async static Task<T> startTask<T>(Task<T> task, string taskName = null, Form form = null) where T : new()
        {
            TaskName = taskName;

            try
            {
                if (form == null)
                    SplashScreenManager.ShowForm(typeof(XFrmWait));
                else
                    SplashScreenManager.ShowForm(form, typeof(XFrmWait));
            }
            catch
            { /*Nao importa*/ }

            var result = await Task.Run(() => task);

            Thread.Sleep(100);

            try { SplashScreenManager.CloseForm(); }
            catch
            { /*Nao importa*/}

            return result;
        }


        /// <summary>
        /// Inicia uma tarefa com um retorno T
        /// Necessário bloqueio do componente a ser manipulado
        ///Ex:
        ///this.Invoke(new MethodInvoker(delegate
        ///{
        ///     Code here
        ///}));
        /// <typeparam name="T"></typeparam>
        /// <param name="task"></param>
        /// <param name="taskName"></param>
        public static async Task<T> StartTask<T>(Task<T> task, string taskName = null) where T : new()
        {
            //try { SplashScreenManager.ShowForm(typeof(XFrmWait)); }
            //catch
            //{ /*Nao importa*/ }

            //var result = await Task.Run(() => task);

            //try { SplashScreenManager.CloseForm(); }
            //catch
            //{ /*Nao importa*/}

            //return result;
            return await startTask<T>(task, taskName);
        }

        /// <summary>
        /// Inicia uma tarefa do tipo T
        /// Necessário bloqueio do componente a ser manipulado
        ///Ex:
        ///this.Invoke(new MethodInvoker(delegate
        ///{
        ///     Code here
        ///}));
        /// </summary>
        /// <param name="task"></param>Tarefa
        public static async Task<T> StartTask<T>(Task<T> task, Form form) where T : new()
        {

            //try { SplashScreenManager.ShowForm(typeof(XFrmWait)); }
            //catch
            //{ /*Nao importa*/ }

            //var result = await Task.Run(() => task);

            //try { SplashScreenManager.CloseForm(); }
            //catch
            //{ /*Nao importa*/}

            //return result;
            return await startTask<T>(task, null, form);

        }

        /// <summary>
        /// Inicia uma tarefa com um retorno T
        /// Necessário bloqueio do componente a ser manipulado
        ///Ex:
        ///this.Invoke(new MethodInvoker(delegate
        ///{
        ///     Code here
        ///}));
        /// <typeparam name="T"></typeparam>
        /// <param name="task"></param>
        /// <param name="taskName"></param>
        public static async Task<T> StartTask<T>(Task<T> task, string taskName, Form form) where T : new()
        {
            //try { SplashScreenManager.ShowForm(typeof(XFrmWait)); }
            //catch
            //{ /*Nao importa*/ }

            //var result = await Task.Run(() => task);

            //try { SplashScreenManager.CloseForm(); }
            //catch
            //{ /*Nao importa*/}

            //return result;
            return await startTask<T>(task, taskName, form);
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Exibe a barra de progresso por tempo indeterminado
        /// </summary>
        public static void ShowSplashScreen(string taskName = "Executando tarefa ...")
        {
            if (taskName != null)
                TaskName = taskName;

            try { SplashScreenManager.ShowForm(typeof(XFrmWait)); }
            catch
            { /*Nao importa*/}

        }

        /// <summary>
        /// Termina a thread da barra de barra chamada pela primeira
        /// </summary>
        public static void CloseSplashScreen()
        {
            try { SplashScreenManager.CloseForm(); }
            catch
            { /*Nao importa*/}

        }

        #endregion

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

        public enum WaitFormCommand
        {
        }

        #endregion


    }
}