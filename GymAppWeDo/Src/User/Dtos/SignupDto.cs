using System.ComponentModel.DataAnnotations;

namespace GymAppWeDo.User.Dtos;

public class SignupDto
{
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(30)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required] [MaxLength(30)] public string Password { get; set; } = string.Empty;
}