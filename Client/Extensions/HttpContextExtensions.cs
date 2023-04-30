using Client.Models;
using IdentityModel;
using System.Security.Claims;

namespace Client.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            return httpContext.User.FindFirstValue(JwtClaimTypes.Subject);
        }
    }
}
