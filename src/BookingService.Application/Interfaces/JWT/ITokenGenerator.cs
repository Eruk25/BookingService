using BookingService.Domain.Entities;

namespace BookingService.Application.Interfaces.JWT;

public interface ITokenGenerator
{
    string GenerateToken(User user);
}