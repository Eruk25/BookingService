namespace BookingService.Application.DTOs;

public class ResourceDto
{
    public int ResourceNumber { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public decimal PricePerMonth { get; set; }
    public string ImageUrl { get; set; }
    public string SourceId { get; set; }
}