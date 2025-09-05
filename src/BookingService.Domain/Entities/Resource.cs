namespace BookingService.Domain.Entities;

public class Resource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal PricePerHour { get; set; }
    public string ImageUrl { get; set; }
}
