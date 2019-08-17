using ITSolution.Framework.Common.BaseClasses.Reports;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Dao.Repositorio.Base;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace ITSolution.Reports.Repositorio
{
    /// <summary>
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
    public class ReportContext : DbContextIts
    {
        public ReportContext(string nameOrConnectionString)
               : base(nameOrConnectionString)
        {

        }

        /// <summary>
        /// Utiliza a string de conexão com Nome "Balcao" do app config 
        /// </summary>
        public ReportContext()
            : base(AppConfigManager.Configuration.ConnectionString)
        {

            //impedir que o EF trunque os valores decimais > 2 casas
            SqlProviderServices.TruncateDecimalsToScale = false;
            //base.Configuration.LazyLoadingEnabled = false;

            //Controladores de persistencia
            this.ReportGroupDao = new Dao<ReportGroup>(this);
            this.ReportImageDao = new Dao<ReportImage>(this);
            this.ReportSpoolDao = new Dao<ReportSpool>(this);
            this.DashboardImageDao = new Dao<DashboardImage>(this);
            this.SqlQueryItsDao = new Dao<SqlQueryIts>(this);
            this.ReportDataSourceDao = new Dao<ReportDataSource>(this);

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //http://netcoders.com.br/blog/mapeamento-com-entity-framework-code-first-fluent-api-parte-1/

            /*Toda propriedade do tipo string na entidade POCO
                seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>()
                      .Configure(p => p.HasColumnType("varchar"));

        }

        #region Entidades explicítas p/criação das tabelas e controle do banco de dados

        public DbSet<ReportGroup> ReportGroups { get; set; }
        public DbSet<ReportImage> ReportImages { get; set; }
        public DbSet<ReportSpool> ReportSpools { get; set; }
        public DbSet<DashboardImage> DashboardImages { get; set; }
        public DbSet<SqlQueryIts> SqlQueriesIts { get; set; }
        public DbSet<ReportDataSource> ReportDataSources { get; set; }


        #endregion 

        #region Controles de persistencias Dao

        public Dao<ReportGroup> ReportGroupDao { get; private set; }
        public Dao<ReportImage> ReportImageDao { get; private set; }
        public Dao<ReportSpool> ReportSpoolDao { get; private set; }
        public Dao<DashboardImage> DashboardImageDao { get; private set; }
        public Dao<SqlQueryIts> SqlQueryItsDao { get; set; }
        public Dao<ReportDataSource> ReportDataSourceDao { get; set; }

        #endregion 

    }
}

