using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.QuestionParameter
{
    public class QuestionParameterCreateDTO
    {
        public Guid QuestionTypeId { get; set; }
        public Guid SubjectParameterId { get; set; }
        public int StartQuestionNumber { get; set; }
        public int EndQuestionNumber { get; set; }
    }
}
