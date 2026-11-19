using System.ComponentModel.DataAnnotations;

namespace IsakSiteApi.Dtos
{
    public class PortfolioCreateDto
    {
      
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Technologies { get; set; } = string.Empty;

        [Required]
        public string GithubLink { get; set; } = string.Empty;

        [Required]
        public string ImageURL { get; set; } = string.Empty;
    }
}
