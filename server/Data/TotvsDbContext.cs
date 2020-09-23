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
                Id = new Guid("97abbeca-c716-4eb0-b1da-d0e7287118b3"),
                Name = "Guilherme Neubaner",
                Email = "guilherme.neubaner@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                Enabled = true
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = new Guid("efe1f695-4048-4ef8-939e-017fe39cba01"),
                Name = "TOTVS Admin",
                Email = "admin@totvs.com.br",
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                Enabled = true
            });
        }

    }
}