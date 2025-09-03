using BookingService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>()
            .Property(u => u.UserName)
            .IsRequired()
            .HasMaxLength(50);
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);
        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(30);
        modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
        modelBuilder.Entity<User>().HasIndex(u =>  u.Email).IsUnique();
    }
}
    