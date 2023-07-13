using Business.Abstract.Generic;
using EntityLayer.Concrete.ExceptionalEntities;
using System.Linq.Expressions;

namespace Business.Abstract.Exceptional
{
    public interface IPaymentService
    {
        Task Insert(Payment t);
        IQueryable<Payment> GetAllAsnyc(Expression<Func<Payment, bool>> filter);
    }
}
