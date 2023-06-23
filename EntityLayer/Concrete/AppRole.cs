using EntityLayer.Concrete.ForRoles;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole()
        {
            this.CombineRoleUrls = new HashSet<CombineRoleUrl>();
        }

        public ICollection<CombineRoleUrl> CombineRoleUrls { get; set; }
    }
}
