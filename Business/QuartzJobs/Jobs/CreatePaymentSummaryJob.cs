using Business.Abstract;
using Business.Abstract.Exceptional;
using CoreLayer.Helpers.Tools;
using DTOLayer.DTOs.PaymentSummary;
using EntityLayer.Constants;
using Quartz;

namespace Business.QuartzJobs.Jobs
{
    public class CreatePaymentSummaryJob : IJob
    {
        private readonly IPaymentSummaryService _paymentSummaryService;
        private readonly ICompanyService _companyService;
        private readonly IPaymentService _paymentService;
        public CreatePaymentSummaryJob(IPaymentSummaryService paymentSummaryService, ICompanyService companyService, IPaymentService paymentService)
        {
            _paymentSummaryService = paymentSummaryService;
            _companyService = companyService;
            _paymentService = paymentService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var companies = _companyService.GetAllAsnyc().Select(x => x.Id).ToArray();

            List<PaymentSummaryUpdateDTO> summaries = new List<PaymentSummaryUpdateDTO>();


            foreach (var item in companies)
            {
                decimal payments = _paymentService.GetAllAsnyc(x => x.CompanyId == item && x.PaymentType == PaymentType.Pay).Sum(x => x.Amout);
                decimal debts = _paymentService.GetAllAsnyc(x => x.CompanyId == item && x.PaymentType == PaymentType.Debt).Sum(x => x.Amout);
                summaries.Add(new PaymentSummaryUpdateDTO
                {
                    TotalDebt = debts,
                    TotalPayment = payments,
                    CompanyId = item,
                });
            }

            await _paymentSummaryService.UpdateRange(summaries);
        }
    }
}
