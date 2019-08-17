using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Dao.Repositorio.Base
{
    /// <summary>
    /// Metodos padroes de persistencia
    /// </summary>
    /// <typeparam colName="T"></typeparam>
    interface IDao<T> where T : class
    {
        bool Save(T obj);

        bool Update(T obj);

        bool Delete(Func<T, bool> predicate);

        T Find(params object[] key);

        DbSet<T> Controller();

        IQueryable<T> Where(Func<T, bool> predicate);

    }
}
