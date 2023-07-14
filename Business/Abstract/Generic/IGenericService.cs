using EntityLayer.Concrete.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Abstract.Generic
{
    public interface IGenericService<T> : IGenericBaseService<T> where T : BaseEntity
    {
        Task Delete(T t);
    }
}
