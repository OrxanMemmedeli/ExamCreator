using CoreLayer.Entities;
using EntityLayer.Concrete.Base;
using EntityLayer.Concrete.CombineEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Question : BaseEntityWithUser
    {
        public Question()
        {
            this.Responses = new HashSet<Response>();
            this.QuestionAttahments = new HashSet<QuestionAttahment>();
        }

        public string Content { get; set; }

        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public Guid SectionId { get; set; }
        public virtual Section Section { get; set; }

        public Guid QuestionTypeId { get; set; }
        public virtual QuestionType QuestionType { get; set; }

        public Guid QuestionLevelId { get; set; }
        public virtual QuestionLevel QuestionLevel { get; set; }

        public Guid GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        public Guid? TextId { get; set; }
        public virtual Text Text { get; set; }

        public Guid AcademicYearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
            
        public ICollection<Response> Responses { get; set; }
        public ICollection<QuestionAttahment> QuestionAttahments { get; set; }

    }
}
