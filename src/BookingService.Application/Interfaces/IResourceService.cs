using BookingService.Application.DTOs;

namespace BookingService.Application.Interfaces;

public interface IResourceService
{
    Task<IEnumerable<ResourceDto>> GetAllAsync();
    Task<ResourceDto> GetByIdAsync(int id);
    Task<ResourceDto> CreateAsync(ResourceDto resource);
    Task<bool> UpdateAsync(ResourceDto resource);
    Task<bool> DeleteAsync(int id);
}