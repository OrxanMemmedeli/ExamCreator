using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using EntityLayer.Concrete.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public partial class GenericRepository<T> : IGenericDal<T> where T : BaseEntity, IEntity
    {
        private readonly ECContext _context;

        public GenericRepository(ECContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        private IQueryable<T> IncludeMultiple<T>(IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
        private async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public async Task Delete(T t)
        {
            Type type = t.GetType();
            PropertyInfo? prop = type.GetProperty("IsDeleted");
            //object obj = prop.GetValue(t, null);
            prop.SetValue(t, true, null);

            updateBaseField(ref t);

            await SaveAsync();
        }

        public async Task Remove(T t)
        {
            EntityEntry entityEntry = _context.Entry(t);
            entityEntry.State = EntityState.Deleted;

            //Table.Remove(t);
            await SaveAsync();
        }

        public IQueryable<T> GetAllAsnyc(params Expression<Func<T, object>>[] includes)
        {
            if (includes.Any())
                return IncludeMultiple<T>(Table.AsQueryable(), includes);
            return Table.AsQueryable();
        }

        public IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            if (includes.Any())
                return IncludeMultiple<T>(Table.Where(filter).AsQueryable(), includes);
            return Table.Where(filter).AsQueryable();
        }

        public async Task<T> GetByAsnyc(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            if (includes.Any())
            {
                var query = IncludeMultiple<T>(Table.Where(filter).AsQueryable(), includes);
                return await query.FirstOrDefaultAsync();

            }
            return await Table.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsnyc(Guid id)
        {
            var data = await Table.FindAsync(id);
            return data;
        }

        public async Task Insert(T t)
        {
            addBaseFields(ref t);
            await Table.AddAsync(t);
            await SaveAsync();
        }

        private static void addBaseFields(ref T t)
        {
            t.Id = Guid.NewGuid();
            t.IsDeleted = false;
            t.Status = true;
            t.CreatedDate = DateTime.Now;
            t.ModifyedDate = default(DateTime);

            //if (typeof(T) == typeof(BaseEntityWithUser))
            //{
            //    Type type = t.GetType();
            //    PropertyInfo? propCreatUserId = type.GetProperty("CreatUserId");
            //    propCreatUserId.SetValue(t, , null);
            //}
        }

        public async Task Update(T t, Guid id)
        {
            updateBaseField(ref t);


            EntityEntry entityEntry = _context.Entry(t);
            entityEntry.State = EntityState.Modified;

            //var local = await Table.FindAsync(id);
            //if (local != null)
            //{
            //    _context.Entry(local).State = EntityState.Detached;
            //}

            //entityEntry.State = EntityState.Modified;



            await SaveAsync();
        }

        private static void updateBaseField(ref T t)
        {
            t.ModifyedDate = DateTime.Now;

            //if (typeof(T) == typeof(BaseEntityWithUser))
            //{
            //    Type type = t.GetType();
            //    PropertyInfo? propModifyUserId = type.GetProperty("ModifyUserId");
            //    propModifyUserId.SetValue(t, , null);
            //}
        }


    }
}
