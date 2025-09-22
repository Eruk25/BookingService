using BookingService.Domain.Entities;

namespace BookingService.Application.Interfaces.JWT;

public interface IJwtService
{
    string GenerateJwtToken(User user);
}