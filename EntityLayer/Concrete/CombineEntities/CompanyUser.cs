using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.CombineEntities
{
    public class CompanyUser
    {
        public Guid AppUserId { get; set; }
        public Guid CompanyId { get; set; }

        public AppUser AppUser { get; set; }
        public Company Company { get; set; }
    }
}
