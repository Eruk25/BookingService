namespace BookingService.Application.DTOs;

public class BookingDto
{
    public int BookingNumber { get; set; }
    public ResourceDto Resource { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}