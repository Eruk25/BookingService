using BookingService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Resource> Resources { get; set; }
}
