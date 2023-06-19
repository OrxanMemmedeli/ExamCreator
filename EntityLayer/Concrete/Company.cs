using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Company : BaseEntityWithUser
    {
        public Company()
        {
            this.Booklets = new HashSet<Booklet>();
        }

        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string? Key { get; set; }
        public bool IsFree { get; set; }

        public ICollection<Booklet> Booklets { get; set; }

    }
}
