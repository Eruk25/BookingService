using AutoMapper;
using BookingService.Application.DTOs;
using BookingService.Application.DTOs.User;
using BookingService.Application.Interfaces;
using BookingService.Domain.Interfaces;

namespace BookingService.Application.Service.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public Task<IEnumerable<UserDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RegisterAsync(RegisterUserDto userDto)
    {
        if(userDto is null)
            throw new ArgumentNullException(nameof(userDto));
        var createdUser = new Domain.Entities.User()
        {
            UserName = userDto.UserName,
            Email = userDto.Email,
            Password = userDto.Password,
        };
        
        return await _userRepository.CreateAsync(createdUser);
    }

    public Task LoginAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UserDto bookingDto, string password)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}