using EFCoreCommon.Model;
using Microsoft.EntityFrameworkCore;

namespace TuyenDanQuan.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Citizen> Citizen { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<DisciplineApproval> DisciplineApproval { get; set; }
        public DbSet<DisciplineProposal> DisciplineProposal { get; set; }
        public DbSet<RewardApproval> RewardApproval { get; set; }
        public DbSet<RewardProposal> RewardProposal { get; set; }
        public DbSet<Mission> Mission { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
