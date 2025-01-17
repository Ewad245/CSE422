using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options) { }
    
    public DbSet<DeviceCategory> DeviceCategories { get; set; }
    public DbSet<DeviceStatus> DeviceStatuses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceAssignment> DeviceAssignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure unique constraints
        modelBuilder.Entity<DeviceCategory>()
            .HasIndex(c => c.CategoryName)
            .IsUnique();

        modelBuilder.Entity<Device>()
            .HasIndex(d => d.DeviceCode)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // Seed initial device statuses
        modelBuilder.Entity<DeviceStatus>().HasData(
            new DeviceStatus { StatusId = 1, StatusName = "In use" },
            new DeviceStatus { StatusId = 2, StatusName = "Broken" },
            new DeviceStatus { StatusId = 3, StatusName = "Under maintenance" }
        );
    }
}