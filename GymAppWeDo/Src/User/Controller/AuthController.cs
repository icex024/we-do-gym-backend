using System.Security.Claims;
using GymAppWeDo.Helpers;
using GymAppWeDo.User.Dtos;
using GymAppWeDo.User.Enum;
using GymAppWeDo.User.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;

namespace GymAppWeDo.User.Controller;

public class AuthController : BaseApiController
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;
    private readonly ITokenService _tokenService;

    
    public AuthController(IAuthService authService,ILogger<AuthController> logger,ITokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
        _logger = logger;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup(SignupDto dto)
    {
        try
        {
            var existingUser = await _authService.CheckIfUserExists(dto.Email);
            if (existingUser)
            {
                return BadRequest("User already exists");
            }

            if ((await _authService.CreateNewRole(Roles.User)) == IdentityResult.Failed())
            {
           
                    _logger.LogError($"Failed to create user role. Errors ");
                    return BadRequest($"Failed to create user role. Errors ");
            }
           

            
            var createUserResult = await _authService.CreateNewUser(dto);

            if (createUserResult.Succeeded == false)
            {
                var errors = createUserResult.Errors.Select(e => e.Description);
                _logger.LogError($"Failed to create user. Errors: {string.Join(", ", errors)}");
                return BadRequest($"Failed to create user. Errors: {string.Join(", ", errors)}");
            }
            
            var addUserToRoleResult = await _authService.AddUserToRole(dto.Email, Roles.User);
            if (addUserToRoleResult.Succeeded == false)
            {
                var errors = addUserToRoleResult.Errors.Select(e => e.Description);
                _logger.LogError($"Failed to add role to the user. Errors : {string.Join(",", errors)}");
            }
            return CreatedAtAction(nameof(Signup), null);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        try
        {
            var user = await _authService.GetUserByEmail(dto.Username);
            if (user == null)
            {
                return BadRequest("User with this username is not registered with us.");
            }
            bool isValidPassword = await _authService.CheckPassword(user, dto.Password);
            if (isValidPassword == false)
            {
                return Unauthorized();
            }

            List<Claim> authClaims =
            [
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ];
            var userRoles = await _authService.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            
            var token = _tokenService.GenerateAccessToken(authClaims);
            
            string refreshToken = _tokenService.GenerateRefreshToken();

            await _tokenService.AddOrUpdateTokenOnLogin(user, refreshToken);
            
            return Ok(new TokenDto()
            {
                AccessToken = token,
                RefreshToken = refreshToken
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Unauthorized();
        }
    }

    [HttpPost("token/refresh")]
    public async Task<IActionResult> RefreshToken(TokenDto dto)
    {
        try
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(dto.AccessToken);
            var user = await _authService.GetUserByEmail(principal.Identity.Name);

            if (_tokenService.CheckValidityOfRefreshToken(user, dto) != true)
            {
                 return BadRequest("Invalid refresh token. Please login again.");
            }
            
            var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            
            _tokenService.UpdateRefreshToken(user,newRefreshToken);
            
            return Ok(new TokenDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost("token/revoke")]
    [Authorize]
    public async Task<IActionResult> RevokeToken()
    {
        try
        {
            var user = await _authService.GetUserByEmail(User.Identity.Name);
            
            await _tokenService.UpdateRefreshToken(user, "");
            
            return Ok(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}