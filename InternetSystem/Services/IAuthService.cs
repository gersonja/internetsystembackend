using InternetSystem.Models;
using System.IdentityModel.Tokens.Jwt;

namespace InternetSystem.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> ReturnToken(LoginRequestModel authorization);
        int ReadToken(string token);
    }
}
