using AutoMapper;
using Business.Abstract;
using Business.Abstract.Exceptional;
using Business.Attributes;
using CoreLayer.Constants;
using CoreLayer.Helpers.Extensions;
using CoreLayer.Helpers.Tools;
using DataAccess.Abstract.Exceptional;
using DTOLayer.DTOs.Payment;
using EntityLayer.Concrete.ExceptionalEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Concrete.Exceptional
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public PaymentManager(IPaymentDal paymentDal, IMapper mapper, ICompanyService companyService)
        {
            _paymentDal = paymentDal;
            _mapper = mapper;
            _companyService = companyService;
        }

        public IQueryable<Payment> GetAllAsnyc(Expression<Func<Payment, bool>> filter)
        {
            return _paymentDal.GetAllAsnyc(filter);
        }

        [Transaction]
        public async Task InsertPayment(PaymentCreateDTO payment)
        {
            Payment entity = _mapper.Map<PaymentCreateDTO, Payment>(payment);
            entity.PaymentType = EntityLayer.Constants.PaymentType.Pay;
            entity.CreatedDate = DateTime.Now;
            entity.CompanyId = CompanyIdFinder.GetCompanyID();

            var companyInfo = await _companyService.GetByAsnyc(x => x.Id == entity.CompanyId, x => x.PaymentSummary);

            if (companyInfo.PaymentSummary?.CurrentDebt > payment.Amout)
                throw new Exception(string.Format(ValidationMessage.PaymentGreaterFromDebt, DateTime.Now.Date, companyInfo.PaymentSummary.CurrentDebt));

            await _paymentDal.Insert(entity);

            await _companyService.Update(companyInfo, entity =>
            {
                entity.SetValue(x => x.BlockedDate, null);
                entity.SetValue(x => x.IsPenal, false);
                entity.SetValue(x => x.Status, true);
            });

        }

        [Transaction]
        public async Task InsertRangeDebts(List<Payment> t)
        {
            foreach (var item in t.Where(x => x.PaymentType == EntityLayer.Constants.PaymentType.Debt))
                await _paymentDal.Insert(item);

            await _paymentDal.SaveAsync();
        }
    }
}
