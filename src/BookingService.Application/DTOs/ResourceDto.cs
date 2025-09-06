namespace BookingService.Application.DTOs;

public class ResourceDto
{
    public int ResourceNumber { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal PricePerHour { get; set; }
}