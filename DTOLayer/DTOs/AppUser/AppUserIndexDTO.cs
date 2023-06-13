using DTOLayer.DTOs.BaseFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUser
{
    public class AppUserIndexDTO
    {
        public string FullName { get; set; }
        public bool ImageUrl { get; set; }
        public bool Status { get; set; } 
        public bool IsDeleted { get; set; } 

        public string UserTypeName { get; set; }
    }
}
