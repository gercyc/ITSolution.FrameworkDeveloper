using ITSolution.Framework.Beans.Forms;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Listeners;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSolution.Admin.Entidades.EntidadesBd;
using ITSolution.Admin.Forms.Menu;
using ITSolution.Admin.Repositorio;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Forms;
using ITSolution.Framework.BaseClasses;

//Essa classe nao esta padronizada
namespace ITSolution.Admin.Launcher
{
    public class AdminMenuUtil : ActionLogin
    {
        //private Type _typeCtx;
        public static string PREFERENCIAS = Path.Combine(Application.StartupPath, "admin_pref");
        private XFrmLogin _xFrmLogin;
        private Task<AdminDTO> _taskLogin;
        private bool _isInit;
        private bool _isLogon;
        ITSApplication _application;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="isLogon"></param>Esse flag indica que o form setara o tema e devera ser fechado ou nao caso o usuario clique em cancelar.
        public AdminMenuUtil(bool isLogon = true)
        {
            _application = new ITSApplication();
            this._isLogon = isLogon;

            if (isLogon)
                this.setTheme();

            this._xFrmLogin = new XFrmLogin(this);
            //this._typeCtx = typeCtx;
        }

        public void Run(string logon = null)
        {


            this._xFrmLogin.Text = "Acesso ao sistema:";

            //se nao informe
            if (string.IsNullOrEmpty(logon))
            {
                //action form do login dispara o invokeMenu
                //faça login primeiro
                this._xFrmLogin.ShowDialog();

                //se foi cancelado
                if (this._xFrmLogin.IsCancel)
                {
                    if (_isLogon)
                        //termina aplicação
                        Application.Exit();
                }
                else
                {
                    //espera e invoca
                    waitRun();

                }
            }
            else
            {
                //chama a task
                _taskLogin = Task.Run(() => doWorkAsync(logon, "a123"));

                //espera e invoca
                waitRun();
            }
        }

        /// <summary>
        ///Acao de login com verifcacao no no banco de dados
        /// Acesso sera feito somente pra manipular o form do login
        /// </summary>
        /// <param name="logon"></param>Login informado ID/Nome Utilizador
        /// <param name="senha"></param>Senha
        /// <returns></returns>true logado false nao logado
        public  bool Login(string logon, string senha)
        {
            //se foi inciado
            if (this._isInit)
            {
                //rode sequencialmente
                //rodando a tarefa nao asscrinono consigo manipular 
                //o form do login livremente liberando o form somente
                //quando o login for aceito pelo banco de dados
                var user = doWork(logon, senha);
                //se logou deixei entrar
                if (user.IsAdmin)
                    this._xFrmLogin.Dispose();
            }
            else
            {
                //rode assincrono para iniciar o EF
                //rodando essa tarefa a assincrona os metodo do botao login
                //e o metodo Login da interface rodando em paralelo
                //isso implica que o form do login nao eh fechado
                //impedindo a chamada do form menu
                this._taskLogin = Task.Run(() => doWorkAsync(logon, senha));

            }
            return true;
        }

        //Acao disparada pelo botao de login
        //Sequencialmente
        private AdminDTO doWork(string logon, string senha)
        {
            Console.WriteLine("Wait Entityframework initializate ...");

            //aqui eu ja tenho contexto iniciado

            //traz um usuario indexado do banco + login no servidor
            AdminDTO admin = new AdminDTO(logon, senha, true);

            

            if (admin.IsAdmin == false)
            {
                MessageBoxBlack.Show("Usuário \"" + logon + "\" não encontrado.", "Atenção");
                this._xFrmLogin.BringToFront();
            }
            else
            {
                //agora sim feche essa janela 
                this._xFrmLogin.DisposeOnLogin = true;
                this._xFrmLogin.Dispose();
            }
            return admin;
        }

        //Acao disparada pelo botao de login
        //Totalmente assicrono
        private async Task<AdminDTO> doWorkAsync(string logon, string senha)
        {
            AdminDTO admin = new AdminDTO(logon, senha);
            bool result = await WaitEntityFramework.StartTask<Package>(TaskEF());

            //aqui tenho um contexto rodando assincrono
            if (result)
            {
                //ja iniciou nao precisa roda a barra denovo
                //isso impede que outro contexto seja iniciado
                this._isInit = true;

                if (admin.IsAdmin == false)
                {
                    //recria
                    this._xFrmLogin = new XFrmLogin(this);
                    //nao feche essa janela ate logar corretamente
                    this._xFrmLogin.DisposeOnLogin = false;

                    //marque false
                    //mesmo que o form marque true
                    //no banco de dados foi negado o acesso
                    this._xFrmLogin.IsLogin = false;

                    //agora nem esconde esse form mais
                    //fica amarrado ate logar corretamente
                    this._xFrmLogin.IsHideOnLogin = false;

                    MessageBoxBlack.Show("Usuário \"" + logon + "\" ou senha inválido(s).", "Atenção");
                }
                else
                {
                    this._xFrmLogin.IsLogin = true;
                    //agora sim feche essa janela 
                    this._xFrmLogin.DisposeOnLogin = true;
                }

            }


            return admin;
        }

        private DbContextIts createCtx()
        {
            try
            {
                //retorna o pai
                return new AdminContext();
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                return null;
            }

        }

        /// <summary>
        /// Inicia o contexto de forma assincrona
        /// </summary>
        /// <returns></returns>
        private async Task<DbContextIts> TaskEF()
        {
            return await Task.Run(() => createCtx());
        }

        /// <summary>
        /// Aguarde o fim da tarefa e invoca o menu se o contexto foi iniciado e o usuário logado corretamente
        /// </summary>
        private void waitRun()
        {
            try
            {
                _taskLogin.Wait();

            }
            catch (Exception ex)
            {
                string msg = "Ocorreu um erro não identificado ao realizar login.";
                LoggerUtilIts.GenerateLogs(ex, msg);
                //Environment.Exit(0);
                //Application.Exit();
                throw ex;
            }


            //se nao conseguiu logar deu ruim
            if (this._xFrmLogin.IsLogin == false)
            {
                //faz tudo denovo mas dessa vez fica amarrado
                //ou seja nao vai fechar o form ate logar corretamente
                this._xFrmLogin.ShowDialog();
            }

            Console.WriteLine("Task Done");

            AdminDTO admin = _taskLogin.Result;
            //se algum deles existe
            if (admin != null)
            {
                //garante o fim da Task
                _taskLogin.Dispose();

                //invoka a thread que amarra o menu principal
                Application.Run(new XFrmAdminMenu(_application));

            }
        }

        /// <summary>
        /// Seta os grupo de skin disponiveis do DevExpress
        /// Achamada deste metodo deve ser obrigatóriamente antes da inicialização de qualquer form
        /// </summary>
        private void setTheme()
        {
            // The following line provides localization for the application's user interface. 
            Thread.CurrentThread.CurrentUICulture =
                new CultureInfo("pt-BR");

            // The following line provides localization for data formats. 
            Thread.CurrentThread.CurrentCulture =
                new CultureInfo("pt-BR");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            //use o tema DEFAULT do VS
            string skin = "Office 2010 Blue";
            var preferences = FileManagerIts.GetDataFile(PREFERENCIAS);
            if (File.Exists(PREFERENCIAS) && preferences.Count > 0)
                skin = preferences.FirstOrDefault();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skin;

        }


    }
}
