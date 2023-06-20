using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Company
{
    public class CompanyEditDTO : DTOLayer.DTOs.BaseFields.BaseFields
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
    }
}
