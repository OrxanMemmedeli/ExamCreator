using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Response
{
    public class ResponseIndexDTO : BaseFieldsForList
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsTrue { get; set; }

        public string SubjectName { get; set; }
        public string QuestionName { get; set; }
        public string QuestionTypeName { get; set; }
        public string AcademicYearName { get; set; }
    }
}
