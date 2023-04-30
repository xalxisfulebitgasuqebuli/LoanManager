using IdentityModel;
using IdentityServer.Models;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer.STS
{
    public class LoansManagerProfileService : IProfileService
    {
        private readonly UserManager<CustomIdentityUser> _userManager;

        public LoansManagerProfileService(UserManager<CustomIdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //add user id to claims
            var user = await _userManager.GetUserAsync(context.Subject);
            var claims = new Claim[]
            {
                new Claim(JwtClaimTypes.BirthDate, user.BirthDate.ToShortDateString()),
                new Claim("personal_id", user.PersonalId),
                new Claim(JwtClaimTypes.Subject, user.Id),
                new Claim(JwtClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(JwtClaimTypes.GivenName, user.FirstName),
                new Claim(JwtClaimTypes.FamilyName, user.LastName),
                new Claim(JwtClaimTypes.WebSite, "https://angellafreeman.com"),
                new Claim("location", "somewhere")
            };

            context.IssuedClaims.AddRange(claims);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
