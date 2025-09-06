using AutoMapper;
using BookingService.Application.DTOs;
using BookingService.Domain.Entities;

namespace BookingService.Application.Mappings;

public class ResourceProfile : Profile
{
    public ResourceProfile()
    {
        CreateMap<Resource, ResourceDto>()
            .ForMember(resource => resource.ResourceNumber,
                opt =>
                    opt.MapFrom(resourceDto => resourceDto.Id))
            .ReverseMap();
    }
}