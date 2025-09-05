using EatDomicile.Core.Contexts;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EatDomicile.Core.Services;

public class UserService
{
    public UserService()
    {
        
    }

    public UserDTO AddUser(UserDTO dto)
    {
        using var context = new ProductContext();

        User user = UserDTO.ToEntity(dto);
        
        context.Users.Add(user);
        context.SaveChanges();
        Console.WriteLine($"User created with {user.Id}");
        return UserDTO.FromEntity(user);
    }
    
    
    public List<UserDTO> GetAllUsers()
    {
        using var context = new ProductContext();
        return context.Users
            .Include(u => u.Address)
            .Select(UserDTO.FromEntity)
            .ToList();
    }
}