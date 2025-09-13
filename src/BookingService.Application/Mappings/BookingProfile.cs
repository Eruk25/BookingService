using AutoMapper;
using BookingService.Application.DTOs;
using BookingService.Domain.Entities;

namespace BookingService.Application.Mappings;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<Booking, BookingDto>()
            .ForMember(dto => dto.BookingNumber,
                opt =>
                    opt.MapFrom(booking => booking.Id))
            .ForMember(dto => dto.Resource,
                opt =>
                    opt.MapFrom(booking => booking.Resource))
            .ForMember(dto => dto.StartDate, 
                opt =>
                    opt.MapFrom(booking => booking.StartTime))
            .ForMember(dto => dto.EndDate,
                opt =>
                    opt.MapFrom(booking => booking.EndTime))
            .ReverseMap();

    }
}