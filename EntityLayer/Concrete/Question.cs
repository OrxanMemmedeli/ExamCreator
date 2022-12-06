using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Question : IEntity
    {
        public Question()
        {
            this.Responses = new HashSet<Response>();
        }

        public string Content { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid SectionId { get; set; }
        public Section Section { get; set; }

        public Guid QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }

        public Guid QuestionLevelId { get; set; }
        public QuestionLevel QuestionLevel { get; set; }

        public Guid GradeId { get; set; }
        public Grade Grade { get; set; }

        public Guid? TextId { get; set; }
        public Text Text { get; set; }

        public Guid AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }

        public ICollection<Response> Responses { get; set; }

        #region IEntity
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyedDate { get; set; }
        public Guid? CreatUserId { get; set; }
        public Guid? ModifyUserId { get; set; }

        public AppUser? CreatUser { get; set; }
        public AppUser? ModifyUser { get; set; }
        #endregion

    }
}
