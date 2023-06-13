using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTOLayer.DTOs.AppUser
{
    public class AppUserCreateEditDTO
    {
        public string FullName { get; set; }
        public bool ImageUrl { get; set; }
        public bool Status { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public Guid? UserTypeId { get; set; }
    }
}
