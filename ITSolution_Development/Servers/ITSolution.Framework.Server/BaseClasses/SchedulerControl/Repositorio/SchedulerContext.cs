using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Dao.Repositorio.Base;
using ITSolution.Scheduler.EntidadesBd;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace ITSolution.Scheduler.Repositorio
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
    /// 
    /// </summary>
    public class SchedulerContext : DbContextIts
    {
        #region Propriedades de controle de persistência

        private Dao<LogIts> logItsDao;
        private Dao<ProcessIts> processItsDao;
        private Dao<TaskIts> taskItsDao;
        //private Dao<TaskParamIts> taskParamItsDao;

        #endregion Propriedades de controle de persistência

        /*Metodo ja existe no DbContextIts
		#region String de conexao        
		//String de conexão
        //private static string ConnectionString = Properties.Settings.Default.Balcao;
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["Balcao"].ConnectionString;        
		#endregion String de conexao*/


        #region Construtores

        public static SchedulerContext Instance { get { return new SchedulerContext(); } }

        public SchedulerContext(string connectionStringOrDataBase) : base(connectionStringOrDataBase)
        {
            //impedir que o EF trunque os valores decimais > 2 casas
            SqlProviderServices.TruncateDecimalsToScale = false;

            //base.Configuration.LazyLoadingEnabled = false;
            //try
            //{
            //    base.Set<Produto>().AsNoTracking();
            //}
            //catch (Exception ex)
            //{
            //    XMessageIts.MensagemExcecaoMsg(ex,"Comportamento do produto nao foi modificado");
            //    Environment.Exit(0);
            //}

            //iniciando controladores de persistencia
            this.logItsDao = new Dao<LogIts>(this);
            this.processItsDao = new Dao<ProcessIts>(this);
            this.taskItsDao = new Dao<TaskIts>(this);
            //this.testeEntityDao = new Dao<TesteEntity>(this);
            //this.taskParamItsDao = new Dao<TaskParamIts>(this);

        }

        public SchedulerContext() 
            : this(AppConfigManager.Configuration.ConnectionString)
        {


        }

        #endregion Fim dos construtores

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //http://netcoders.com.br/blog/mapeamento-com-entity-framework-code-first-fluent-api-parte-1/

            /*Toda propriedade do tipo string na entidade POCO
                seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>()
                      .Configure(p => p.HasColumnType("varchar"));
            //precisão do campo
            //modelBuilder.Entity<TEntity>().Property(p => p.Quantidade).HasPrecision(18, 3);

        }

        #region Propriedades de controle de persistencia

        public Dao<LogIts> LogItsDao { get { return logItsDao; } }
        public Dao<ProcessIts> ProcessItsDao { get { return processItsDao; } }
        public Dao<TaskIts> TaskItsDao { get { return taskItsDao; } }
        //public Dao<TaskParamIts> TaskParamItsDao { get { return taskParamItsDao; } }
        //public Dao<TesteEntity> TesteEntityDao { get { return testeEntityDao; } }

        #endregion Propriedades de controle de persistencia

        #region Entidades que devem ser explicítas para criação das tabelas e controle de consultas

        public virtual DbSet<LogIts> LogsIts { get; set; }
        public virtual DbSet<ProcessIts> ProcesssIts { get; set; }
        public virtual DbSet<TaskIts> TasksIts { get; set; }
        //public virtual DbSet<TesteEntity> TesteEntitys { get; set; }

        #endregion Entidades que devem ser explicítas para criação das tabelas e controle de consultas

    }
}

