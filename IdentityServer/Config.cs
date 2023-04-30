using IdentityModel;
using IdentityServer4.Models;
namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string>{"role", JwtClaimTypes.Subject}
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[] { new ApiScope("LoanManager.read"), new ApiScope("LoanManager.write")};

        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("LoanManager")
                {
                    Scopes = new List<string> { "LoanManager.read", "LoanManager.write" },
                    ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256()) },
                    UserClaims = new List<string> { "role", JwtClaimTypes.Subject }
                }
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                    AllowedScopes = { "openid", "profile", "LoanManager.read", "LoanManager.write" }
                },

                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:7283/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:7283/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:7283/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "LoanManager.read" },
                    RequirePkce = true,
                    RequireConsent = true,
                    AllowPlainTextPkce = false
                }
            };
    }
}
