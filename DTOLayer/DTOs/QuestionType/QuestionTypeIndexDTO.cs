using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.QuestionType
{
    public class QuestionTypeIndexDTO : BaseFieldsForList
    {
        public string ResponseType { get; set; }
        public double? ResponseCount { get; set; }
        public bool IsShowAnswer { get; set; } = false;
        public string Description { get; set; }
    }
}
