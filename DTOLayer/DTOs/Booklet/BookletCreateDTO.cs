using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Booklet
{
    public class BookletCreateDTO
    {
        public Guid GradeId { get; set; }
        public Guid? GroupId { get; set; }
        public Guid VariantId { get; set; }
        public Guid ExamId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid AcademicYearId { get; set; }
    }
}
