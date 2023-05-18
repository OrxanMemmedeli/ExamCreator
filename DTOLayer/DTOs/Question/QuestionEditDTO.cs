using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Question
{
    public class QuestionEditDTO : BaseFieldsForEdit
    {
        public string Content { get; set; }

        public Guid SubjectId { get; set; }
        public Guid SectionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid QuestionLevelId { get; set; }
        public Guid GradeId { get; set; }
        public Guid AcademicYearId { get; set; }
    }
}
