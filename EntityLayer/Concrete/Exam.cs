using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Exam : BaseEntityWithUser
    {
        public Exam()
        {
            this.Booklets = new HashSet<Booklet>();

        }
        public string Name { get; set; }
        public Guid GradeId { get; set; }
        public Guid ExamParameterId { get; set; }


        public virtual Grade Grade { get; set; }
        public virtual ExamParameter ExamParameter { get; set; }

        public ICollection<Booklet> Booklets { get; set; }

    }
}
