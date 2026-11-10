using System.ComponentModel.DataAnnotations;

namespace IsakSiteApi.Models
{
    public class Portfolio
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]

        public string Link { get; set; } = string.Empty;
        

    }
}
