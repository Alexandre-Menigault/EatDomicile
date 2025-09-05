using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class UserDTO
{
    public int Id { get; set; }
    public  string FirstName { get; set; }
    public  string LastName { get; set; }
    public  string Email { get; set; }
    public  string Phone { get; set; }
    public  AddressDTO Address { get; set; }

    
    public UserDTO()
    {
        
    }
    
    public UserDTO(int id, string firstName, string lastName, string email, string phone, AddressDTO address)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Phone = phone;
        this.Address = address;
    }

    public static UserDTO FromEntity(User user)
    {
        return new UserDTO(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Phone,
            AddressDTO.FromEntity(user.Address) 
        );
    }

    public static User ToEntity(UserDTO dto)
    {
        return new User
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Address = AddressDTO.ToEntity(dto.Address) 
        };
    }
}

public static class UserDTOExtensions
{
    public static String AsString(this UserDTO user)
    {
        return $"<User> {user.Id}" +
               $"\n\t{user.FirstName} {user.LastName}" +
               $"\n\t{user.Address.AsString()}" +
               $"\n\t{user.Email}" +
               $"\n\t{user.Phone}";
    }
    
    public static String AsString(this List<UserDTO> users)
    {
        var sb = new StringBuilder();
        foreach (var user in users)
        {
            sb.AppendLine(user.AsString());
        }
        return sb.ToString();
    }
}