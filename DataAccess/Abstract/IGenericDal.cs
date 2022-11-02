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
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        Task<IQueryable<T>> GetAllAsnyc();
        Task<T> GetByIdAsnyc(int id);
        Task<IQueryable<T>> GetAllAsnyc(Expression<Func<T, bool>> filter);
        Task<T> GetByAsnyc(Expression<Func<T, bool>> filter);

    }
}
