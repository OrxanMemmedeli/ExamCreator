using AutoMapper;
using Business.Abstract.Exceptional;
using Business.Attributes;
using DataAccess.Abstract.Exceptional;
using DTOLayer.DTOs;
using DTOLayer.DTOs.PaymentSummary;
using EntityLayer.Concrete;

namespace Business.Concrete.Exceptional
{
    public class PaymentSummaryManager : IPaymentSummaryService
    {
        private readonly IPaymentSummaryDal _dal;
        private readonly IMapper _mapper;
        public PaymentSummaryManager(IPaymentSummaryDal paymentSummaryDal, IMapper mapper)
        {
            _dal = paymentSummaryDal;
            _mapper = mapper;
        }


        public async Task<PaymentSummary> GetByAsnyc(Guid CompanyId)
        {
            return await _dal.GetByAsnyc(x => x.CompanyId == CompanyId);
        }

        public async Task Insert(PaymentSummaryCreateDTO t)
        {
            PaymentSummary entity = _mapper.Map<PaymentSummaryCreateDTO, PaymentSummary>(t);
            entity.CurrentDebt = entity.TotalPayment - entity.TotalDebt;
            await _dal.Insert(entity);
            await _dal.SaveAsync();
        }


        [Transaction]
        public async Task UpdateRange(IEnumerable<PaymentSummaryUpdateDTO> summaries)
        {

            if (summaries != null)
                foreach (var item in summaries)
                {
                    PaymentSummary paymentSummary = _mapper.Map<PaymentSummaryUpdateDTO, PaymentSummary>(item);
                    paymentSummary.CurrentDebt = item.TotalPayment > item.TotalDebt ? item.TotalPayment - item.TotalDebt : 0;

                    await _dal.Update(paymentSummary);
                }

            await _dal.SaveAsync();
        }
    }
}
