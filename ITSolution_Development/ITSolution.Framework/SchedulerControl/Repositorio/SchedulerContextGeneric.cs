using ITSolution.Framework.Dao.Contexto;
using ITSolution.Framework.Entities;
using System.Configuration;
using System.Data.Entity;

namespace ITSolution.Scheduler.Repositorio
{
    /// <summary>
    /// Muito pesado
    /// Refazer usando contexto estatico
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SchedulerContextGeneric<T> : GenericContextIts<T> where T : class
    {

        public SchedulerContextGeneric() 
            : base(AppConfigManager.Configuration.ConnectionString)
        {

        }

        public static SchedulerContextGeneric<T> Instance { get { return new SchedulerContextGeneric<T>(); } }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //http://netcoders.com.br/blog/mapeamento-com-entity-framework-code-first-fluent-api-parte-1/

            /*Toda propriedade do tipo string na entidade POCO
                seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>()
                      .Configure(p => p.HasColumnType("varchar"));

            //precisão do campo
            //modelBuilder.Entity<T>().Property(p => p.Field).HasPrecision(18, 3);

        }
    }
}
