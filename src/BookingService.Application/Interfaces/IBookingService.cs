using BookingService.Application.DTOs;

namespace BookingService.Application.Interfaces;

public interface IBookingService
{
    Task<IEnumerable<BookingDto>> GetAllAsync();
    Task<BookingDto> GetByIdAsync(int id);
    Task<BookingDto> CreateAsync(BookingDto bookingDto);
    Task<bool> UpdateAsync(BookingDto bookingDto);
    Task<bool> DeleteAsync(int id);
}