using EFCoreCommon.Model;
using Microsoft.EntityFrameworkCore;

namespace TuyenDanQuan.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Citizen> Citizen { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<RequestCitizen> RequestCitizen { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.RequestUnit)
                .WithMany()
                .HasForeignKey(r => r.RequestUnitId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Request>()
                .HasOne(r => r.ReceiveUnit)
                .WithMany()
                .HasForeignKey(r => r.ReceiveUnitId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
    


}
