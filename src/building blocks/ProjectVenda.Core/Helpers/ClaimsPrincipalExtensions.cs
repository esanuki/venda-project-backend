using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenda.Core.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claim)
        {
            if (claim == null) throw new ArgumentNullException(nameof(claim));

            return claim.FindFirst("sub")?.Value ?? string.Empty;
        }

        public static string GetUserEmail(this ClaimsPrincipal claim)
        {
            if(claim == null) throw new ArgumentNullException(nameof(claim));

            return claim.FindFirst("email")?.Value ?? string.Empty;
        }

        public static string GetUserToken(this ClaimsPrincipal claim)
        {
            if (claim == null) throw new ArgumentNullException(nameof(claim));

            return claim.FindFirst("JWT")?.Value ?? string.Empty;
        }

        public static string GetUserRefreshToken(this ClaimsPrincipal claim)
        {
            if (claim == null) throw new ArgumentNullException(nameof(claim));

            return claim.FindFirst("RefreshToken")?.Value ?? string.Empty;
        }
    }
}
