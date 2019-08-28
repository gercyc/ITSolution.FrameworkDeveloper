using DevExpress.DashboardCommon.Viewer;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Beans.ProgressBar;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using ITSolution.Framework.Validador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 * @author Filipe   
 * @Data   25/07/2015     
 * Changes Metódos assincronos
 * Configuração do bloqueio de várioas Threads simultaneamente usando Task
 */
namespace ITSolution.Framework.Dao.Repositorio.Base
{
    /// <summary>
    /// Essa classe trata diversas funcionalidades do banco de dados
    /// Principais funcionalidades: Create, Update, Delete, Find, FindAll, Where etc.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Dao<T> : IDao<T>, IDisposable where T : class
    {
        #region Declaracao de variaveis
        /**Variavel para verificar se a entidade for persistido com sucesso no banco*/
        protected bool save;
        /**Variavel para verificar se a entidade for atualizado com sucesso no banco*/
        protected bool update;
        /**Variavel para verificar se a entidade for removido com sucesso no banco*/
        protected bool delete;
        /**Variavel para verificar se a entidade for removido com sucesso no banco*/
        protected bool changes;
        /**Variavel para verificar se o contexto foi liberado*/
        protected bool dispose;
        /**Contexto do contexto chamado internamente*/
        private DbContextIts contexto;
        /**Dados do Contexto chamado internamente*/
        public DbSet<T> DbSet { get; private set; }

        /// <summary>
        /// Controlador de comportamento do contexto
        /// </summary>

        public EntryIts<T> Entry { private set; get; }

        #endregion Fim da declaracao de variaveis

        #region Construtores

        ///  <summary>
        /// Recebe o contexto que recebe a string de conexão do banco a ser manipulado 
        ///  </summary>
        public Dao(DbContextIts contexto)
        {
            this.update = false;
            this.save = false;
            this.delete = false;
            this.dispose = false;
            this.contexto = contexto;
            //Set eh o DbSet que todo contexto tem
            this.DbSet = this.contexto.Set<T>();


            this.Entry = new EntryIts<T>(this.contexto);

        }

        #endregion Construtores

        #region Controle de Persistência - Data Access Object (Dao)

        private string msgErrorTransaction(T entidade, Exception ex)
        {
            var inner = ex.InnerException != null
                ? ex.InnerException.InnerException
                : null;

            //Tentativa de inserção de dados em duplicidade
            if (inner == null)

                //restricao unique
                return "A informação : \"" + entidade.ToString() + "\" já existe !";
            else
            {

                if (inner.ToString().Contains("Cannot insert duplicate key")
                    || inner.ToString().Contains("dados em duplicidade"))
                    return "Tentativa de inserção de dados em duplicidade: "
                           + entidade.GetType().Name + "\n"
                           + inner.Message;

                else
                    return (inner.Message + "Falha durante transação");
            }

        }

        /// <summary>
        /// Salva os dados do objeto no banco de dados
        /// </summary>
        /// <param colName="entidade"></param>
        /// <returns>true salvo com sucesso caso contrário false</returns>
        public virtual bool Save(T entidade)
        {
            if (DebugEntidade(entidade))
            {
                try
                {
                    DbSet.Add(entidade);
                    save = SaveChanges();
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(DbUpdateException))
                    {
                        //XMessageIts.Erro(msgErrorTransaction(entidade, ex), "Duplicidade ou inconsistência");
                        throw new DebugDao(ex, entidade, false);
                    }
                    else
                    {
                        throw new DebugDao(ex, entidade);
                    }

                }
            }
            return save;
        }

