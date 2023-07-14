using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helpers.Tools
{
    public static class CompanyIdFinder
    {
        public static Guid GetCompanyID()
        {
            var user = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var companyClaim = user.Claims.FirstOrDefault(x => x.Type == "Company");

            if (companyClaim != null && Guid.TryParse(companyClaim.Value, out Guid companyID))
                return companyID;
            else
                throw new InvalidOperationException("Company claim not found or invalid.");
        }
    }
}
