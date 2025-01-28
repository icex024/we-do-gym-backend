using GymAppWeDo.User.Dtos;
using Microsoft.AspNetCore.Identity;

namespace GymAppWeDo.User.Service;

public interface IAuthService
{
    Task<IdentityResult> CreateNewRole(string role);
    Task<IdentityResult> CreateNewUser(SignupDto dto);
    Task<Model.User>  GetUserByEmail(string email);

    Task<IdentityResult> AddUserToRole(string email, string role);
    Task<bool> CheckIfUserExists(string email);

    Task<bool> CheckPassword(Model.User user, string password);
    Task<IList<string>> GetRolesAsync(Model.User user);
}