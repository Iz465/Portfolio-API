using System.ComponentModel.DataAnnotations;

namespace IsakSiteApi.Dtos
{
    public class OwnerCreateDto
    {

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Skills { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

    }
}
