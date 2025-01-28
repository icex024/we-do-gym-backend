using System.Security.Claims;
using GymAppWeDo.User.Dtos;
using GymAppWeDo.User.Model;

namespace GymAppWeDo.User.Service;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);
    
    TokenInfo GetToken(Model.User user);
    
    TokenInfo AddToken(Model.User user);
    
    Task AddOrUpdateTokenOnLogin(Model.User user, string refreshToken);

    bool CheckValidityOfRefreshToken(Model.User user,TokenDto dto);
    
    Task UpdateRefreshToken(Model.User user,string refreshToken);
}