using Business.Abstract.Exceptional;
using DataAccess.Abstract.Exceptional;
using EntityLayer.Concrete.ExceptionalEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete.Exceptional
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IQueryable<Payment> GetAllAsnyc(params Expression<Func<Payment, object>>[] includes)
        {
            return _paymentDal.GetAllAsnyc(includes);
        }

        public IQueryable<Payment> GetAllAsnyc(Expression<Func<Payment, bool>> filter, params Expression<Func<Payment, object>>[] includes)
        {
            return _paymentDal.GetAllAsnyc(filter, includes);
        }

        public async Task<Payment> GetByAsnyc(Expression<Func<Payment, bool>> filter, params Expression<Func<Payment, object>>[] includes)
        {
            return await _paymentDal.GetByAsnyc(filter, includes);
        }

        public async Task<Payment> GetByIdAsnyc(Guid id)
        {
            return await _paymentDal.GetByIdAsnyc(id);
        }

        public async Task Insert(Payment t)
        {
            await _paymentDal.Insert(t);
        }

        public async Task Remove(Payment t)
        {
            await _paymentDal.Remove(t);
        }

        public async Task Update(Payment t, Action<EntityEntry<Payment>> rules = null)
        {
            await _paymentDal.Update(t, rules);
        }
    }
}
