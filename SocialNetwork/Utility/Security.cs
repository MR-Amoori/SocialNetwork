using System.Security.Claims;
using System.Security.Principal;

namespace SocialNetwork
{
    public static class Security
    {
        public static string GetEmail(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Email);
            return claim?.Value ?? string.Empty;
        }

        public static string GetFullName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("FullName");
            return claim?.Value ?? string.Empty;
        }

        public static string GetUserName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("UserName");
            return claim?.Value ?? string.Empty;
        }



        public static bool GetIsAdmin(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("IsAdmin");
            if (claim == null)
            {
                return false;
            }
            return GetIsAdminUtility(claim.Value);
        }

        public static bool GetIsAdminUtility(string value)
        {
            if (value == null)
                return false;

            if (value == "True")
                return true;

            else
            {
                return false;
            }

        }
    }
}
