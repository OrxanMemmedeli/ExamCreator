using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entities;

namespace EntityLayer.Concrete
{
    public class UserType : IEntityBase
    {
        public UserType()
        {
            this.AppUsers = new HashSet<AppUser>();
        }

        public string Type { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }

        #region IEntity
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyedDate { get; set; }
        #endregion

    }
}
