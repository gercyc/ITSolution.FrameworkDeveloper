using ITSolution.Framework.ConnectionFactory;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;
using System.Windows.Forms;
using ITSolution.Framework.Dao.Repositorio.Base;
using ITSolution.Framework.Enumeradores;
using System.Xml;
using System.Data.SqlClient;

namespace ITSolution.Framework.Dao.Contexto
{

    /// <summary>
    /// Introdução do padrão Singleton
    /// Controle do banco de dados.
    /// DDL - Data Definition Language 
    /// Comandos do tipo DDL: CREATE, ALTER ou DROP
    /// Usandos na criação dos objeto: tabelas, procedures, índices, relacionamentos etc.
    /// 
    /// DML - Data Manipulation Language
    /// Comandos dos tipos DML SELECT, INSERT, UPDATE e DELETE. 
    /// Usandos para manipular os dados.
    /// 
    /// Data Control Language (DCL). Os comandos GRANT e REVOKE.
    /// Verificar como fazer isto aqui    
    /// 
    /// </summary>
    public abstract class DbContextIts : DbContext
    {
        //Antes apontavamos pra string do App.config dessa forma
        // ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString

        public string NameOrConnectionString { get; protected set; }

        public bool IsDispose { get; set; }

        public ConnectionFactoryIts ConnectionSql { get; protected set; }

        public string DatabaseName { get { return this.Database.Connection.Database; } }

        /// <summary>
        /// Cria esse banco de dados se ele nao existir
        /// </summary>
        /// <param colName="nameOrConnectionString"></param>
        /// <param name="nameOrConnectionString"></param>
        /// <param name="typeConnection"></param>
        public DbContextIts(string nameOrConnectionString, TypeConnection typeConnection = TypeConnection.SqlServer)
            //tenta codificar a string de conexão ou usa a string original
            : base(nameOrConnectionString)
        {
            //impedir que o EF trunque os valores decimais > 2 casas
            SqlProviderServices.TruncateDecimalsToScale = false;

            this.IsDispose = false;

            //guarda a referencia da string 
            this.NameOrConnectionString = nameOrConnectionString;

            if (this.NameOrConnectionString == null)
            {
                throw new Exception("Connection String not found");
            }
            Exception exception = null;
            try
            {
                this.Database.CreateIfNotExists();
                //avise q o banco deve ser dropado caso haja alteracao 
                Database.SetInitializer<DbContextIts>
                    (new DropCreateDatabaseIfModelChanges<DbContextIts>());

                if (typeConnection == TypeConnection.SqlServer)
                {
                    try
                    {
                        //string conn = AppConfigManager.Configuration.ConnectionStringRuntime;
                        this.ConnectionSql = new ConnectionFactoryIts(NameOrConnectionString);

                    }
                    catch (Exception ex)
                    {
                        //dificilmente vai dar erro se conseguiu chegar ate aqui
                        exception = ex;
                    }
                }
                //others
            }

            catch (InvalidOperationException ex)
            {
                exception = ex;
            }

            catch (Exception ex)
            {
                exception = ex;
            }

            if (exception != null)
            {

                XMessageIts.ExceptionJustMessage(exception, null, "Falha na inicialização do controle do Sistema");
                LoggerUtilIts.GenerateLogs(exception);
                if (exception.GetType() != typeof(SqlException))
                {
                    Application.Exit();
                    Environment.Exit(0);
                }
            }

        }

        /// <summary>
        /// true => Entidades com marcação virtual são carregadas\n
        /// false => Entidades com marcação virtual nao serão carregadas
        /// </summary>
        /// <param name="enabled"></param>
        public void LazyLoading(bool enabled)
        {
            base.Configuration.LazyLoadingEnabled = enabled;
        }

        /// <summary>
        /// true => Entidades com marcação virtual são carregadas com PROXY\n
        /// false => Entidades com marcação virtual serão carregadas sem PROXY
        /// </summary>
        /// <param name="enabled"></param>
        public void ProxyCreation(bool enabled)
        {
            base.Configuration.ProxyCreationEnabled = enabled;
        }

        /// <summary>
        /// Ativa log de transações no Dao.
        /// Por padrão a propriedade não exibe logs
        /// </summary>
        /// <param name="enabled"></param>
        public void LogTransation(bool enabled)
        {
            if (enabled)
                this.Database.Log = Console.WriteLine;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //http://netcoders.com.br/blog/mapeamento-com-entity-framework-code-first-fluent-api-parte-1/

            //precisão do campo
            //modelBuilder.Entity<TEntity>().Property(p => p.Quantidade).HasPrecision(18, 3);
            //Aqui vamos remover a pluralização padrão do Etity Framework que é em inglês
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*Desabilitamos o delete em cascata em relacionamentos 1:N evitando
             ter registros filhos     sem registros pai*/
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Basicamente a mesma configuração, porém em relacionamenos N:N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            /*Toda propriedade do tipo string na entidade POCO
             seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>()
                      .Configure(p => p.HasColumnType("varchar"));

            /*Toda propriedade do tipo string na entidade POCO seja configurado como VARCHAR (150) no banco de dados */
            //modelBuilder.Properties<string>() .Configure(p => p.HasMaxLength(150));

            /*Definimos usando reflexão que toda propriedade que contenha
           "Nome da classe" + Id como "IdName" por exemplo, seja dada como
           chave primária, caso não tenha sido especificado*/
            modelBuilder.Properties().Where(p => p.Name == "Id" + p.ReflectedType.Name)
                                        .Configure(p => p.IsKey());



        }

        /// <summary>
        /// Disparado sempre que o using eh invocado
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            this.IsDispose = true;
        }

    }
}
