namespace GymAppWeDo.User.Repository;

public interface ITokenRepository
{
    TokenInfo GetToken(Model.User user);
    
    Task AddToken(TokenInfo token);
    Task UpdateToken(TokenInfo token);
}