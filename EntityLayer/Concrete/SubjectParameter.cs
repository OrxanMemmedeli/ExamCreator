using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SubjectParameter : IEntity
    {
        public SubjectParameter()
        {
            this.QuestionParameters = new HashSet<QuestionParameter>();
        }
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyedDate { get; set; }

        public int QuestionCount { get; set; }
        public int Order { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid ExamParameterId { get; set; }

        public Subject Subject { get; set; }
        public ExamParameter ExamParameter { get; set; }

        public ICollection<QuestionParameter> QuestionParameters { get; set; }

    }
}
