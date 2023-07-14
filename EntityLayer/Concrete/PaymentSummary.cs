using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete.Base;

namespace EntityLayer.Concrete
{
    public class PaymentSummary : BaseEntity
    {
        public decimal TotalPayment { get; set; }
        public decimal TotalDebt { get; set; }
        public decimal CurrentDebt { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
