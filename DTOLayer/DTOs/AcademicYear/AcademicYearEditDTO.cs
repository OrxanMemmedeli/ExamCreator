using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AcademicYear
{
    public class AcademicYearEditDTO : BaseFieldsForEdit
    {
        public string Name { get; set; }
    }
}
