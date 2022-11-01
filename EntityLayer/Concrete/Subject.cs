using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Subject:BaseEntity
    {
        public Subject()
        {
            this.Sections = new HashSet<Section>();
        }
        public string Name { get; set; }
        public decimal? AmountForQuestion{ get; set; }

        public ICollection<Section> Sections { get; set; }
    }
}
