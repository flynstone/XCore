using Microsoft.EntityFrameworkCore;
using XCore.Entities.Configurations;
using XCore.Entities.Models.Overtime;
using XCore.Entities.Models.Rentals;

namespace XCore.Entities
{
    public class XCoreDbContext : DbContext
    {
        public XCoreDbContext(DbContextOptions options) : base(options)
        {
        }


        // Create Database Table (COMP200 Project)
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        // Create Database Table (COMP266 Project)
        public DbSet<Backup> Backups { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeBackup> EmployeeBackups { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<RuleType> RuleTypes { get; set; }
        public DbSet<WeeklyOvertime> WeeklyOvertimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeBackup>()
                .HasKey(e => new { e.EmployeeId, e.BackupId });

            modelBuilder.Entity<EmployeeBackup>()
                .HasOne(e => e.Employee)
                .WithMany(eb => eb.EmployeeBackups)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<EmployeeBackup>()
                .HasOne(e => e.Backup)
                .WithMany(eb => eb.EmployeeBackups)
                .HasForeignKey(e => e.BackupId);

            modelBuilder.ApplyConfiguration(new CrewConfiguration());
        }
    }
}