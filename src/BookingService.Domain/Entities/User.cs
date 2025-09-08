using BookingService.Domain.Enums;

namespace BookingService.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public EnumRole Role { get; set; }
    public DateTime RegistrationDate { get; set; }

    public User(string userName, string email, string password, EnumRole role)
    {
        if(string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("User name cannot be null or empty", nameof(userName));
        if(string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be null or empty", nameof(email));
        if(string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be null or empty", nameof(password));
        UserName = userName;
        Email = email;
        Password = password;
        Role = role;
        RegistrationDate = DateTime.UtcNow;
    }
    protected User() {}
}
