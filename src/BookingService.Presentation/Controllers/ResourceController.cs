using BookingService.Application.DTOs;
using BookingService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourcesController: ControllerBase
{
    private readonly IResourceService _resourceService;

    public ResourcesController(IResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResourceDto>>> GetAllAsync()
    {
        var resources = await _resourceService.GetAllAsync();
        return Ok(resources);
    }   

    [HttpGet("{id}", Name = "GetByIdAsync")]
    public async Task<ActionResult<ResourceDto>> GetByIdAsync(int id)
    {
        var resource = await _resourceService.GetByIdAsync(id);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<ActionResult<ResourceDto>> CreateAsync(ResourceDto resource)
    {
        var creatId = await _resourceService.CreateAsync(resource);
        return CreatedAtRoute("GetByIdAsync", new  { id = creatId }, creatId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> UpdateAsync(int id, ResourceDto resource)
    {
        var success = await _resourceService.UpdateAsync(resource);
        return Ok(success);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var success = await _resourceService.DeleteAsync(id);
        return Ok(success);
    }
}