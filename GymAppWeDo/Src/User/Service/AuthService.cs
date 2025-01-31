using GymAppWeDo.User.Dtos;
using GymAppWeDo.User.Repository;
using Microsoft.AspNetCore.Identity;

namespace GymAppWeDo.User.Service;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }
    
    public async Task<IdentityResult> CreateNewRole(string role)
    {
        if ((await _authRepository.CheckIfRoleExistsAsync(role)) == false)
        {
            return await _authRepository.CreateRoleAsync(new IdentityRole(role.ToString()));
        }

        return IdentityResult.Success;
    }

    public async  Task<IdentityResult> CreateNewUser(SignupDto dto)
    {
        Model.User user = new()
        {
            Email = dto.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName
        };
        return await _authRepository.CreateUserAsync(user, dto.Password);
    }

    public async Task<Model.User> GetUserByEmail(string email)
    {
        return await _authRepository.FindUserByEmail(email);
    }

    public async Task<IdentityResult> AddUserToRole(string email, string role)
    {
        var user = await _authRepository.FindUserByEmail(email);
        if (user != null)
        {
            return await _authRepository.AddToRoleAsync(user, role);
        }
        return IdentityResult.Failed();
    }

    public async Task<bool> CheckIfUserExists(string email)
    {
        Model.User? user = await _authRepository.FindUserByEmail(email);
        if (user != null)
        {
            return true;
        }
        return false;
    }

    public Task<bool> CheckPassword(Model.User user, string password)
    {
        return _authRepository.CheckPasswordAsync(user, password);
    }

    public async Task<IList<string>> GetRolesAsync(Model.User user)
    {
        return await _authRepository.GetRolesAsync(user);
    }
}