using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Section
{
    public class SectionIndexDTO : BaseFieldsForList
    {
        public string Name { get; set; }

        public string SubjectName { get; set; }
    }
}
