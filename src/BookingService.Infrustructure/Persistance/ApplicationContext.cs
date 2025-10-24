using BookingService.Domain.Entities;
using BookingService.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Persistance;

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
            .HasMaxLength(500);
        modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
        modelBuilder.Entity<User>().HasIndex(u =>  u.Email).IsUnique();
        
        modelBuilder.Entity<Booking>().HasKey(b => b.Id);
        
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Booking>()
            .Property(b => b.StartTime)
            .IsRequired();
        
        modelBuilder.Entity<Booking>()
            .Property(b => b.EndTime)
            .IsRequired();

        modelBuilder.Entity<Booking>()
            .HasOne(r => r.Resource)
            .WithOne()
            .HasForeignKey<Booking>(r => r.ResourceId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Resource>().HasKey(r => r.Id);
        modelBuilder.Entity<Resource>()
            .Property(r => r.Title)
            .IsRequired()
            .HasMaxLength(60);
        modelBuilder.Entity<Resource>()
            .Property(r => r.Description)
            .IsRequired()
            .HasMaxLength(500);
        modelBuilder.Entity<Resource>()
            .Property(r => r.Address)
            .IsRequired()
            .HasMaxLength(500);
        modelBuilder.Entity<Resource>()
            .Property(r => r.PricePerMonth)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Resource>()
            .Property(r => r.ImageUrl)
            .IsRequired()
            .HasMaxLength(255);
        modelBuilder.Entity<Resource>()
            .Property(r => r.SourceId)
            .IsRequired()
            .HasMaxLength(100);
    }
}
    