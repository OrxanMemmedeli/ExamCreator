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
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly ECContext _context;

        public GenericRepository(ECContext context)
        {
            _context = context;
        }
        
        public DbSet<T> Table => _context.Set<T>();

        private async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public async Task Delete(T t)
        {
            Type type = t.GetType();
            PropertyInfo? prop = type.GetProperty("IsDeleted");
            //object obj = prop.GetValue(t, null);
            prop.SetValue(t, true, null);

            await SaveAsync();
        }

        public async Task Remove(T t)
        {
            Table.Attach(t);
            EntityEntry entityEntry = _context.Entry(t);
            entityEntry.State = EntityState.Deleted;

            //Table.Remove(t);
            await SaveAsync();
        }

        public IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> include = null)
        {
            return include != null ? Table.AsQueryable().Include(include) : Table.AsQueryable(); 
        }

        public IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> filter, Expression<Func<T, bool>> include = null)
        {
            return include != null ? Table.Where(filter).AsQueryable().Include(include) : Table.Where(filter).AsQueryable();
        }

        public async Task<T> GetByAsnyc(Expression<Func<T, bool>> filter, Expression<Func<T, bool>> include = null)
        {
            return include != null ? await Table.Include(include).FirstOrDefaultAsync(filter) : await Table.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsnyc(Guid id)
        {
            var data = await Table.FindAsync(id);
            return data;
        }

        public async Task Insert(T t)
        {
            await Table.AddAsync(t);
            await SaveAsync();
        }

        public async Task Update(T t, Guid id)
        {
            EntityEntry entityEntry = Table.Update(t);

            var local = await Table.FindAsync(id);
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }

            entityEntry.State = EntityState.Modified;

            await SaveAsync();
        }
    }
}
