namespace BookingService.Domain;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int ResourceId { get; set; }
    public Resource? Resource { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
