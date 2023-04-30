using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Client.Services
{
    public class TokenService : ITokenService
    {
        public readonly IdentityServerSettings _identityServerSettings;
        public readonly DiscoveryDocumentResponse discoveryDocument;
        private readonly HttpClient httpClient;

        public TokenService(IOptions<IdentityServerSettings> identityServerSettings)
        {
            _identityServerSettings = identityServerSettings.Value;
            httpClient = new HttpClient();
            discoveryDocument = httpClient.GetDiscoveryDocumentAsync(_identityServerSettings.DiscoveryUrl).Result;

            if (discoveryDocument.IsError)
            {
                throw new Exception("Unable to get discovery document", discoveryDocument.Exception);
            }
        }
        public async Task<TokenResponse> GetToken()
        {
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = _identityServerSettings.ClientName,
                ClientSecret = _identityServerSettings.ClientPassword,
                Scope = _identityServerSettings.Scopes
                
            });

            if (tokenResponse.IsError)
            {
                throw new Exception("Unable to get token", tokenResponse.Exception);
            }

            return tokenResponse;
        }
    }
}
