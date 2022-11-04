using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        IQueryable<T> GetAllAsnyc();
        Task<T> GetByIdAsnyc(Guid id);
        IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> filter);
        Task<T> GetByAsnyc(Expression<Func<T, bool>> filter);
    }
}
