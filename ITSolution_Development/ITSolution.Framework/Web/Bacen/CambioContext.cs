using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Dao.Repositorio.Base;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace ITSolution.Framework.Web.Bacen
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
    public class CambioContext : DbContextIts
    {
        #region Construtores

        public CambioContext(string connectionStringOrDataBase) : base(connectionStringOrDataBase)
        {
            //impedir que o EF trunque os valores decimais > 2 casas
            SqlProviderServices.TruncateDecimalsToScale = false;
  
        }
        public CambioContext(bool lazy=true)
              : base(AppConfigManager.Configuration.ConnectionString)
        {
            this.LazyLoading(lazy);
        }

        #endregion Fim dos construtores

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //http://netcoders.com.br/blog/mapeamento-com-entity-framework-code-first-fluent-api-parte-1/

            /*Toda propriedade do tipo string na entidade POCO
                seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //precisão do campo
            modelBuilder.Entity<CotacaoMonetaria>().Property(p => p.ValorCompra).HasPrecision(18, 4);
            modelBuilder.Entity<CotacaoMonetaria>().Property(p => p.ValorVenda ).HasPrecision(18, 4);
        }

        //Cada chamada estatica que realiza inicializaca dos ctx caso precise ou não 
        /// <summary>
        /// Instancia estatica do contexto
        /// </summary>
        public static CambioContext Instance { get { return new CambioContext(); } }

        #region Propriedades de controle de persistencia
        public Dao<Moeda> MoedaDao { get { return new Dao<Moeda>(this); } }

        public Dao<CotacaoMonetaria> CotacaoMonetariaDao { get { return new Dao<CotacaoMonetaria>(this); } }

        public Dao<IndicadoresBacen> IndicadoresBacenDao { get { return new Dao<IndicadoresBacen>(this); } }

        #endregion Propriedades de controle de persistencia

        #region Entidades que devem ser explicítas para criação das tabelas e controle de consultas

        public virtual DbSet<Moeda> Moedas { get; set; }

        public virtual DbSet<CotacaoMonetaria> CotacoesMonetaria { get; set; }
        public virtual DbSet<IndicadoresBacen> IndicadoresBacen { get; set; }

        #endregion Entidades que devem ser explicítas para criação das tabelas e controle de consultas

    }
}

