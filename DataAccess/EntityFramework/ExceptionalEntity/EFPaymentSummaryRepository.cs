using DataAccess.Abstract.Exceptional;
using DataAccess.Concrete.Context;
using DataAccess.Repositories;
using EntityLayer.Concrete;

namespace DataAccess.EntityFramework.ExceptionalEntity
{
    public class EFPaymentSummaryRepository : GenericBaseRepository<PaymentSummary>, IPaymentSummaryDal
    {
        public EFPaymentSummaryRepository(ECContext context) : base(context)
        {
        }
    }
}
