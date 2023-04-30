using IdentityServer4.Validation;
using System.Collections.Specialized;
using System.Security.Claims;

namespace IdentityServer.STS
{
    public class CustomAuthorizedRequestValidator : ICustomAuthorizeRequestValidator
    {
        public Task ValidateAsync(CustomAuthorizeRequestValidationContext context)
        {
            return Task.CompletedTask;
        }
    }
}
