using EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Question : BaseEntity
    {
        public Question()
        {
            this.Responses = new HashSet<Response>();
        }

        public string Content { get; set; }


        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

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
        

        public ICollection<Response> Responses { get; set; }
    }
}
