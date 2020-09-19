using Microsoft.EntityFrameworkCore;

namespace totvs_test
{
    public class TotvsDbContext : DbContext
    {
        public TotvsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }

    }
}