using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GymAppWeDo.User.Dtos;
using GymAppWeDo.User.Model;
using GymAppWeDo.User.Repository;
using Microsoft.IdentityModel.Tokens;

namespace GymAppWeDo.User.Service;

public class TokenService : ITokenService
{
    
    private readonly IConfiguration _configuration;
    private readonly ITokenRepository _tokenRepository;
    public TokenService(IConfiguration configuration,ITokenRepository tokenRepository)
    {
        _configuration = configuration;
        _tokenRepository = tokenRepository;
    }
    
    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var authSignInKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var TokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _configuration["JWT:ValidIssuer"],
            Audience = _configuration["JWT:ValidAudience"],
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials
                (authSignInKey, SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(TokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];

        using var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = _configuration["JWT:ValidAudience"],
            ValidIssuer = _configuration["JWT:ValidIssuer"],
            ValidateLifetime = false,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]))
        };
        ;
        
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);
        
        var jwtSecurityToken = securityToken as JwtSecurityToken;

        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals
                (SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }
        
        return principal;
    }

    public TokenInfo GetToken(Model.User user)
    {
        return _tokenRepository.GetToken(user);
    }

    public TokenInfo AddToken(Model.User user)
    {
        throw new NotImplementedException();
    }

    public async Task AddOrUpdateTokenOnLogin(Model.User user, string refreshToken)
    {
        var tokenInfo = GetToken(user);
        if (tokenInfo == null)
        {
            var newTokenInfo = new TokenInfo
            {
                
                RefreshToken = refreshToken,
                Username = user.UserName,
                ExiredAt = DateTime.UtcNow.AddDays(7),
            }; 
            await _tokenRepository.AddTokenAsync(newTokenInfo);
        }
        else
        {
            tokenInfo.RefreshToken = refreshToken;
            tokenInfo.ExiredAt = DateTime.UtcNow.AddDays(7);
            await _tokenRepository.UpdateTokenAsync(tokenInfo);
        }
    }

    public bool CheckValidityOfRefreshToken(Model.User user,string refreshToken)
    {
         var tokenInfo = _tokenRepository.GetToken(user);
         if (tokenInfo == null || tokenInfo.RefreshToken != refreshToken
                               || tokenInfo.ExiredAt <= DateTime.UtcNow)
         {
             return false;
         }
         return true;
    }

    public async Task UpdateRefreshToken(Model.User user, string refreshToken)
    {
        var tokenInfo = _tokenRepository.GetToken(user);
        tokenInfo.RefreshToken = refreshToken;
        await _tokenRepository.UpdateTokenAsync(tokenInfo);
    }
}