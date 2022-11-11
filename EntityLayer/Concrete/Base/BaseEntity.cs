using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Base
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Status { get; set; } 
        public bool IsDeleted { get; set; } 
        public DateTime? CreatedDate { get; set; } 
        public DateTime? ModifyedDate { get; set; }

        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }

        public AppUser? CreatUser { get; set; }
        public AppUser? ModifyUser { get; set; }
    }
}
