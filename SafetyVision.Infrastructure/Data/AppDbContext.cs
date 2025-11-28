using Microsoft.EntityFrameworkCore;
using SafetyVision.Core.Entities;
using SafetyVision.Infrastructure.Data.Seeders;

namespace SafetyVision.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<SafetyOfficer> SafetyOfficers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Violation> Violations { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            // Seeding Departments
            DepartmentSeeder.SeedDepartments(modelBuilder);
        }
    }
}
