using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.Base
{
    public abstract class BaseEntityWithUser : BaseEntity, IEntity
    {
        [ForeignKey("CreatUserId")]
        public Guid? CreatUserId { get; set; }
        [ForeignKey("ModifyUserId")]
        public Guid? ModifyUserId { get; set; }

        public virtual AppUser? CreatUser { get; set; }
        public virtual AppUser? ModifyUser { get; set; }
    }
}
