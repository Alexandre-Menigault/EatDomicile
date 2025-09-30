using EatDomicile.Core.Contexts;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Models;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EatDomicile.Core.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly ProductContext _context;
    private readonly IAddressService _addressService;

    public UserService(ILogger<UserService> logger, ProductContext context, IAddressService addressService)
    {
        _logger = logger;
        _context = context;
        _addressService = addressService;
    }

    public UserDTO AddUser(UserDTO dto)
    {

        User user = UserDTO.ToEntity(dto);
        
        _context.Users.Add(user);
        _context.SaveChanges();
        _logger.LogInformation($"User created with id: {user.Id}");
        return UserDTO.FromEntity(user);
    }

    public async Task<UserDTO> CreateUser(CreateUserDTO createUserDto)
    {
        var user = CreateUserDTO.ToEntity(createUserDto);
        if (!await _addressService.AddressExists(createUserDto.AddressId))
        {
            _logger.LogInformation($"Address not found with id: {user.AddressId}");
            throw new EntityNotFoundException<Address>(createUserDto.AddressId);
        }
        _context.Users.Add(user);
        _context.SaveChanges();
        _logger.LogInformation($"User created with id: {user.Id}");
        return UserDTO.FromEntity(user);
    }
    
    
    public List<UserDTO> GetAllUsers()
    {
        return _context.Users
            .Include(u => u.Address)
            .Select(UserDTO.FromEntity)
            .ToList();
    }

    public UserDTO? GetUser(int id)
    {
        return _context.Users
            .Include(u => u.Address)
            .Select(UserDTO.FromEntity)
            .FirstOrDefault(u => u.Id == id);
    }

    public async Task UpdateUser(int id, UserLightDTO user)
    {
        var userEntity = _context.Users.Find(id);
        if (userEntity is null)
        {
            _logger.LogInformation($"User not found with id: {id}");
            throw new EntityNotFoundException<User>(id);
        }
        userEntity.FirstName = user.FirstName.IsNullOrEmpty() ? userEntity.FirstName : user.FirstName;
        userEntity.LastName = user.LastName.IsNullOrEmpty()  ? userEntity.LastName : user.LastName;
        userEntity.Email = user.Email.IsNullOrEmpty() ? userEntity.Email : user.Email;
        userEntity.Phone = user.Phone.IsNullOrEmpty() ? userEntity.Phone : user.Phone;
        
        if (user.AddressId != userEntity.AddressId)
        {
            // Check if address exists in database before updating the user address
            // Crashes otherwise
            if (await _addressService.AddressExists(id))
            {
                userEntity.AddressId = user.AddressId == userEntity.AddressId ? user.AddressId : userEntity.AddressId;
            }
            else
            {
                _logger.LogInformation($"Address not found with id: {user.AddressId}");
                throw new EntityNotFoundException<Address>(user.AddressId);
            }
        }
        _context.SaveChanges();
        _logger.LogInformation($"User with id {id} was updated");
    }

    public void DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user is null)
            throw new EntityNotFoundException<User>(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}