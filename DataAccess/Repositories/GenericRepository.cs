using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        
        var test = _context.Grades.First().

        public DbSet<T> Table => _context.Set<T>();

        private async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public async void Delete(T t)
        {
            Table.Remove(t);
            await SaveAsync();
        }

        public IQueryable<T> GetAllAsnyc()
        {
            return Table.AsQueryable();
        }

        public IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> filter)
        {
            return Table.Where(filter).AsQueryable();
        }

        public async Task<T> GetByAsnyc(Expression<Func<T, bool>> filter)
        {
            return await Table.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsnyc(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async void Insert(T t)
        {
            Table.Add(t);
            await SaveAsync();
        }

        public async void Update(T t)
        {
            Table.Update(t);
            await SaveAsync();
        }
    }
}
