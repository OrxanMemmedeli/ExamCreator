using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helpers.Tools
{
    public static class CompanyHttpContex
    {
        public static Guid GetCompanyID(IHttpContextAccessor httpContextAccessor)
        {
            var companyID =httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Company");
            return Guid.Parse(companyID.Value);
        }
    }
}
