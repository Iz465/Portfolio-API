using System.ComponentModel.DataAnnotations;

namespace IsakSiteApi.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty; 
    }
}
