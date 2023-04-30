using Microsoft.EntityFrameworkCore.Metadata;

namespace Client.Services
{
    public class IdentityServerSettings
    {
        public string DiscoveryUrl { get; set; }
        public string ClientName { get; set; }
        public string ClientPassword { get; set; }
        public bool UseHttps { get; set; }
        public string Scopes { get; set; }
    }
}
