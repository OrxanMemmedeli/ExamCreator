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
        //public Guid? CreatUserId { get; set; }
        //public Guid? ModifyUserId { get; set; }
        //public Guid Id { get; set; }
        //public bool Status { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? ModifyedDate { get; set; }

        public string Name { get; set; }
        public Guid GradeId { get; set; }
        public Guid ExamParameterId { get; set; }


        public virtual Grade Grade { get; set; }
        public virtual ExamParameter ExamParameter { get; set; }
        //public AppUser? CreatUser { get; set; }
        //public AppUser? ModifyUser { get; set; }

        public ICollection<Booklet> Booklets { get; set; }

    }
}
