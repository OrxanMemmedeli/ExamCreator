using Business.Abstract.Generic;
using DTOLayer.DTOs.PaymentSummary;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Business.Abstract.Exceptional
{
    public interface IPaymentSummaryService 
    {
        Task Insert(PaymentSummaryCreateDTO t);
        Task<PaymentSummary> GetByAsnyc(Guid CompanyId);
        Task UpdateRange(IEnumerable<PaymentSummaryUpdateDTO> summaries);

    }
}
