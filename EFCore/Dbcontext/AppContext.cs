using EFCoreCommon.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TuyenDanQuan.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Citizen> Citizen { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<RequestCitizen> RequestCitizen { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<MissionCitizen> MissionCitizen { get; set; }
        public DbSet<Mission> Mission { get; set; } 


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

            modelBuilder.Entity<Mission>()
                .HasOne(m => m.TaskType)
                .WithMany(t => t.Missions)
                .HasForeignKey(m => m.TaskTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Mission>()
                .HasOne(m => m.Unit)
                .WithMany(u => u.Missions)
                .HasForeignKey(m => m.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Citizen>()
                .HasOne(c => c.Unit)
                .WithMany(u => u.Citizens)
                .HasForeignKey(c => c.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MissionCitizen>()
                .HasKey(mc => new { mc.MissionId, mc.CitizenId });

            modelBuilder.Entity<MissionCitizen>()
                .HasOne(mc => mc.Mission)
                .WithMany(m => m.MissionCitizens)
                .HasForeignKey(mc => mc.MissionId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<MissionCitizen>()
                .HasOne(mc => mc.Citizen)
                .WithMany(c => c.MissionCitizens)   
                .HasForeignKey(mc => mc.CitizenId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<TaskType>().HasData(
                new TaskType { Id = 1, Code = "TRAIN", Name = "Huấn luyện", Description = "Nhiệm vụ huấn luyện dân quân" },
                new TaskType { Id = 2, Code = "PATROL", Name = "Tuần tra", Description = "Nhiệm vụ tuần tra an ninh" },
                new TaskType { Id = 3, Code = "SUPPORT", Name = "Hỗ trợ", Description = "Hỗ trợ địa phương, cứu trợ" },
                new TaskType { Id = 4, Code = "DEFENSE", Name = "Phòng thủ", Description = "Tham gia phòng thủ khi cần" }
            );
        }
    }
}
