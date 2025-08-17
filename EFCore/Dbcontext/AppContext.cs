using EFCoreCommon.Model;
using Microsoft.EntityFrameworkCore;

namespace TuyenDanQuan.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Citizen> Citizen { get; set; }
        public DbSet<Unit> Unit { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
