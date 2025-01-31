using System.ComponentModel.DataAnnotations;

namespace GymAppWeDo.User.Dtos;

public class TokenDto
{
    [Required] public string AccessToken { get; set; } = string.Empty;

}