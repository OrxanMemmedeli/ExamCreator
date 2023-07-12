using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.Company
{
    public class CompanyCreateDTO
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }

        public decimal DailyAmount { get; set; }  
        public decimal DebtLimit { get; set; } 
        public decimal PersentOfFine { get; set; }

        public bool IsFree { get; set; }

    }
}
