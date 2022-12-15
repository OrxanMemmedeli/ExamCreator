using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Variant : IEntity
    {
        public Variant()
        {
            this.Booklets = new HashSet<Booklet>();

        }
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyedDate { get; set; }

        public string Name { get; set; }

        public AppUser? CreatUser { get; set; }
        public AppUser? ModifyUser { get; set; }

        public ICollection<Booklet> Booklets { get; set; }

    }
}
