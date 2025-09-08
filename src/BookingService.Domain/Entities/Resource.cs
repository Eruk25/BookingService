namespace BookingService.Domain.Entities;

public class Resource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal PricePerHour { get; set; }
    public string ImageUrl { get; set; }

    public Resource(string title, string description,
        decimal pricePerHour, string imageUrl)
    {
        if(string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be null or empty", nameof(title));
        if(string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be null or empty", nameof(description));
        if(pricePerHour <= 0)
            throw new ArgumentException("Price per hour cannot be greater than zero", nameof(pricePerHour));
        if(string.IsNullOrWhiteSpace(imageUrl))
            throw new ArgumentException("ImageUrl cannot be null or empty", nameof(imageUrl));
        Title = title;
        Description = description;
        PricePerHour = pricePerHour;
        ImageUrl = imageUrl;
    }
}
