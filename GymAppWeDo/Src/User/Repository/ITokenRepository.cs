using GymAppWeDo.User.Model;

namespace GymAppWeDo.User.Repository;

public interface ITokenRepository
{
    TokenInfo GetToken(Model.User user);
    
    Task AddTokenAsync(TokenInfo token);
    Task UpdateTokenAsync(TokenInfo token);
}