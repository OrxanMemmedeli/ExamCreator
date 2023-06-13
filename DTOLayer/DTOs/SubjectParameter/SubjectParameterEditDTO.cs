using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.SubjectParameter
{
    public class SubjectParameterEditDTO : BaseFieldsForEdit
    {
        public int QuestionCount { get; set; }
        public int Order { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid ExamParameterId { get; set; }
    }
}
