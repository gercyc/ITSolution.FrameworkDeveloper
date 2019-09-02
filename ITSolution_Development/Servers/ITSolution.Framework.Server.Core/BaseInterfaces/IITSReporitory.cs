using ITSolution.Framework.Server.Core.BaseClasses.Repository;
using ITSolution.Framework.Server.Core.BaseEnums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Server.Core.BaseInterfaces
{
    //base https://github.com/stuartmcg123/GenericRepository/

    public interface IITSReporitory<TEntity, TContext> 
                                    where TEntity : class
                                    where TContext : ITSolutionDbContext
    {
        /// <summary>
        /// Synchronously retrieve all entities.
        /// </summary>
        /// <param name="predicate">Filter the results.</param>
        /// <param name="orderBy">Order the results.</param>
        /// <param name="orderDirection">Specify the direction of the ordering.</param>
        /// <param name="skip">Number of rows to skip</param>
        /// <param name="take">Number of rows to retrieve</param>
        /// <param name="includes">Child properites to include.</param>
        /// <returns>The filtered list of <see cref="TEntity"/></returns>
        IEnumerable<TEntity> GetAll(
           Expression<Func<TEntity, bool>> predicate = null,
           Expression<Func<TEntity, object>> orderBy = null,
           OrderDirection orderDirection = OrderDirection.Ascending,
           int skip = 0,
           int take = 0,
           Expression<Func<TEntity, object>>[] includes = null);

        /// <summary>
        /// Asynchronously retrieve all entities.
        /// </summary>
        /// <param name="predicate">Filter the results.</param>
        /// <param name="orderBy">Order the results.</param>
        /// <param name="orderDirection">Specify the direction of the ordering.</param>
        /// <param name="skip">Number of rows to skip</param>
        /// <param name="take">Number of rows to retrieve</param>
        /// <param name="includes">Child properites to include.</param>
        /// <returns>The filtered list of <see cref="TEntity"/></returns>
        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Expression<Func<TEntity, object>> orderBy = null,
            OrderDirection orderDirection = OrderDirection.Ascending,
            int skip = 0,
            int take = 0,
            Expression<Func<TEntity, object>>[] includes = null);

        /// <summary>
        /// Get a single item.
        /// </summary>
        /// <typeparam name="TKey">Type of the primary key.</typeparam>
        /// <param name="key">The key to find.</param>
        /// <returns>Null if no item found</returns>
        TEntity FirstOrDefault<TKey>(TKey key);

        /// <summary>
        /// Get a single item.
        /// </summary>
        /// <typeparam name="TKey">Type of the primary key.</typeparam>
        /// <param name="key">The key to find.</param>
        /// <returns>Null if no item found</returns>
        Task<TEntity> FirstOrDefaultAsync<TKey>(TKey key);

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges"></param>
        void Update(TEntity entity, bool saveChanges = false);

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges"></param>
        Task UpdateAsync(TEntity entity, bool saveChanges = false);

        /// <summary>
        /// Create an element.
        /// </summary>
        /// <param name="entity">The entity to be created.</param>
        /// <param name="saveChanges">Should save changes be called on the entity after being created.</param>
        /// <returns></returns>
        void Create(TEntity entity, bool saveChanges = false);

        /// <summary>
        /// Create an element.
        /// </summary>
        /// <param name="entity">The entity to be created.</param>
        /// <param name="saveChanges">Should save changes be called on the entity after being created.</param>
        /// <returns></returns>
        Task CreateAsync(TEntity entity, bool saveChanges = false);

        /// <summary>
        /// Remove an entity.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        /// <param name="saveChanges">Save the changes.</param>
        void Delete(TEntity entity, bool saveChanges = false);

        /// <summary>
        /// Remove an entity.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        /// <param name="saveChanges">Save the changes.</param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity, bool saveChanges = false);

        /// <summary>
        /// Save changes to the context
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Save changes to the context
        /// </summary>
        /// <returns>{TEntity}</returns>
        Task SaveChangesAsync();
    }
}
