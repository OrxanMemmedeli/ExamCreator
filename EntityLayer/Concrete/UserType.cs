using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entities;
using EntityLayer.Concrete.Base;

namespace EntityLayer.Concrete
{
    public class UserType : BaseEntity
    {
        public UserType()
        {
            this.AppUsers = new HashSet<AppUser>();
        }

        public string Type { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }

    }
}
