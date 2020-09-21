using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid(),
                Name = "Guilherme Neubaner",
                Email = "guilherme.neubaner@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                Enabled = true
            });
        }

    }
}