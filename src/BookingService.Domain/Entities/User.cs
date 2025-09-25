using BookingService.Domain.Enums;

namespace BookingService.Domain.Entities;

public class User
{
    public int Id { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public EnumRole Role { get; init; }
    public DateTime RegistrationDate { get; init; }
    public User() {}

    public static User Create(string userName, string email, string password)
    {
        if(string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("User name cannot be null or empty", nameof(userName));
        if(string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be null or empty", nameof(email));
        if(string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be null or empty", nameof(password));

        return new User
        {
            UserName = userName,
            Email = email,
            Password = password,
            Role = EnumRole.Client,
            RegistrationDate = DateTime.Now,
        };
    }
}
