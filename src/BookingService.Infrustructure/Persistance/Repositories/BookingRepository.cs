using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Persistance.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationContext _context;

    public BookingRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await _context.Bookings
            .Include(u => u.User)
            .Include(r => r.Resource)
            .ToListAsync();
    }

    public async Task<Booking?> GetByIdAsync(int id)
    {
        return await _context.Bookings
            .Include(u => u.User)
            .Include(r => r.Resource)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task CreateAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Booking booking)
    {
        var entity = await _context.Bookings.FirstAsync(e => e.Id == booking.Id);
        entity.UpdateUser(booking.UserId);
        entity.UpdateResource(booking.ResourceId);
        entity.UpdateBookingTime(entity.StartTime, entity.EndTime);
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var booking = await _context.Bookings.FirstAsync(b => b.Id == id);
        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        return true;
    }
}