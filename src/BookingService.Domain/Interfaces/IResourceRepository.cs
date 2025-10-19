using BookingService.Domain.Entities;

namespace BookingService.Domain.Interfaces;

public interface IResourceRepository
{
    Task<IEnumerable<Resource>> GetAllAsync();
    Task<Resource?> GetByIdAsync(int id);
    Task CreateAsync(Resource resource);
    Task ImportDataAsync(IEnumerable<Resource> resources);
    Task<bool> UpdateAsync(Resource resource);
    Task<bool> DeleteAsync(int id);
}