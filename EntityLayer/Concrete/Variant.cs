using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Variant : BaseEntityWithUser
    {
        public Variant()
        {
            this.Booklets = new HashSet<Booklet>();

        }

        public string Name { get; set; }

        public ICollection<Booklet> Booklets { get; set; }

    }
}
