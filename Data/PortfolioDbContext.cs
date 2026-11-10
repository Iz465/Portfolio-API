using Microsoft.EntityFrameworkCore;
using IsakSiteApi.Models;

namespace IsakSiteApi.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
        : base(options)
        {
        }

        public DbSet<Portfolio> Portfolio { get; set; }
    }
}
