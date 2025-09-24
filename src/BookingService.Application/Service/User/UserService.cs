using AutoMapper;
using BookingService.Application.DTOs;
using BookingService.Application.DTOs.User;
using BookingService.Application.Interfaces;
using BookingService.Application.Interfaces.JWT;
using BookingService.Application.Interfaces.PasswordHasher;
using BookingService.Domain.Interfaces;

namespace BookingService.Application.Service.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPassworHasher  _passwordHasher;
    private readonly ITokenGenerator _tokenGenerator;
    public UserService(IUserRepository userRepository, IMapper mapper,
        IPassworHasher passwordHasher, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _tokenGenerator = tokenGenerator;
    }
    
    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users =  await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var user =  await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new KeyNotFoundException($"User with id {id} not found");
        return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> RegisterAsync(RegisterUserDto userDto)
    {
        if(userDto is null)
            throw new ArgumentNullException(nameof(userDto));
        var createdUser = new Domain.Entities.User()
        {
            UserName = userDto.UserName,
            Email = userDto.Email,
            Password = _passwordHasher.HashPassword(userDto.Password),
        };
        
        return await _userRepository.CreateAsync(createdUser);
    }

    public async Task<string> LoginAsync(LoginUserDto userDto)
    {
        var user = await _userRepository.GetByEmailAsync(userDto.Email);
        if(user == null)
            throw new ArgumentNullException(nameof(user));
        var success = _passwordHasher.VerifyHashedPassword(userDto.Password, user.Password);
        if (!success)
        {
            throw new Exception("Invalid password or Email");
        }
        else
        {
            return _tokenGenerator.GenerateToken(user);
        }
    }
    
    public async Task UpdateAsync(UserDto userDto, string password)
    {
        var user = await _userRepository.GetByEmailAsync(userDto.Email);
        if(user == null)
            throw new KeyNotFoundException($"User with email {userDto.Email} not found");
        var success =  _passwordHasher.VerifyHashedPassword(password, user.Password);
        if (!success)
        {
            throw new Exception("Invalid password");
        }
        else
        {
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            user.Password = _passwordHasher.HashPassword(password);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if(user == null)
            throw new KeyNotFoundException($"User with id {id} not found");
        await _userRepository.DeleteAsync(id);
    }
}