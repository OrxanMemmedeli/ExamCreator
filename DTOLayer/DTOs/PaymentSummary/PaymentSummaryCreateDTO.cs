using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.PaymentSummary
{
    public class PaymentSummaryCreateDTO
    {
        public decimal TotalPayment { get; set; }
        public decimal TotalDebt { get; set; }
        public Guid CompanyId { get; set; }
    }
}
