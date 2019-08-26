using ITSolution.Framework.Dao.Repositorio.Base;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

// Padrão Adapter
namespace ITSolution.Framework.Dao.Contexto
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
    public class GenericContextIts<T> : DbContextIts where T : class
    {
    //    #region String de conexao
    //    //String de conexão
    //    //private static string ConnectionString = Properties.Settings.Default.Balcao;
    //    private static string connectionString= null; //= ConfigurationManager.ConnectionStrings["Balcao"].ConnectionString;
    //    #endregion String de conexao

    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public GenericContextIts(string connectionStringOrDatabase):base(connectionStringOrDatabase)
            {

            //impedir que o EF trunque os valores decimais > 2 casas
            SqlProviderServices.TruncateDecimalsToScale = false;

            this.DbSet = this.Set<T>();
            

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //http://netcoders.com.br/blog/mapeamento-com-entity-framework-code-first-fluent-api-parte-1/

            /*Toda propriedade do tipo string na entidade POCO
                seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>()
                      .Configure(p => p.HasColumnType("varchar"));

        }


        #region Entidades que devem ser explicítas para criação das tabelas e controle de consultas

        public DbSet<T> DbSet { get; private set; }

        #endregion Entidades que devem ser explicítas para criação das tabelas e controle de consultas


        #region Metodos de acesso aos controles de persistencias

        public Dao<T> Dao { get { return new Dao<T>(this); } }

        #endregion Metodos de acesso aos controles de persistencias


    }
}

