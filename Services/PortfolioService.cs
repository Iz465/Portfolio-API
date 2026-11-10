using IsakSiteApi.Data;
using IsakSiteApi.Dtos;
using IsakSiteApi.Enums;
using IsakSiteApi.Interfaces;
using IsakSiteApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsakSiteApi.Services
{
    public class PortfolioService : IPortfolio
    {

        private readonly PortfolioDbContext _context;
        public PortfolioService(PortfolioDbContext context) =>
            _context = context;

        public async Task<List<Portfolio>> GetPortfolios()
        {
            return await _context.Portfolio.ToListAsync();
        }

        public async Task<EPortfolio> UpdatePortfolio(int id, PortfolioUpdateDto dto)
        {
            var portfolio = await _context.Portfolio.FindAsync(id);
            if (portfolio == null)
                return EPortfolio.NotFound;

            if (dto.Title != string.Empty)
                portfolio.Title = dto.Title;
            if (dto.Link != string.Empty)
                portfolio.Link = dto.Link;

            _context.Portfolio.Update(portfolio);
            await _context.SaveChangesAsync();

            return EPortfolio.Updated;
        }

        public async Task<EPortfolio> CreatePortfolio(Portfolio portfolio)
        {

            await _context.Portfolio.AddAsync(portfolio);
            await _context.SaveChangesAsync();

            return EPortfolio.Created;
        }

        public async Task<EPortfolio> DeletePortfolio(int id)
        {
            var portfolio = await _context.Portfolio.FindAsync(id);
            if (portfolio == null)
                return EPortfolio.NotFound;

            _context.Portfolio.Remove(portfolio);
            await _context.SaveChangesAsync();
            return EPortfolio.Deleted;

        }
    }
}
