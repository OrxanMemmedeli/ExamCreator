using Business.Abstract;
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
        private readonly ICompanyService _companyService;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IQueryable<Payment> GetAllAsnyc(Expression<Func<Payment, bool>> filter)
        {
            return _paymentDal.GetAllAsnyc(filter);
        }

        public async Task Insert(Payment t)
        {
            await _paymentDal.Insert(t);
            await _paymentDal.SaveAsync();
        }
    }
}
