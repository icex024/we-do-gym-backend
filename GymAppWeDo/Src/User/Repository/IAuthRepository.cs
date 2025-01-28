using Microsoft.AspNetCore.Identity;

namespace GymAppWeDo.User.Repository;

public interface IAuthRepository
{
    Task<Model.User> FindUserByEmail(string email);
     Task<bool> CheckIfRoleExistsAsync(string role);
     Task<IdentityResult> CreateRoleAsync(IdentityRole role);
     Task<IdentityResult>  CreateUserAsync(Model.User user, string password);
     Task<IdentityResult>  AddToRoleAsync(Model.User user,string role);
     Task<bool> CheckPasswordAsync(Model.User user,string password);
     Task<IList<string>> GetRolesAsync(Model.User user);
}