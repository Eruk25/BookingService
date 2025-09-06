using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Persistance.Repositories;

public class ResourceRepository : IResourceRepository
{
    private readonly ApplicationContext _context;

    public ResourceRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Resource>> GetAllAsync()
    {
        return await _context.Resources.ToListAsync();
    }

    public async Task<Resource?> GetByIdAsync(int id)
    {
        return await _context.Resources.FindAsync(id);
    }

    public async Task CreateAsync(Resource resource)
    {
        await _context.Resources.AddAsync(resource);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Resource resource)
    {
        var entity = await _context.Resources.FindAsync(resource.Id);
        entity.Title = resource.Title;
        entity.Description = resource.Description;
        entity.PricePerHour = resource.PricePerHour;
        entity.ImageUrl = resource.ImageUrl;
        
        await _context.SaveChangesAsync();
    }

    public Task DeleteAsync(int id)
    {
        var entity = _context.Resources.Find(id);
        _context.Resources.Remove(entity);
        return _context.SaveChangesAsync();
    }
}