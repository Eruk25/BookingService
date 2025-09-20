namespace BookingService.Application.Interfaces.PasswordHasher;

public interface IPassworHasher
{
    string HashPassword(string password);
    bool VerifyHashedPassword(string password, string hashedPassword);
}