using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task Insert(T t);
        Task Update(T t);
        Task Delete(T t);
        Task Remove(T t);
        IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> include = null);
        Task<T> GetByIdAsnyc(Guid id);
        IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> filter, Expression<Func<T, bool>> include = null);
        Task<T> GetByAsnyc(Expression<Func<T, bool>> filter, Expression<Func<T, bool>> include = null);

    }
}
