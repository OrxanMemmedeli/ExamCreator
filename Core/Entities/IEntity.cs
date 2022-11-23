using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public interface IEntity : IEntityBase
    {
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }
    }
}
