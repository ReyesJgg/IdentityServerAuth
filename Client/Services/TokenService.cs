using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Client.Services
{
    public class TokenService : ITokenService
    {
        public readonly IOptions<IdentityServerSettings> _identityServerSettings;
        public readonly DiscoveryDocumentResponse discoveryDocument;
        public readonly HttpClient httpClient;

        public TokenService(IOptions<IdentityServerSettings> identityServerSettings) {
            _identityServerSettings = identityServerSettings;
            httpClient = new HttpClient();
            discoveryDocument = httpClient.GetDiscoveryDocumentAsync(identityServerSettings.Value.DiscoveryUrl).Result;

            if (discoveryDocument.IsError) {
                throw new Exception("Unable to get discovery document", discoveryDocument.Exception);
            }
        }

        public async Task<TokenResponse> GetToken(string scope) {
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = _identityServerSettings.Value.ClientName,
                ClientSecret = _identityServerSettings.Value.ClientPassword,
                Scope = scope
            });

            if (tokenResponse.IsError)
            {
                throw new Exception("Unable to get token", tokenResponse.Exception);
            }

            return tokenResponse;
        }
    }
}
