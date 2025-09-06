using BookingService.Domain.Entities;

namespace BookingService.Domain.Interfaces;

public interface IResourceRepository
{
    Task<IEnumerable<Resource>> GetAllAsync();
    Task<Resource> GetByIdAsync(int id);
    Task CreateAsync(Resource resource);
    Task UpdateAsync(Resource resource);
    Task DeleteAsync(int id);
}