using Business.Abstract.Generic;
using EntityLayer.Concrete.ExceptionalEntities;

namespace Business.Abstract.Exceptional
{
    public interface IPaymentService : IGenericBaseService<Payment>
    {
        Task Insert(Payment t);
        IQueryable<Payment> GetAllAsnyc();
    }
}
