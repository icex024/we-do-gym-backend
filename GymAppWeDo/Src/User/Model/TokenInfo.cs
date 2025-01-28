using System.ComponentModel.DataAnnotations;

namespace GymAppWeDo.User.Model;

public class TokenInfo
{
    public int Id { get; set; }

    [Required] [MaxLength(30)] public string Username { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(200)]
    public string RefreshToken { get; set; } = string.Empty;
    
    [Required]
    public DateTime ExiredAt { get; set; }
}