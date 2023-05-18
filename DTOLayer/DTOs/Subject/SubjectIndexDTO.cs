using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Subject
{
    public class SubjectIndexDTO :BaseFieldsForList
    {
        public string Name { get; set; }
        public decimal? AmountForQuestion { get; set; }
    }
}
