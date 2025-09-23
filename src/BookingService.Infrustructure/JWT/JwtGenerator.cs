using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookingService.Application.Interfaces.JWT;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BookingService.Infrastructure.JWT;

public class JwtGenerator: ITokenGenerator
{
    private readonly IOptions<AuthSettings> _authSettings;

    public JwtGenerator(IOptions<AuthSettings> authSettings)
    {
        _authSettings = authSettings;
    }

    public string GenerateToken(Domain.Entities.User user)
    {
        var claims = new List<Claim>()
        {
            new Claim("id", user.Id.ToString()),
            new Claim("userName", user.UserName),
            new Claim("role", user.Role.ToString())
        };
        var jwt = new JwtSecurityToken(
            expires: DateTime.UtcNow.Add(_authSettings.Value.Expires),
            claims: claims,
            signingCredentials: 
            new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_authSettings.Value.SecretKey)),
                SecurityAlgorithms.HmacSha256));
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}