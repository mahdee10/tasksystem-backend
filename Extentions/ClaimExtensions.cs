using System.Security.Claims;

namespace TaskSystemServer.Extentions
{
    public static class ClaimExtensions
    {
        public static string GetMemberId(this ClaimsPrincipal user)
        {
            return user.Claims.SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;
        }

    }
}
