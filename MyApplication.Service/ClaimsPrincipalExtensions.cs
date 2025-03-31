using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Service
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetFullName(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst("FullName");
            return claim != null ? claim.Value : string.Empty;
        }

        public static string GetUserId(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);
            return claim != null ? claim.Value.ToString() : string.Empty;
        }

        public static int GetCompanyId(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst("CompanyId");
            return claim != null ? Convert.ToInt32(claim.Value) : 0;
        }

        public static string GetCompanyName(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst("CompanyName");
            return claim != null ? Convert.ToString(claim.Value) : string.Empty;
        }

        public static string GetUserRole(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Role);
            return claim != null ? Convert.ToString(claim.Value) : string.Empty;
        }
    }
}
