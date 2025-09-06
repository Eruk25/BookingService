using AutoMapper;
using BookingService.Application.DTOs;
using BookingService.Domain.Entities;

namespace BookingService.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}