using BookingService.Application.Interfaces.PasswordHasher;

namespace BookingService.Infrastructure.Security;

public class PasswordHasher :  IPassworHasher
{
    private readonly Identity.PasswordHasher.PasswordHasher _hasher = new();
    public string HashPassword(string password)
    {
        return _hasher.HashPassword(password);
    }

    public bool VerifyHashedPassword(string password, string hashedPassword)
    {
        return _hasher.VerifyHashedPassword(hashedPassword, password);
    }
}