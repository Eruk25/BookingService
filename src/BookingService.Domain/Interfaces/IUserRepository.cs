using BookingService.Domain.Entities;

namespace BookingService.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task<User> GetByEmailAsync(string email);
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}