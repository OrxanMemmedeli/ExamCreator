using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Text
{
    public class TextIndexDTO : BaseFieldsForList
    {
        public string Name { get; set; }
        public string Title { get; set; } 
        public string Content { get; set; }
    }
}
