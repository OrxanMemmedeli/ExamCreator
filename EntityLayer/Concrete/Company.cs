using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using EntityLayer.Concrete.CombineEntities;
using EntityLayer.Concrete.ExceptionalEntities;
using EntityLayer.Concrete.ForRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Company : BaseEntity
    {
        public Company()
        {
            this.CompanyUsers = new HashSet<CompanyUser>();
            this.Payments = new HashSet<Payment>();
        }

        public string Name { get; set; }
        public string LogoUrl { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? BlockedDate { get; set; }
        public decimal DailyAmount { get; set; }  // günlük məbləğ AZN
        public decimal DebtLimit { get; set; } // maksimal borc limiti
        public decimal PersentOfFine { get; set; } // limit aşıldıqda məbləğə artım faizi AZN

        public bool IsFree { get; set; }
        public bool IsPenal { get; set; }

        public virtual PaymentSummary? PaymentSummary { get; set; }
        public ICollection<CompanyUser> CompanyUsers { get; set; }
        public ICollection<Payment> Payments { get; set; }

    }
}
