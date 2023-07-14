using Business.Abstract.Generic;
using DTOLayer.DTOs.Payment;
using EntityLayer.Concrete.ExceptionalEntities;
using System.Linq.Expressions;

namespace Business.Abstract.Exceptional
{
    public interface IPaymentService
    {
        Task InsertPayment(PaymentCreateDTO payment);
        Task InsertRangeDebts(List<Payment> t);
        IQueryable<Payment> GetAllAsnyc(Expression<Func<Payment, bool>> filter);
    }
}
