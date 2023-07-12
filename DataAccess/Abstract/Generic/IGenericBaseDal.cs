using DTOLayer.DTOs;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace DataAccess.Abstract.Generic
{
    public interface IGenericBaseDal<T> where T : class
    {
        Task Insert(T t);
        Task Update(T t, Action<EntityEntry<T>> rules = null);
        Task UpdateRange(IEnumerable<GenericUpdateRangeModel<T>> rangeModels);
        Task Remove(T t);
        IQueryable<T> GetAllAsnyc(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsnyc(Guid id);
        IQueryable<T> GetAllAsnyc(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task<T> GetByAsnyc(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);

        Task<int> SaveAsync();
    }

    

}
