namespace BookingService.Application.Service.JWT;

public class AuthSettings
{
    public TimeSpan Expires { get; set; }
    public string SecretKey { get; set; }
}