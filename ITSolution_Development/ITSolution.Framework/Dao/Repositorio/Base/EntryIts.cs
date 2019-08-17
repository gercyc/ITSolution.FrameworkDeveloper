using System;
using System.Data.Entity;

namespace ITSolution.Framework.Dao.Repositorio.Base
{
    /// <summary>
    /// Classe responsavel por alterar o estado do objeto.
    /// Alterar o comportamento do contexto.
    /// </summary>
    public sealed class EntryIts<T> where T : class  //where T : new() so para metodos
    {
        private DbContext dbContext;

        public EntryIts(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SetStateAdded(T entity)
        {
            this.dbContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
        }

        public void SetStateModified(T entity)
        {
            this.dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void SetStateDetached(T entity)
        {
            this.dbContext.Entry(entity).State = System.Data.Entity.EntityState.Detached;
        }

        public void SetStateUnchanged(T entity)
        {
            this.dbContext.Entry(entity).State = System.Data.Entity.EntityState.Unchanged;
        }

        public void SetStateDeleted(T entity)
        {
            this.dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
        }

    }
}
