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
        Task Insert(T t);
        Task Update(T t, Guid id);
        Task Delete(T t);
        Task Remove(T t);
        IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> include = null);
        Task<T> GetByIdAsnyc(Guid id);
        IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> filter, Expression<Func<T, bool>> include = null);
        Task<T> GetByAsnyc(Expression<Func<T, bool>> filter, Expression<Func<T, bool>> include = null);
    }
}
