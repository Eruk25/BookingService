using BookingService.Application.DTOs;
using BookingService.Application.DTOs.User;
using BookingService.Domain.Entities;

namespace BookingService.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(int id);
    Task<bool> RegisterAsync(RegisterUserDto userDto);
    Task<string> LoginAsync(string email, string password);
    Task LogoutAsync();
    Task UpdateAsync(UserDto bookingDto, string password);
    Task DeleteAsync(int id);
}