using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class QuestionParameter : IEntity
    {
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyedDate { get; set; }

        public Guid QuestionTypeId { get; set; }
        public Guid SubjectParameterId { get; set; }
        public int StartQuestionNumber { get; set; }
        public int EndQuestionNumber { get; set; }


        public QuestionType QuestionType { get; set; }
        public SubjectParameter SubjectParameter { get; set; }
        public AppUser? CreatUser { get; set; }
        public AppUser? ModifyUser { get; set; }
    }
}
