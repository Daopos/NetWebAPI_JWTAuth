using System.ComponentModel.DataAnnotations;

namespace JWTAspNet.Entities
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserRole Role { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }
    }

    public enum UserRole
    {
        Admin = 1,
        User = 2 
    }   
}
