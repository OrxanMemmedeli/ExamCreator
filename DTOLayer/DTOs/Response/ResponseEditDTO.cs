using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Response
{
    public class ResponseEditDTO : DTOLayer.DTOs.BaseFields.BaseFields
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsTrue { get; set; }

        public Guid SubjectId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid AcademicYearId { get; set; }
    }
}
