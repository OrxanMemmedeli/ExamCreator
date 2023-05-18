using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Question
{
    public class QuestionIndexDTO : BaseFieldsForList
    {
        public string Content { get; set; }

        public string SubjectName { get; set; }
        public string SectionName { get; set; }
        public string QuestionTypeName { get; set; }
        public string QuestionLevelName { get; set; }
        public string GradeName { get; set; }
        public string AcademicYearName { get; set; }
    }
}
