using BookingService.Domain.Enums;

namespace BookingService.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int ResourceId { get; set; }
    public Resource? Resource { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Booking(int userId, int resourceId, DateTime startTime, DateTime endTime)
    {
        if(endTime <= startTime)
            throw new ArgumentException("EndTime must be later than StartTime", nameof(endTime));
        UserId = userId;
        ResourceId = resourceId;
        StartTime = startTime;
        EndTime = endTime;
    }
    protected Booking() {}
}
