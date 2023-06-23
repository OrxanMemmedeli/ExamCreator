using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.ForRoles
{
    public class CombineRoleUrl
    {
        public Guid AppRoleId { get; set; }
        public Guid RoleUrlId { get; set; }

        public AppRole AppRole { get; set; }
        public RoleUrl RoleUrl { get; set; }
    }
}
