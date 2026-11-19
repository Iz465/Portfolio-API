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

        public async Task<List<PortfolioDto>> GetPortfolios() =>
            await _context.Portfolio.Select(item => new PortfolioDto()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Technologies = item.Technologies,
                GithubLink = item.GithubLink,
                ImageURL = item.ImageURL
            }).ToListAsync();
        

        public async Task<EPortfolio> UpdatePortfolio(int id, PortfolioUpdateDto dto)
        {
            var portfolio = await _context.Portfolio.FindAsync(id);
            if (portfolio == null)
                return EPortfolio.NotFound;

            if (dto.Title != string.Empty)
                portfolio.Title = dto.Title;

            if (dto.Description != dto.Description)
                portfolio.Description = dto.Description;

            if (dto.Technologies != string.Empty)
                portfolio.Technologies = dto.Technologies;
         
            if (dto.GithubLink != string.Empty)
                portfolio.GithubLink = dto.GithubLink;

            if (dto.ImageURL != string.Empty)
                portfolio.ImageURL = dto.ImageURL;


            _context.Portfolio.Update(portfolio);
            await _context.SaveChangesAsync();

            return EPortfolio.Updated;
        }

        public async Task<EPortfolio> CreatePortfolio(PortfolioCreateDto dto)
        {
            var portfolio = new Portfolio()
            {
                Title = dto.Title,
                Description = dto.Description,
                Technologies = dto.Technologies,
                GithubLink = dto.GithubLink,
                ImageURL = dto.ImageURL
            };

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
