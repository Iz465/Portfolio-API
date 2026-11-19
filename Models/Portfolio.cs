using System.ComponentModel.DataAnnotations;

namespace IsakSiteApi.Models
{
    public class Portfolio
    {

        public int Id { get; set; }

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
