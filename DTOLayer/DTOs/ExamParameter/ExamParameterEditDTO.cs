using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ExamParameter
{
    public class ExamParameterEditDTO : BaseFieldsForEdit
    {
        public string Name { get; set; }
        public int SubjectCount { get; set; }
        public string Description { get; set; }
    }
}
