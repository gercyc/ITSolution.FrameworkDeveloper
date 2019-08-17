using ITSolution.Admin.Entidades.EntidadesBd;
using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Dao.Repositorio.Base;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;


namespace ITSolution.Admin.Repositorio
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
    /// 
    /// </summary>
    public class AdminContext : DbContextIts
    {

        #region Construtores

        public AdminContext(string connectionStringOrDataBase) : base(connectionStringOrDataBase)
        {
        }

        public AdminContext()
            : base(AppConfigManager.Configuration.AppConfig.ConnectionString)
        {

        }

        #endregion Fim dos construtores


        ///Nesse caso não é um boa idéia cc padrão Singleton no ctx Pelo fato do ctx 
        //poder ser fechado e precisarmos do objeto que foi Dispose(terminado) 
        //Cada chamada estatica refaça a inicializaca dos ctx caso precise ou não 
        /// <summary>
        /// Instancia estatica do contexto
        /// </summary>
        //public static AdminContext Instance { get { return new AdminContext(); } }

        #region Propriedades de controle de persistencia

        public Dao<Package> PackageDao { get { return new Dao<Package>(this); } }
        public Dao<AnexoPackage> AnexoPackageDao { get { return new Dao<AnexoPackage>(this); } }
        public Dao<UpdateInfo> UpdateInfoDao { get { return new Dao<UpdateInfo>(this); } }

        #endregion Propriedades de controle de persistencia

        #region Entidades que devem ser explicítas para criação das tabelas e controle de consultas

        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<UpdateInfo> UpdatesInfo { get; set; }
        public virtual DbSet<AnexoPackage> AnexoPackages { get; set; }

        #endregion Entidades que devem ser explicítas para criação das tabelas e controle de consultas

    }
}


