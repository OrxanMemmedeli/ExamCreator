using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ExamParameter : BaseEntityWithUser
    {
        public ExamParameter()
        {
            this.SubjectParameters = new HashSet<SubjectParameter>();
            this.Exams = new HashSet<Exam>();
        }

        //public Guid? CreatUserId { get; set; }
        //public Guid? ModifyUserId { get; set; }
        //public Guid Id { get; set; }
        //public bool Status { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? ModifyedDate { get; set; }

        public string Name { get; set; }
        public int SubjectCount { get; set; }
        public string Description { get; set; }

        //public AppUser? CreatUser { get; set; }
        //public AppUser? ModifyUser { get; set; }

        public ICollection<SubjectParameter> SubjectParameters { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
