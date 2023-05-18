using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Section
{
    public class SectionCreateDTO
    {
        public string Name { get; set; }

        public Guid SubjectId { get; set; }
    }
}
