using BookingService.Application.DTOs;

namespace BookingService.Application.Interfaces;

public interface IResourceService
{
    Task<IEnumerable<ResourceDto>> GetAllAsync();
    Task<ResourceDto> GetByIdAsync(int id);
    Task AddAsync(ResourceDto resource);
    Task UpdateAsync(ResourceDto resource);
    Task DeleteAsync(int id);
}