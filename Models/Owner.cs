using System.ComponentModel.DataAnnotations;

namespace IsakSiteApi.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Skills { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
