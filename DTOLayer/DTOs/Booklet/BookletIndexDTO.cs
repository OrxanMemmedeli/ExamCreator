using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Booklet
{
    public class BookletIndexDTO : BaseFieldsForList
    {
        public string GradeName { get; set; }
        public string GroupName { get; set; }
        public string VariantName { get; set; }
        public string ExamName { get; set; }
        public string CompanyName { get; set; }
        public string AcademicYearName { get; set; }
    }
}
