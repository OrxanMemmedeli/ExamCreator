using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Constants;

namespace EntityLayer.Concrete.ExceptionalEntities
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public decimal Amout { get; set; }
        public PaymentType PaymentType { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
