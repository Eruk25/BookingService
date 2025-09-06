namespace BookingService.Application.DTOs;

public class BookingDto
{
    public int BookingNumber { get; set; }
    public List<ResourceDto> Resources { get; set; } = new();
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}