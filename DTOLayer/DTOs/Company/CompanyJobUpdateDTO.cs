using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Company
{
    public class CompanyJobUpdateDTO
    {
        public Guid CompanyId { get; set; }
        public bool IsPenal { get; set; }
        public DateTime? BlockedDate { get; set; }

    }
}
