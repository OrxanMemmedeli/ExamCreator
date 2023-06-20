using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.QuestionType
{
    public class QuestionTypeEditDTO : DTOLayer.DTOs.BaseFields.BaseFields
    {
        public string ResponseType { get; set; }
        public double? ResponseCount { get; set; } = 0;
        public bool IsShowAnswer { get; set; } = false;
        public string Description { get; set; }
    }
}
