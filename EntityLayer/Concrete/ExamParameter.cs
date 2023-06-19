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


        public string Name { get; set; }
        public int SubjectCount { get; set; }
        public string Description { get; set; }

        public ICollection<SubjectParameter> SubjectParameters { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
