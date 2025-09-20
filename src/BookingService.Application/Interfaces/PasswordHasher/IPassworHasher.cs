namespace BookingService.Application.Interfaces.PasswordHasher;

public interface IPassworHasher
{
    string HashPassword(string password);
    string VerifyHashedPassword(string password, string hashedPassword);
}