namespace IsakSiteApi.Dtos
{
    public record PortfolioUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
    }
}
