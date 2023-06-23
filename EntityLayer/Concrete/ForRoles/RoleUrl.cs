using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.ForRoles
{
    public class RoleUrl
    {
        public RoleUrl()
        {
            this.CombineRoleUrls = new HashSet<CombineRoleUrl>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Url { get; set; }

        public ICollection<CombineRoleUrl> CombineRoleUrls { get; set; }

    }
}
