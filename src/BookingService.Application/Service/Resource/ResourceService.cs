using AutoMapper;
using BookingService.Application.DTOs;
using BookingService.Application.Interfaces;
using BookingService.Domain.Interfaces;

namespace BookingService.Application.Service.Resource;

public class ResourceService : IResourceService
{
    private readonly IResourceRepository _resourceRepository;
    private readonly IMapper _mapper;

    public ResourceService(IResourceRepository resourceRepository, IMapper mapper)
    {
        _resourceRepository = resourceRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ResourceDto>> GetAllAsync()
    {
        var resources = await _resourceRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ResourceDto>>(resources);
    }

    public async Task<ResourceDto> GetByIdAsync(int id)
    {
        var resource = await _resourceRepository.GetByIdAsync(id);
        if(resource == null)
            throw new KeyNotFoundException($"Resource with id {id} not found");
        
        return _mapper.Map<ResourceDto>(resource);
    }

    public async Task<ResourceDto> CreateAsync(ResourceDto resource)
    {
        if(resource is null) 
            throw new ArgumentNullException(nameof(resource));
        var resourceEntity = _mapper.Map<Domain.Entities.Resource>(resource);
        await _resourceRepository.CreateAsync(resourceEntity);
        return _mapper.Map<ResourceDto>(resourceEntity);
    }

    public async Task<bool> UpdateAsync(ResourceDto resource)
    {
        if(resource is null)
            throw new ArgumentNullException(nameof(resource));
        var resourceEntity = _mapper.Map<Domain.Entities.Resource>(resource);
        return await _resourceRepository.UpdateAsync(resourceEntity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _resourceRepository.DeleteAsync(id);
    }
}