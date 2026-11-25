using IsakSiteApi.Data;
using IsakSiteApi.Dtos;
using IsakSiteApi.Enums;
using IsakSiteApi.Interfaces;
using IsakSiteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IsakSiteApi.Services
{
    public class OwnerService : IOwner
    {
        private readonly PortfolioDbContext _context;

        public OwnerService(PortfolioDbContext context) =>
            _context = context;

        public async Task<OwnerDto?> GetOwner() =>
            await _context.Owner.Select(owner => new OwnerDto()
            {
                Name = owner.Name,
                Skills = owner.Skills,
                Description = owner.Description
            }).FirstOrDefaultAsync();
        

        public async Task<EOwner> UpdateOwner(OwnerUpdateDto dto)
        {

            var owner = await _context.Owner.FirstOrDefaultAsync();
            if (owner == null)
                return EOwner.NotFound;

            if (dto.Name != string.Empty)
                owner.Name = dto.Name;
            if (dto.Skills != string.Empty)
                owner.Skills = dto.Skills;
            if (dto.Description != string.Empty)
                owner.Description = dto.Description;

            _context.Owner.Update(owner);
            await _context.SaveChangesAsync();

            return EOwner.Updated;
        }

        public async Task<EOwner> CreateOwner(OwnerCreateDto dto)
        {
            var exists = await _context.Owner.FirstOrDefaultAsync();
            if (exists != null)
                return EOwner.AlreadyExists;

            var owner = new Owner()
            {
                Name = dto.Name,
                Skills = dto.Skills,
                Description = dto.Description
            };

            await _context.Owner.AddAsync(owner);
            await _context.SaveChangesAsync();

            return EOwner.Created;
        }
    }
}
