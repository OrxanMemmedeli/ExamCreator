using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Exam
{
    public class ExamIndexDTO : BaseFieldsForList
    {
        public string Name { get; set; }
        public string GradeName { get; set; }
        public string ExamParameterName { get; set; }
    }
}
