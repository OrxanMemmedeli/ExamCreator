using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.QuestionLevel
{
    public class QuestionLevelEditDTO : DTOLayer.DTOs.BaseFields.BaseFields
    {
        public string Name { get; set; }
        public short Level { get; set; }
    }
}
