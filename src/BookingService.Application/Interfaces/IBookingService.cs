using BookingService.Application.DTOs;

namespace BookingService.Application.Interfaces;

public interface IBookingService
{
    Task<IEnumerable<BookingDto>> GetAllAsync();
    Task<BookingDto> GetByIdAsync(int id);
    Task CreateAsync(BookingDto bookingDto);
    Task UpdateAsync(BookingDto bookingDto);
    Task DeleteAsync(int id);
}