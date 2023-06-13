using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.SubjectParameter
{
    public class SubjectParameterIndexDTO : BaseFieldsForList
    {
        public int QuestionCount { get; set; }
        public int Order { get; set; }
        public string SubjectName { get; set; }
        public string ExamParameterName { get; set; }
    }
}
