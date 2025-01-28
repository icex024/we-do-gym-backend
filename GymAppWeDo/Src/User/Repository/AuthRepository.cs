using Microsoft.AspNetCore.Identity;

namespace GymAppWeDo.User.Repository;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<Model.User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthRepository(UserManager<Model.User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    public async Task<Model.User> FindUserByEmail(string email)
    {
        return await _userManager.FindByNameAsync(email);
    }

    public async Task<bool> CheckIfRoleExistsAsync(string role)
    {
        return await _roleManager.RoleExistsAsync(role);
    }

    public async  Task<IdentityResult>  CreateRoleAsync(IdentityRole role)
    {
        return await _roleManager.CreateAsync(role);
    }

    public async Task<IdentityResult>  CreateUserAsync(Model.User user, string password)
    {
        return   await _userManager.CreateAsync(user, password);
    }

    public async Task<IdentityResult>  AddToRoleAsync(Model.User user, string role)
    {
        return await _userManager.AddToRoleAsync(user, role);
    }

    public async Task<bool> CheckPasswordAsync(Model.User user, string password)
    {
        
        return await _userManager.CheckPasswordAsync(user,password);
    }

    public async Task<IList<string>> GetRolesAsync(Model.User user)
    {
        return await _userManager.GetRolesAsync(user);
    }
}