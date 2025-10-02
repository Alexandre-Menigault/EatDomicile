using EatDomicile.Core.Contexts;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EatDomicile.Core.Services;

public class UserService
{
    private readonly ProductContext _context;

    public UserService(ProductContext context)
    {
        _context = context;
    }

    public UserDTO AddUser(UserDTO dto)
    {

        User user = UserDTO.ToEntity(dto);
        
        _context.Users.Add(user);
        _context.SaveChanges();
        Console.WriteLine($"User created with {user.Id}");
        return UserDTO.FromEntity(user);
    }

    public UserDTO CreateUser(CreateUserDTO createUserDto)
    {
        var user = CreateUserDTO.ToEntity(createUserDto);
        _context.Users.Add(user);
        _context.SaveChanges();
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

    public void DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user is null)
            throw new Exception($"User {id} not found");
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}