        /// <summary>
        /// Atualiza os dados do objeto no banco de dados.
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns>true atualizado com sucesso caso contrário false</returns>
        public virtual bool Update(T entidade)
        {
            if (DebugEntidade(entidade))
            {
                var tra = false;
                try
                {

#if DEBUG
                    //https://stackoverflow.com/questions/32675411/the-relationship-could-not-be-changed-because-one-or-more-of-the-foreign-key-pro
                    contexto.ChangeTracker.DetectChanges(); // Force EF to match associations.
                    var objectContext = ((IObjectContextAdapter)contexto).ObjectContext;
                    var objectStateManager = objectContext.ObjectStateManager;
                    var fieldInfo = objectStateManager.GetType().GetField("_entriesWithConceptualNulls", BindingFlags.Instance | BindingFlags.NonPublic);
                    var conceptualNulls = fieldInfo.GetValue(objectStateManager);

#endif
                    contexto.Entry<T>(entidade).State = EntityState.Modified;
                    this.update = SaveChanges();
                    tra = this.update;
                    return tra;
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(DbUpdateException))
                    {
                        XMessageIts.Erro(msgErrorTransaction(entidade, ex), "Duplicidade ou inconsistência");
                        new DebugDao(ex, entidade, false);
                    }
                    else
                        throw new DebugDao(ex, entidade);
                }
            }
            return update;
        }

        /// <summary>
        /// Apaga o objeto do contexto(Memória) e do banco de dados.
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns>true apagado com sucesso caso contrário false</returns>
        public virtual bool Delete(T entidade)
        {
            if (DebugEntidade(entidade))
            {
                try
                {
                    //avisa que a entidade deve ser removida
                    contexto.Entry<T>(entidade).State = EntityState.Deleted;
                    //apague a entidade
                    T x = DbSet.Remove(entidade);
                    delete = SaveChanges();
                }

                catch (Exception ex)
                {
                    throw new DebugDao(ex, entidade);
                }
            }
            return delete;

        }

        /// <summary>
        /// Deleta um objeto no banco de dados
        /// </summary>
        /// <param colName="predicate"></param>
        public virtual bool Delete(Func<T, bool> predicate)
        {
            try
            {
                DbSet.Where(predicate).ToList().ForEach(del => DbSet.Remove(del));
                delete = SaveChanges();
            }
            catch (Exception ex)
            {
                var type = typeof(T);
                T entidade = ReflectionIts.CreateInstance(type) as T;

                throw new DebugDao(ex, entidade);
            }
            return delete;

        }

        /// <summary>
        /// Efetiva todas as alterações em memoria no banco de dados         
        /// </summary>
        /// <returns>true efetivado com sucesso caso contrário false</returns>
        private bool SaveChanges()
        {
            Exception exception = null;
            try
            {
                //0 OK caso contrario false
                contexto.SaveChanges();
                changes = true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                changes = false;
                exception = ex;
                throw ex;
            }

            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                changes = false;
                exception = ex;
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                changes = false;
                exception = ex;
            }
            catch (ObjectDisposedException ex)
            {
                changes = false;
                exception = ex;
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                changes = false;
                exception = ex;
                throw ex;

            }
            catch (Exception ex)
            {
                changes = false;
                exception = ex;
                throw ex;

            }

            return changes;

        }

        /// <summary>
        /// Atualiza o objeto de maneira assincrona no banco de dados.
        /// </summary>
        /// <param name="entidade"></param>Entidade a ser atualizada
        /// <returns>true atualizado com sucesso caso contrário false</returns>
        public async Task<Boolean> UpdateAsync(T entidade)
        {
            if (DebugEntidade(entidade))
            {
                try
                {
                    contexto.Entry<T>(entidade).State = EntityState.Modified;
                    var r = await contexto.SaveChangesAsync();
                    if (r > 0)
                        this.save = true;

                }
                catch (DbUpdateException ex)
                {
                    this.save = false;
                    throw new DebugDao(ex, entidade);
                }
                catch (Exception ex)
                {
                    this.save = false;
                    throw new DebugDao(ex, entidade);
                }
            }
            return save;
        }


        /// <summary>
        /// Salva o objeto de maneira assincrona
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public async Task<bool> SaveAsync(T entidade)
        {
            if (DebugEntidade(entidade))
            {
                try
                {
                    DbSet.Add(entidade);
                    var i = await contexto.SaveChangesAsync();

                    save = i == 1 ? true : false;
                }
                catch (DbUpdateException ex)
                {
                    throw new DebugDao(ex, entidade);
                }
                catch (Exception ex)
                {
                    throw new DebugDao(ex, entidade);
                }
            }
            return save;

        }

        #endregion Fim do Controle Dao

        #region Controle de Persistência (Em Memória) - Data Access Object (Dao)
        /// <summary>
        /// Salva os dados memória
        /// </summary>
        /// <param colName="entidade"></param>
        /// <returns>true salvo com sucesso caso contrário false</returns>
        public bool SaveInMemory(T entidade)
        {
            if (DebugEntidade(entidade))
            {
                try
                {
                    DbSet.Add(entidade);
                }
                catch (Exception ex)
                {
                    //Para por ae
                    throw new DebugDao(ex, entidade);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Atualiza os dados em memória
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns>true atualizado com sucesso caso contrário false</returns>
        public bool UpdateInMemory(T entidade)
        {
            if (DebugEntidade(entidade))
            {
                try
                {
                    contexto.Entry(entidade).State = EntityState.Modified;
                }
                catch (Exception ex)
                {
                    //Para por ae
                    throw new DebugDao(ex, entidade);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Deleta um objeto em memória (Contexto)
        /// </summary>
        /// <param colName="predicate"></param>
        public virtual bool DeleteInMemory(Func<T, bool> predicate)
        {
            try
            {
                DbSet.Where(predicate).ToList().ForEach(del => DbSet.Remove(del));
            }
            catch (Exception ex)
            {
                var type = typeof(T);
                T entidade = ReflectionIts.CreateInstance(type) as T;
                //Para por ae
                throw new DebugDao(ex, entidade);
            }

            return true;

        }

        #endregion Persistência em memória

        #region DML


        /// <summary>
        ///Verifica se existe um ou mais elemetos na tabela.
        ///<br>
        ///Exceptions:
        ///</br>
        ///T:System.ArgumentNullException:
        ///<br>     source is null.</br>
        ///<br>T:System.InvalidOperationException:</br>
        ///<br>The source sequence is empty.</br>
        /// </summary>
        /// <returns>true existe 1 ou mais caso contrário false</returns>
        public bool CheckFirst()
        {
            try
            {
                var f = First();//passou daqui ta ok
                return true;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Primeiro nao existe");
                LoggerUtilIts.ShowExceptionLogs(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Primeiro nao existe");
                LoggerUtilIts.ShowExceptionLogs(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Primeiro Elemento da lista
        ///     Lança exceção
        /// </summary>
        /// <returns></returns>
        public T First(Func<T, bool> predicate = null)
        {
            try
            {
                if (predicate == null)
                    return this.DbSet.ToList().First<T>();
                else
                    return this.DbSet.Where(predicate).First<T>();

            }
            catch (InvalidOperationException ex)
            {
                //   T:System.InvalidOperationException:
                //     The source sequence is empty.
                // nao esta na sequencia
                LoggerUtilIts.ShowExceptionLogs(ex);
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                //   source is null.
                LoggerUtilIts.ShowExceptionLogs(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Último Elemento da lista
        /// </summary>
        /// <returns></returns>
        public T Last(Func<T, bool> predicate = null)
        {
            try
            {
                if (predicate == null)
                    return this.DbSet.ToList().Last<T>();
                else
                    return this.DbSet.Where(predicate).Last<T>();
            }

            catch (InvalidOperationException ex)
            {
                //   T:System.InvalidOperationException:
                //     The source sequence is empty.
                // nao esta na sequencia
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
            catch (ArgumentNullException ex)
            {
                //   source is null.
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
            return null;
        }

        /// <summary>
        /// Obtém a lista de todos os elementos da tabela.
        /// </summary>
        /// <returns>A lista com todos os dados do objeto do banco de dados</returns>
        public List<T> FindAll()
        {
            List<T> lista = new List<T>();
            try
            {
                return lista = DbSet.ToList();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(EntityCommandExecutionException))
                    XMessageIts.Erro("Falha ao obter todos os dados da tabela\n",
                        "Falha crítica na estrutura do banco de dados!");
                var type = typeof(T);
                T entidade = ReflectionIts.CreateInstance(type) as T;
                throw new DebugDao(ex, entidade);
            }
        }

        /// <summary>
        /// Obtém a lista de todos os elementos da tabela.
        /// </summary>
        /// <returns>A lista com todos os dados do objeto do banco de dados</returns>
        public List<T> FindAll(int size)
        {
            List<T> lista = new List<T>();
            try
            {
                var query = (from p in DbSet select p).Take(size);

            }
            catch (Exception ex)
            {
                XMessageIts.Mensagem("Falha ao obter todos os dados da tabela\n\n"
                                     + ex.Message);
            }
            return lista;
        }

        /// <summary>
        /// Obtém a lista de todos os elementos da tabela.
        /// 
        /// EntityFramework cannot convert DateTime.Date to SQL. 
        /// So, it fails to generate expected SQL. 
        /// Instead of that you can use DbFunctions.TruncateTime() method if you want to get Date part only:
        /// DbFunctions.TruncateTime(prop)
        /// </summary>
        /// <returns>A Queryable com todos os dados do objeto do banco de dados</returns>
        public DbSet<T> Controller()
        {
            try
            {
                return DbSet;
            }
            catch (Exception ex)
            {
                LoggerUtilIts.GenerateLogs(ex, "Falha ao retorna o controlador do dao.");

            }
            return null;
        }

        /// <summary>
        /// Obtém a lista de todos os elementos da tabela.
        /// </summary>
        /// <param name="predicate"></param>Expressão
        /// <returns>A Queryable com todos os dados do objeto do banco de dados</returns>
        public IQueryable<T> Where(Func<T, bool> predicate)
        {
            try
            {
                return this.DbSet.Where(predicate).AsQueryable();
            }
            catch (ArgumentNullException ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Obtém um objeto da tabela pela chave primária.
        /// </summary>
        /// <returns>Um objeto do banco de dados</returns>
        public T Find(params object[] key)
        {

            if (key == null || String.IsNullOrWhiteSpace(key.ToString()))
            {
                return null;
            }

            try
            {
                return DbSet.Find(key);
            }
            catch (InvalidOperationException ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
            catch (Exception ex)
            {
                //rolou um treta nao esperada
                string msg = "Falha localizar objeto pela chave primária.";
                Console.WriteLine(msg + "\n" + ex.Message);
            }
            return null;
        }

        #endregion DML

        #region DML - Assincronos

        /// <summary>
        /// Primeiro Elemento da lista
        /// </summary>
        /// <returns></returns>
        public async Task<T> FirstAsync(Func<T, bool> predicate = null)
        {
            try
            {
                if (predicate == null)
                {
                    var r = await this.DbSet.ToListAsync();
                    return r.First();
                }
                else
                {
                    var task = await this.DbSet.ToListAsync();
                    var r = task.Where(predicate);
                    return r.First();
                }
            }
            catch (InvalidOperationException ex)
            {
                //   T:System.InvalidOperationException:
                //     The source sequence is empty.
                // nao esta na sequencia
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
            catch (ArgumentNullException ex)
            {
                //   source is null.
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
            }

            return null;
        }

        /// <summary>
        /// Último Elemento da lista
        /// </summary>
        /// <returns></returns>
        public async Task<T> LastAsync(Func<T, bool> predicate = null)
        {
            try
            {
                if (predicate == null)
                {
                    var r = await this.DbSet.ToListAsync();
                    return r.Last();
                }
                else
                {
                    var task = await this.DbSet.ToListAsync();
                    var r = task.Where(predicate);
                    return r.Last();
                }
            }

            catch (InvalidOperationException ex)
            {
                //   T:System.InvalidOperationException:
                //     The source sequence is empty.
                // nao esta na sequencia
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
            catch (ArgumentNullException ex)
            {
                //   source is null.
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
            }
            return null;
        }

        /// <summary>
        /// Obtém um objeto da tabela pela chave primária.
        /// </summary>
        /// <returns>Um objeto do banco de dados</returns>
        public async Task<T> FindAsync(params object[] key)
        {

            if (key == null || String.IsNullOrWhiteSpace(key.ToString()))
            {
                return null;
            }

            try
            {
                return await DbSet.FindAsync(key);
            }
            catch (InvalidOperationException ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                return null;

            }
            catch (Exception ex)
            {
                string msg = "Falha localizar objeto pela chave primária.";
                XMessageIts.ExceptionJustMessage(ex, msg);

            }
            return null;
        }

        /// <summary>
        /// Obtém a lista de todos os elementos da tabela (Assincrono).
        /// </summary>
        /// <returns>A lista com todos os dados do objeto do banco de dados</returns>
        public async Task<List<T>> FindAllAsync(int count = 0)
        {
            List<T> lista = new List<T>();
            try
            {
                lista = await DbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                var type = typeof(T);
                T entidade = ReflectionIts.CreateInstance(type) as T;
                throw new DebugDao(ex, entidade);
            }

            if (count > 0)
                return lista.Take(count).ToList();

            return lista;
        }

        /// <summary>
        /// Obtém a os elementos da tabela a partir de uma condição (Assincrono).
        /// </summary>
        /// <returns>Um resultado de uma lista com todos os dados da condição </returns>
        public async Task<List<T>> WhereAsync(Func<T, bool> predicate)
        {
            try
            {
                return await Task.Run(() => Where(predicate).ToList());

            }
            catch (Exception)
            {

                return new List<T>();
            }
        }

        /// <summary>
        /// Versao BETA
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var changesAsync = await contexto.SaveChangesAsync(cancellationToken);
            return changesAsync;
        }

        /// <summary>
        /// Nao testado
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await this.SaveChangesAsync(CancellationToken.None);
        }

        #endregion  

        #region Metodos Assincronos - Threads Safe on Components DevExpress

        /// <summary>
        /// Preenche o grid de maneira assincrona e exibe uma barra de progresso durante o processo.
        /// Esse metódo deve ser chamad com o tratamento abaixo:
        /// if (this.gridControl.InvokeRequired)
        /// {
        ///     this.Invoke(new MethodInvoker(delegate{
        ///         Context.Entidade.FillGridControl(gridControl, taskName);
        ///      }));
        /// }
        /// É necessário disparar uma thread que estará em primeiro plano
        ///  new Thread(Tarefa).Start();
        /// </summary>
        /// <param name="gridControl"></param>
        /// <param name="taskName"></param>
        public async void FillGridControl(GridControl gridControl, string taskName = null)
        {
            //inicia a barra
            XFrmWait.ShowSplashScreen(taskName);
            var lista = await FindAllAsync();
            gridControl.DataSource = lista;

            //termina a barra
            XFrmWait.CloseSplashScreen();
        }

        /// <summary>
        /// Preenche o grid de maneira assincrona e exibe uma barra de progresso durante o processo.
        /// Esse metódo deve ser chamad com o tratamento abaixo:
        /// if (this.comboBox.InvokeRequired)
        /// {
        ///     this.Invoke(new MethodInvoker(delegate{
        ///         Context.Entidade.FillGridControl(gridControl, taskName);
        ///      }));
        /// }
        /// É necessário disparar uma thread que estará em primeiro plano
        ///  new Thread(Tarefa).Start();
        /// </summary>
        /// </summary>
        /// <param name="comboBox"></param>ComboBox
        /// <param name="taskName"></param>Nome da tarefa
        public async void FillComboBoxEdit(ComboBoxEdit comboBox, string taskName = null)
        {
            XFrmWait.ShowSplashScreen(taskName);

            var lista = await FindAllAsync();
            comboBox.Properties.Items.Clear();
            comboBox.SelectedItem = null;
            comboBox.Properties.Items.AddRange(lista);

            if (lista.Count > 0)
            {
                comboBox.SelectedItem = lista[0];
            }
            //termina a barra
            XFrmWait.CloseSplashScreen();


        }

        /// <summary>
        /// Preenche o grid de maneira assincrona e exibe uma barra de progresso durante o processo.
        /// Esse metódo deve ser chamad com o tratamento abaixo:
        /// if (this.gridLookUp.InvokeRequired)
        /// {
        ///     this.Invoke(new MethodInvoker(delegate{
        ///         Context.Entidade.FillGridLookup(gridControl, taskName);
        ///      }));
        /// }
        /// É necessário disparar uma thread que estará em primeiro plano
        ///  new Thread(Tarefa).Start();        
        /// </summary>
        /// <param name="comboBox"></param>GridLookUp
        /// <param name="taskName"></param>Nome da tarefa
        public async void FillGridlLookUp(GridLookUpEdit gridLookUp, string taskName = null)
        {
            XFrmWait.ShowSplashScreen(taskName);

            var lista = await FindAllAsync();

            gridLookUp.Properties.DataSource = lista;

            //termina a barra
            XFrmWait.CloseSplashScreen();
        }

        /// <summary>
        /// Carrega todos os dados no grid control assincrono
        /// </summary>
        /// <param name="form"></param>
        /// <param name="gridControl"></param>
        /// <returns></returns>
        public async Task FillGridControlAsync(Form form, GridControl gridControl)
        {
            try { SplashScreenManager.ShowForm(typeof(XFrmWait)); }
            catch { }
            var source = await this.FindAllAsync();

            gridControl.DataSource = source;

            //termina a barra
            try { SplashScreenManager.CloseForm(); }
            catch { }

        }

        /// <summary>
        /// Carrega todos os dados no grid control assincrono, com ordenação OrderByDescending
        /// </summary>
        /// <param name="form"></param>
        /// <param name="gridControl"></param>
        /// <returns></returns>
        public async Task FillGridControlAsync(Form form, GridControl gridControl, String fieldOrdenacao)
        {
            XFrmWait.ShowSplashScreen();
            var source = await this.FindAllAsync();
            //pegue o tipo do primeiro item da source
            Type t = source.Count > 0 ? source[0].GetType() : null;
            if (source.Count > 0)
            {
                //http://stackoverflow.com/questions/188141/list-orderby-alphabetical-order
                gridControl.DataSource = source.OrderByDescending(r => t.InvokeMember(fieldOrdenacao,
                    System.Reflection.BindingFlags.GetProperty,
                    null,
                    r,
                    null));
            }
            else
            {
                gridControl.DataSource = source;
            }

            //termina a barra
            XFrmWait.CloseSplashScreen();
        }

        #endregion 

        #region Eventos

        /// <summary>
        /// Chamado automaticamente quando usado o using 
        /// Libera a memória do Contexto
        /// </summary>
        public void Dispose()
        {
            try
            {
                contexto.Dispose();
                contexto.IsDispose = true;
            }
            catch (Exception ex)
            {
                XMessageIts.Mensagem("Falha ao liberar a memória do objeto de Contexto\n\n"
                                     + ex.Message);
            }
        }

        /// <summary>
        /// true se a entidade foi salvo caso contrário false
        /// </summary>
        /// <returns></returns>
        public bool IsSave()
        {
            return changes && save;
        }

        /// <summary>
        /// true se alteracões foram realizadas caso contrário false
        /// </summary>
        /// <returns></returns>
        public bool IsUpdate()
        {
            return changes && update;
        }

        /// <summary>
        /// se a entidade foi eliminado caso contrário false
        /// </summary>
        /// <returns></returns>
        public bool IsDelete()
        {
            return changes && delete;
        }

        /// <summary>
        /// true se o contexto sofreu alteração no CRUD caso contrário false
        /// </summary>
        /// <returns></returns>
        public bool IsChanges()
        {
            return changes;
        }

        #endregion Metodos

        #region Debug Dao

        /// <summary>
        /// Tratamento pre persistência
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        private bool DebugEntidade(T entidade)
        {
            return ValidadorDTO.ValidateWarningAll(entidade);
        }

        /// <summary>
        /// Chamado para debugar cada metodo da classe
        /// </summary>
        private class DebugDao : Exception
        {
            /// <summary>
            /// Gera um mensagem gráfica com os dados da exceção.
            /// </summary>
            /// <param colName="ex"></param>
            public DebugDao(Exception ex, T t, bool errorMessage = true)
                : base(ex.Message)
            {
                var type = ex.GetType();
                var classe = t.GetType();
                //Logs
                string dirLogDao = @"C:\logs\its\dao";
                string title = "Relatório de logs\n";
                string excecao = "Erros de persistência: " + type;
                string entity = "\nClasse de ocorrência: " + classe;
                string data = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");

                var inner = ex.InnerException == null
                              ? "Nenhuma exceção interna"
                              : ex.InnerException.Message + "";
                //Uso o método Write para escrever o arquivo que será adicionado no arquivo texto
                string msg = "Mensagem: " + ex.Message + "\n" +
                    "Pilha de erros: " + ex.StackTrace + "\n" +
                "Exceção interna: " + inner;


                var fileName = type + "-" + data + ".txt";
                var pathLog = Path.Combine(dirLogDao, fileName);

                //cria o dir
                FileManagerIts.CreateDirectory(dirLogDao);

                //write logs
                FileManagerIts.AppendTextFileException(pathLog, ex, new string[] { title, excecao, entity, data, msg });

                //exibe o log na saida padrao
                LoggerUtilIts.ShowExceptionLogs(ex);

                if (errorMessage)
                    //avisa do erro
                    XMessageIts.ExceptionJustMessage(ex, null, "Falha crítica no banco de dados");
            }

        }

        #endregion Debug para Dao

    }
}
