using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipalExtesions
    {
        public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
        {
            return user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
    }
}