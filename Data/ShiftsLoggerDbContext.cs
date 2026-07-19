using Microsoft.EntityFrameworkCore;
using ShiftsLogger.Models;
using System.Reflection.Metadata;

namespace ShiftsLogger.Data
{
    public class ShiftsLoggerDbContext : DbContext
    {
        public ShiftsLoggerDbContext(DbContextOptions<ShiftsLoggerDbContext> options)
        : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
            .HasKey(e => e.Id);

            modelBuilder.Entity<Shift>()
            .HasKey(s => s.Id);

            modelBuilder.Entity<Employee>()
            .HasMany(e => e.Shifts)
            .WithOne(s => s.Employee)
            .HasForeignKey(e => e.EmployeeId)
            .IsRequired();
        }
    }
}
