using BookingService.Domain.Enums;

namespace BookingService.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public List<Resource> Resources { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
