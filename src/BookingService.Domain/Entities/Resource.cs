namespace BookingService.Domain.Entities;

public class Resource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public decimal PricePerMonth { get; set; }
    public string ImageUrl { get; set; }
    public string SourceId { get; set; }

    public Resource(string title, string description, string address
        ,decimal pricePerMonth, string imageUrl, string sourceId)
    {
        if(string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be null or empty", nameof(title));
        if(string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be null or empty", nameof(description));
        if(string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address cannot be null or empty", nameof(address));
        if(pricePerMonth <= 0)
            throw new ArgumentException("Price per hour cannot be greater than zero", nameof(pricePerMonth));
        if(string.IsNullOrWhiteSpace(imageUrl))
            throw new ArgumentException("ImageUrl cannot be null or empty", nameof(imageUrl));
        Title = title;
        Description = description;
        Address = address;
        PricePerMonth = pricePerMonth;
        ImageUrl = imageUrl;
        SourceId = sourceId;
    }
    public Resource() {}
}
