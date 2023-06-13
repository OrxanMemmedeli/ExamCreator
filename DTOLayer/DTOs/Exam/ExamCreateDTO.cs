using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Exam
{
    public class ExamCreateDTO
    {
        public string Name { get; set; }
        public Guid GradeId { get; set; }
        public Guid ExamParameterId { get; set; }
    }
}
