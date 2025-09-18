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

    [HttpGet("user/{userId}",  Name = "GetByUserIdAsync")]
    public async Task<ActionResult<BookingDto>> GetByIdAsync(int id)
    {
        var booking = await _bookingService.GetByIdAsync(id);
        return Ok(booking);
    }

    [HttpPost]
    public async Task<ActionResult<BookingDto>> CreateAsync(BookingDto booking)
    {
        var createdId = await _bookingService.CreateAsync(booking);
        return CreatedAtRoute("GetByUserIdAsync", new { id = createdId}, createdId);
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