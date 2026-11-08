using System.ComponentModel.DataAnnotations;

namespace IsakSiteApi.Models
{
    public class Portfolio
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]

        public string Link { get; set; } = string.Empty;
        

    }
}
