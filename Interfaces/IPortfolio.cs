using IsakSiteApi.Dtos;
using IsakSiteApi.Enums;


namespace IsakSiteApi.Interfaces
{
    public interface IPortfolio
    {
        Task<List<PortfolioDto>> GetPortfolios();
        Task<EPortfolio> UpdatePortfolio(int id, PortfolioUpdateDto dto);
        Task<EPortfolio> CreatePortfolio(PortfolioCreateDto portfolio);
        Task<EPortfolio> DeletePortfolio(int id);

    }
}
