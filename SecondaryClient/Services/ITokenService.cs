using IdentityModel.Client;

namespace SecondaryClient.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
