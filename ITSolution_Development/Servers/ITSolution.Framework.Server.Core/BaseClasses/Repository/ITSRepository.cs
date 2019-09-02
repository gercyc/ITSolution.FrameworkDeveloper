using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITSolution.Framework.Server.Core.BaseEnums;
using ITSolution.Framework.Server.Core.BaseInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ITSolution.Framework.Server.Core.BaseClasses.Repository
{
    /// <summary>
    /// Generic repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ITSRepository<TEntity, TContext> : IITSReporitory<TEntity, TContext> where TEntity : class where TContext : ITSolutionDbContext
    {
            #region Private properties
            private readonly TContext _context;
            #endregion

            #region Constructor
            public ITSRepository(TContext context)
            {
                _context = context;
            }
            #endregion

            #region Public methods
            /// <inheritdoc/>
            public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null,
                Expression<Func<TEntity, object>> orderBy = null,
                OrderDirection orderDirection = OrderDirection.Ascending,
                int skip = 0,
                int take = 0,
                Expression<Func<TEntity, object>>[] includes = null)
            {
                return GetQuery(predicate, orderBy, orderDirection, skip, take)
                    .ToList();
            }

            /// <inheritdoc />
            public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
                Expression<Func<TEntity, object>> orderBy = null,
                OrderDirection orderDirection = OrderDirection.Ascending,
                int skip = 0,
                int take = 0,
                Expression<Func<TEntity, object>>[] includes = null)
            {
                return await GetQuery(predicate, orderBy, orderDirection, skip, take)
                    .ToListAsync();
            }

            /// <inheritdoc />
            public TEntity FirstOrDefault<TKey>(TKey key)
            {
                return _context
                    .Set<TEntity>()
                    .Find(key);
            }

            /// <inheritdoc />
            public async Task<TEntity> FirstOrDefaultAsync<TKey>(TKey key)
            {
                return await _context
                    .Set<TEntity>()
                    .FindAsync(key);
            }

            /// <inheritdoc />
            public void Update(TEntity entity, bool saveChanges = false)
            {
                var set = _context
                    .Set<TEntity>();

                set.Attach(entity);

                var entry = _context
                    .Entry(entity);

                entry.State = EntityState.Modified;

                if (saveChanges)
                {
                    SaveChanges();
                }
            }

            /// <inheritdoc />
            public async Task UpdateAsync(TEntity entity, bool saveChanges = false)
            {
                var set = _context
                    .Set<TEntity>();

                set.Attach(entity);

                var entry = _context
                    .Entry(entity);

                entry.State = EntityState.Modified;

                if (saveChanges)
                {
                    await SaveChangesAsync();
                }
            }

            /// <summary>
            /// <see cref="ITSRepository{TEntity}.Create(TEntity, bool)"/>
            /// </summary>
            public void Create(TEntity entity, bool saveChanges = false)
            {
                var set = _context
                    .Set<TEntity>();

                set
                    .Add(entity);

                if (saveChanges)
                {
                    SaveChanges();
                }
            }

            /// <summary>
            /// <see cref="ITSRepository{TEntity}.CreateAsync(TEntity, bool)"/>
            /// </summary>
            public async Task CreateAsync(TEntity entity, bool saveChanges = false)
            {
                var set = _context
                    .Set<TEntity>();

                await set
                     .AddAsync(entity);

                if (saveChanges)
                {
                    await SaveChangesAsync();
                }
            }

            /// <summary>
            /// <see cref="ITSRepository{TEntity}.Delete(TEntity, bool)"/>
            /// </summary>
            public void Delete(TEntity entity, bool saveChanges = false)
            {
                _context.Remove(entity);

                if (saveChanges)
                {
                    SaveChanges();
                }
            }

            /// <summary>
            /// <see cref="ITSRepository{TEntity}.DeleteAsync(TEntity, bool)"/>
            /// </summary>
            public async Task DeleteAsync(TEntity entity, bool saveChanges = false)
            {
                _context.Remove(entity);

                if (saveChanges)
                {
                    await SaveChangesAsync();
                }
            }

            /// <summary>
            /// <see cref="ITSRepository{TEntity}.SaveChanges"/>
            /// </summary>
            public void SaveChanges()
            {
                _context
                    .SaveChanges();
            }

            /// <summary>
            /// <see cref="ITSRepository{TEntity}.SaveChangesAsync"/>
            /// </summary>
            public async Task SaveChangesAsync()
            {
                await _context
                    .SaveChangesAsync();
            }
            #endregion

            #region Private methods
            /// <summary>
            /// Retreive a queryable
            /// </summary>
            /// <param name="predicate">Filter the results.</param>
            /// <param name="orderBy">Order the results.</param>
            /// <param name="orderDirection">Specify the direction of the ordering.</param>
            /// <param name="skip"></param>
            /// <param name="take"></param>
            /// <param name="includes">An array of navigation property includes.</param>
            /// <returns></returns>
            private IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null,
                Expression<Func<TEntity, object>> orderBy = null,
                OrderDirection orderDirection = OrderDirection.Ascending,
                int skip = 0,
                int take = 0,
                Expression<Func<TEntity, object>>[] includes = null)
            {
                var querySet = _context
                     .Set<TEntity>();

                var query = querySet
                     .AsQueryable();

                if (predicate != null)
                {
                    query = query.Where(predicate);
                }

                if (orderBy != null)
                {
                    if (orderDirection == OrderDirection.Ascending)
                    {
                        query = query.OrderBy(orderBy);
                    }
                    else
                    {
                        query = query.OrderByDescending(orderBy);
                    }
                }

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                if (skip > 0)
                {
                    query = query.Skip(skip);
                }

                if (take > 0)
                {
                    query = query.Take(take);
                }


                return query;
            }
            #endregion
        
    }
}
