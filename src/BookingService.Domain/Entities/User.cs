using BookingService.Domain.Enums;

namespace BookingService.Domain.Entities;

public class User
{
    public int Id { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public EnumRole Role { get; private set; }
    public DateTime RegistrationDate { get; private set; }
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

    public void UpdateUserName(string userName)
    {
        if(string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("User name cannot be null or empty", nameof(userName));
        UserName = userName;
    }

    public void UpdateEmail(string email)
    {
        if(string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be null or empty", nameof(email));
        Email = email;
    }

    public void UpdatePassword(string password)
    {
        if(string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be null or empty", nameof(password));
        Password = password;
    }
}
