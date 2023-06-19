using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AcademicYear : BaseEntityWithUser
    {
        public AcademicYear()
        {
            this.Questions = new HashSet<Question>();
            this.Responses = new HashSet<Response>();
            this.Booklets = new HashSet<Booklet>();

        }
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Response> Responses { get; set; }
        public ICollection<Booklet> Booklets { get; set; }

    }
}
