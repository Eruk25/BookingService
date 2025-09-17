using AutoMapper;
using BookingService.Application.DTOs;
using BookingService.Application.Interfaces;
using BookingService.Domain.Interfaces;

namespace BookingService.Application.Service.Booking;

public class BookingService : IBookingService
{
    readonly IBookingRepository _bookingRepository;
    readonly IMapper _mapper;

    public BookingService(IBookingRepository bookingRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<BookingDto>> GetAllAsync()
    {
        var bookings = await _bookingRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BookingDto>>(bookings);
    }

    public async Task<BookingDto> GetByIdAsync(int id)
    {
        var booking = await _bookingRepository.GetByIdAsync(id);
        if(booking == null)
            throw new KeyNotFoundException($"Booking with id {id} not found");
        return _mapper.Map<BookingDto>(booking);
    }

    public async Task<int> CreateAsync(BookingDto bookingDto)
    {
        if(bookingDto is null)
            throw new ArgumentNullException(nameof(bookingDto));
        var booking = _mapper.Map<Domain.Entities.Booking>(bookingDto);
        await _bookingRepository.CreateAsync(booking);
        return booking.Id;
    }

    public async Task<bool> UpdateAsync(BookingDto bookingDto)
    {
        if (bookingDto is null)
            throw new ArgumentNullException(nameof(bookingDto));
        var booking = _mapper.Map<Domain.Entities.Booking>(bookingDto);
        return await _bookingRepository.UpdateAsync(booking);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _bookingRepository.DeleteAsync(id);
    }
}