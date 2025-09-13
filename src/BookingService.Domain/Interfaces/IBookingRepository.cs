using BookingService.Domain.Entities;

namespace BookingService.Domain.Interfaces;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetAllAsync();
    Task<Booking?> GetByIdAsync(int id);
    Task CreateAsync(Booking booking);
    Task<bool> UpdateAsync(Booking booking);
    Task<bool> DeleteAsync(int id);
}