using CoreLayer.Helpers.Extensions;
using DataAccess.Abstract.Generic;
using DataAccess.Concrete.Context;
using DTOLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericBaseRepository<TEntity> : IGenericBaseDal<TEntity> where TEntity : class
    {
        private readonly ECContext _context;

        public GenericBaseRepository(ECContext context)
        {
            _context = context;
        }

        protected DbSet<TEntity> Table => _context.Set<TEntity>();

        protected IQueryable<TEntity> IncludeMultiple<TEntity>(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            if (includes != null)
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            return query;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();


        public IQueryable<TEntity> GetAllAsnyc(params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes.Any())
                return IncludeMultiple<TEntity>(Table.AsQueryable(), includes);
            return Table.AsQueryable();
        }

        public IQueryable<TEntity> GetAllAsnyc(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes.Any())
                return IncludeMultiple<TEntity>(Table.Where(filter).AsQueryable(), includes);
            return Table.Where(filter).AsQueryable();
        }

        public async Task<TEntity> GetByAsnyc(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes.Any())
            {
                var query = IncludeMultiple<TEntity>(Table.Where(filter).AsQueryable(), includes);
                return await query.FirstOrDefaultAsync();
            }
            return await Table.FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> GetByIdAsnyc(Guid id)
        {
            var data = await Table.FindAsync(id);
            return data;
        }

        public virtual async Task Insert(TEntity t)
        {
            await Table.AddAsync(t);
        }

        public async Task Remove(TEntity t)
        {
            EntityEntry entityEntry = _context.Entry(t);
            entityEntry.State = EntityState.Deleted;

            //Table.Remove(t);
        }

        public virtual async Task Update(TEntity t, Action<EntityEntry<TEntity>> rules = null)
        {
            var entry = _context.Entry(t);

            if (rules == null)
                goto summary;

            foreach (var propertyInfo in typeof(TEntity).GetProperties().Where(x => Extension.IsEditable(x)))
                entry.Property(propertyInfo.Name).IsModified = false;


            rules(entry);

        summary:
            entry.State = EntityState.Modified;

        }

        public virtual async Task UpdateRange(IEnumerable<GenericUpdateRangeModel<TEntity>> rangeModels)
        {
            foreach (var item in rangeModels)
            {
                await Update(item.t, item.rules);
            }
        }
    }
}
