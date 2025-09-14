using BookingService.Application.DTOs;
using BookingService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService  _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookingDto>>> GetAllAsync()
    {
        try
        {
            var bookings = await _bookingService.GetAllAsync();
            return Ok(bookings);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookingDto>> GetByIdAsync(int id)
    {
        var booking = await _bookingService.GetByIdAsync(id);
        return Ok(booking);
    }

    [HttpPost]
    public async Task<ActionResult<BookingDto>> CreateAsync(BookingDto booking)
    {
        var createdBooking = await _bookingService.CreateAsync(booking);
        return CreatedAtAction(nameof(GetByIdAsync), createdBooking.BookingNumber);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> UpdateAsync(int id, BookingDto booking)
    {
        var success =  await _bookingService.UpdateAsync(booking);
        return Ok(success);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var success = await _bookingService.DeleteAsync(id);
        return Ok(success);
    }
}