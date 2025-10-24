namespace BookingService.Domain.Entities;

public class Resource
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Address { get; private set; }
    public string Description { get; private set; }
    public decimal PricePerMonth { get; private set; }
    public string ImageUrl { get; private set; }
    public string SourceId { get; private set; }

    public Resource(string title, string description, string address
        , decimal pricePerMonth, string imageUrl, string sourceId)
    {
        UpdateTitle(title);
        UpdateDescription(description);
        UpdateAddress(address);
        UpdatePricePerMonth(pricePerMonth);
        UpdateImageUrl(imageUrl);
        UpdateSourceId(sourceId);
    }

    public void UpdateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be null or empty", nameof(title));
        Title = title;
    }

    public void UpdateDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
            throw new ArgumentException("Description cannot be null or empty", nameof(description));
    }

    public void UpdateAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address cannot be null or empty", nameof(address));
        Address = address;
    }

    public void UpdatePricePerMonth(decimal pricePerMonth)
    {
        if(pricePerMonth <= 0)
            throw new ArgumentException("Price per hour cannot be greater than zero", nameof(pricePerMonth));
        PricePerMonth = pricePerMonth;
    }

    public void UpdateImageUrl(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            throw new ArgumentException("ImageUrl cannot be null or empty", nameof(imageUrl));
        ImageUrl = imageUrl;
    }

    public void UpdateSourceId(string sourceId)
    {
        if(string.IsNullOrEmpty(sourceId))
            throw new ArgumentException("SourceId cannot be null or empty", nameof(sourceId));
        SourceId = sourceId;
    }
    public Resource() {}
}
