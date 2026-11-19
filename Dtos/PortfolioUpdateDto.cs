using System.ComponentModel.DataAnnotations;

namespace IsakSiteApi.Dtos
{
    public record PortfolioUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Technologies { get; set; } = string.Empty;
        public string GithubLink { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
    }
}
