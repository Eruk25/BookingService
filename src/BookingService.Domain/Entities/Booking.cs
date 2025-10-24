using BookingService.Domain.Enums;

namespace BookingService.Domain.Entities;

public class Booking
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public User? User { get; private set; }
    public int ResourceId { get; private set; }
    public Resource? Resource { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public Booking(int userId, int resourceId, DateTime startTime, DateTime endTime)
    {
        UpdateUser(userId);
        UpdateResource(resourceId);
        UpdateBookingTime(startTime, endTime);
    }

    public void UpdateUser(int userId)
    {
        if(userId <= 0)
            throw new ArgumentException("UserId must be greater than 0", nameof(userId));
        UserId = userId;
    }

    public void UpdateResource(int resourceId)
    {
        if(resourceId <= 0)
            throw new ArgumentException("ResourceId must be greater than 0", nameof(resourceId));
        ResourceId = resourceId;
    }

    public void UpdateBookingTime(DateTime startTime, DateTime endTime)
    {
        if(startTime <= endTime)
            throw new ArgumentException("StartTime cannot be later than EndTime", nameof(startTime));
        StartTime = startTime;
        EndTime = endTime;
    }
    public Booking() {}
}
