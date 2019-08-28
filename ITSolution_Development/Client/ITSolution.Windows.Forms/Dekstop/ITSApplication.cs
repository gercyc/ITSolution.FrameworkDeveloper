using ITSolution.Framework.BaseClasses.Trace;
using ITSolution.Framework.BaseInterfaces;
using ITSolution.Framework.Common.BaseClasses;
using ITSolution.Framework.Common.BaseClasses.CommonEntities;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSolution.Framework.Windows.BaseForms
{
    public partial class ITSApplication : Component, IITSTools
    {
        string _sessionID;
        public IITSTools ITSTools { get; private set; }
        private ITSFrameworkServer FrameworkServer { get { return OpenConnection<ITSFrameworkServer>(Consts.FrameworkServerClass); } }
        private List<TraceClass> _traceList;
        IITSDesktop _ancestorDesktop;
        MemoryTraceListener memoryTraceListener;
        public IITSDesktop AncestorDesktop
        {
            get { return _ancestorDesktop; }
            set { _ancestorDesktop = value; }
        }

        public ITSApplication()
        {
            InitializeComponent();
            ITSTools = this;
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            AppDomain.CurrentDomain.TypeResolve += CurrentDomain_TypeResolve;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Init();
        }
        public ITSApplication(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        public ITSApplication(IITSDesktop _itsDesktop) : this()
        {
            this._ancestorDesktop = _itsDesktop;
        }
        private void Init()
        {
            _sessionID = Guid.NewGuid().ToString();
            _traceList = new List<TraceClass>();

            if (memoryTraceListener == null)
            {
                memoryTraceListener = (MemoryTraceListener)Activator.CreateInstance(typeof(MemoryTraceListener));
            }
            memoryTraceListener.CreateThread(memoryTraceListener);
            TraceServerListener.Get<MemoryTraceListener>(_sessionID);

            //StaticInfo.CheckSessions();
        }



        #region Events
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            XMessageIts.ExceptionMessage((Exception)e.ExceptionObject);
        }

        private Assembly CurrentDomain_TypeResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string fName = AppDomain.CurrentDomain.FriendlyName;
                string pathAsm = Path.Combine(baseDir, fName);
                Assembly asmTransaction;

                asmTransaction = Assembly.LoadFile(pathAsm);

                return asmTransaction;
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
                throw ex;
            }
        }

        private void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            FrameworkServer.UnRegisterSession(_sessionID);
        }
        #endregion

        #region IITSTools implementation
        public string SessionID { get { return _sessionID; } }
        public List<TraceClass> TraceList { get { return _traceList; } }
        private void InternalShowTransaction(IITSTransaction _itsTransaction, TransactionInfo transactionInfo = null)
        {
            try
            {
                Trace("Creating transaction " + _itsTransaction.GetTransactionText());
                _itsTransaction.ITSTools = this.ITSTools;
                if (_ancestorDesktop.IsMdiContainer)
                {
                    _itsTransaction.MdiParent = (Form)_ancestorDesktop;
                    if (transactionInfo != null)
                        _itsTransaction.TransactionInfo = transactionInfo;

                    Trace("Create succesful!");
                    _itsTransaction.Show();
                }
                else
                    _itsTransaction.ShowDialog();
            }
            catch (Exception ex)
            {
                Trace(string.Format("ITSApplication.ShowTransaction: '{0}' StackTrace: '{1}'", ex.Message, ex.StackTrace));
                LoggerUtilIts.WriteOnEventViewer(ex.Message, ex.StackTrace);
                XMessageIts.Mensagem(string.Format("Transação não encontrada!"));
            }
        }
        public void ShowTransaction(IITSTransaction _itsTransaction)
        {
            InternalShowTransaction(_itsTransaction);
        }

        public T OpenConnection<T>(string Url)
        {
            return ITSActivator.OpenConnection<T>(Url);
        }

        public bool LoginUser(string logon, string senha, out string msg)
        {
            ItsUser user = InternalLogin(logon, senha);
            msg = string.Empty;

            if (user == null)
            {
                msg = "Usuário ou senha inválidos.";
            }

            return user != null;
        }

        private ItsUser InternalLogin(string logon, string senha)
        {
            ItsUser user = null;

            try
            {
                //codifica a senha pois ela foi criptografa no banco
                //entao nao sabemos qual é a verdadeira senha
                var result = ASCIIEncodingIts.Coded(senha);

                using (var ctx = new GenericContextIts<ItsUser>(AppConfigManager.Configuration.ConnectionString))
                {
                    if (logon.IsContainsLetters())

                    {
                        //busca o User com a senha codificada
                        user = ctx.Dao
                            .Where(u => u.NomeUtilizador == logon && u.Senha == result).First();
                    }
                    else
                    {
                        //tente pelo ID
                        var id = ParseUtil.ToInt(logon);
                        var users = ctx.Dao.FindAll();
                        user = ctx.Dao
                            .Where(u => u.IdUsuario == id).First();
                    }
                }

                //se achou o usuario, registre a sessao no servidor.
                if (user != null)
                {
                    FrameworkServer.RegisterSession(_sessionID);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        public bool Login(string logon, string senha)
        {
            return InternalLogin(logon, senha) != null;
        }

        public void Trace(string Message)
        {
            TraceClass traceClass = new TraceClass()
            {
                Message = Message,
                Action = string.Format("Trace from application assembly: {0} ", Assembly.GetExecutingAssembly().FullName)
            };
            _traceList.Add(traceClass);
            TraceServer.Trace(traceClass);
        }

        public void ShowTransactionByShortcut(string _traShortcut)
        {
            ITSTransaction tra;
            Trace("Creating transaction by shortcut " + _traShortcut);
            try
            {
                using (var ctx = new GenericContextIts<TransactionInfo>(AppConfigManager.Configuration.ConnectionString))
                {
                    TransactionInfo traInfo = ctx.Dao.Where(t => t.TransactionShortcut == _traShortcut).FirstOrDefault();
                    if (traInfo != null)
                    {
                        tra = ((ITSTransaction)Activator.CreateInstance(Type.GetType(traInfo.TransactionType)));
                        tra._transactionInfo = traInfo;

                        InternalShowTransaction(tra, traInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace(string.Format("ITSApplication.ShowTransactionByShortcut: '{0}' StackTrace: '{1}'", ex.Message, ex.StackTrace));
                LoggerUtilIts.WriteOnEventViewer(ex.Message, ex.StackTrace);
                XMessageIts.Mensagem(string.Format("Não foi encontrada uma transação com o atalho '{0}'", _traShortcut));
            }

        }

        #endregion

        


    }
}
