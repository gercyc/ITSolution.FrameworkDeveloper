using System.Configuration;
using ITSolution.Framework.Dao.Repositorio.Base;
using ITSolution.Framework.Entities;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using ITSolution.Framework.BaseClasses.License.POCO;
using ITSolution.Framework.BaseClasses;
using ITSolution.Framework.Common.BaseClasses;

// Singletone
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
    /// 
    /// </summary>
    public class ITSolutionContext : DbContextIts
    {

        #region Construtores
        public ITSolutionContext(string connectionStringOrDatabase)
            : base(connectionStringOrDatabase)
        {

        }

        public ITSolutionContext()
             : base(AppConfigManager.Configuration.AppConfig.ConnectionString)

        {
            //impedir que o EF trunque os valores decimais > 2 casas
            SqlProviderServices.TruncateDecimalsToScale = false;

            //Controladores de persistencia
   
        }
        #endregion Fim dos construtores


        #region Propriedades de controle de persistencia

        public Dao<Contato> ContatoDao { get { return new Dao<Contato>(this); } }
        public Dao<Lembrete> LembreteDao { get {return new Dao<Lembrete>(this); } }
        public Dao<Parametro> ParametroDao { get { return new Dao<Parametro>(this); } }
        public Dao<SkinDevExpress> SkinDevExpressDao { get { return new Dao<SkinDevExpress>(this); } }
        public Dao<TipoLogradouro> TipoLogradouroDao { get { return new Dao<TipoLogradouro>(this); } }

        #region License Manager
        public Dao<ItsLicense> LicenseDao { get { return new Dao<ItsLicense>(this); } }
        public virtual DbSet<ItsLicense> LicenseDbSet { get; set; }

        public Dao<ItsMenu> MenuDao { get { return new Dao<ItsMenu>(this); } }
        public virtual DbSet<ItsMenu> MenuDbSet { get; set; }


        #endregion


        #endregion Propriedades de controle de persistencia

        #region DbSet - Entidades explicítas p/criação das tabelas
        public virtual DbSet<Contato> Contatos { get; set; }
        public virtual DbSet<Lembrete> Lembretes { get; set; }
        public virtual DbSet<Parametro> Parametros { get; set; }
        public virtual DbSet<SkinDevExpress> SkinsDevExpress{ get; set; }
        public virtual DbSet<TipoLogradouro> TiposLogradouros { get; set; }
        #endregion

    }
}

