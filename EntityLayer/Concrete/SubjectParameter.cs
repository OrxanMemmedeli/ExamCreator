using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SubjectParameter : BaseEntityWithUser
    {
        public SubjectParameter()
        {
            this.QuestionParameters = new HashSet<QuestionParameter>();
        }

        public int QuestionCount { get; set; }
        public int Order { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid ExamParameterId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ExamParameter ExamParameter { get; set; }

        public ICollection<QuestionParameter> QuestionParameters { get; set; }

    }
}
