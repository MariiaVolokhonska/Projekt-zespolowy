using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QRLogic.Entities;

namespace QRLogic
{

    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<QrCodeScan> QrCodeScans { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<UserPontsWallet> UserPontsWallets { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=localhost;Database=GroupProject;Trusted_Connection=True;TrustServerCertificate=True;", x => x.MigrationsHistoryTable("__EFMigrationsHistory", "GroupProject"));
        }
    }
}
