using GymAppWeDo.Data;
using GymAppWeDo.User.Model;

namespace GymAppWeDo.User.Repository;

public class TokenRepository : ITokenRepository
{
    private readonly MyDbContext _context;

    public TokenRepository(MyDbContext context)
    {
        _context = context;
    }
    
    public TokenInfo GetToken(Model.User user)
    {
        return _context.TokenInfos.FirstOrDefault(item => item.Username == user.UserName);
    }

    public async Task AddTokenAsync(TokenInfo token)
    {
       _context.TokenInfos.Add(token);
       await _context.SaveChangesAsync();
    }

    public async Task UpdateTokenAsync(TokenInfo token)
    {
        _context.TokenInfos.Update(token);
        await _context.SaveChangesAsync();
    }
}