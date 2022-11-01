using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Section : BaseEntity
    {
        public string Name { get; set; }

        public Guid SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
