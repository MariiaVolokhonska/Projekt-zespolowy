using System.Collections.Generic;
using GroupProject.Models;
using Microsoft.EntityFrameworkCore;

namespace QRLogic
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<QrCodeScan> QrCodeScans { get; set; }
    }
}
