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
    public Booking(int userId, List<Resource> resources, DateTime startTime, DateTime endTime)
    {
        if(endTime <= startTime)
            throw new ArgumentException("EndTime must be later than StartTime", nameof(endTime));
        UserId = userId;
        Resources = resources;
        StartTime = startTime;
        EndTime = endTime;
    }
    protected Booking() {}
}
