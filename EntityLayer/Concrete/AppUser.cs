using EntityLayer.Concrete.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            this.CreatUsers = new HashSet<BaseEntity>();
            this.ModifyUsers = new HashSet<BaseEntity>();
        }

        public string FullName { get; set; }
        public bool ImageUrl { get; set; }
        public bool Status { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public Guid UserTypeId { get; set; }

        public UserType UserType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public ICollection<BaseEntity> CreatUsers { get; set; }
        public ICollection<BaseEntity> ModifyUsers { get; set; }
    }
}
