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

        public DbSet<T> Table => _context.Set<T>();

        public void Delete(T t)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAllAsnyc()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAllAsnyc(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByAsnyc(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsnyc(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T t)
        {
            throw new NotImplementedException();
        }

        public void Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
