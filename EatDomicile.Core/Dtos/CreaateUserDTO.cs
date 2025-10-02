using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class CreateUserDTO
{
    public  string FirstName { get; set; }
    public  string LastName { get; set; }
    public  string Email { get; set; }
    public  string Phone { get; set; }
    public int AddressId { get; set; }

    
    public CreateUserDTO()
    {
        
    }
    
    public CreateUserDTO(int id, string firstName, string lastName, string email, string phone, int addressId)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Phone = phone;
        this.AddressId = addressId;
    }

    public static CreateUserDTO FromEntity(User user)
    {
        return new CreateUserDTO(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Phone,
            user.AddressId
        );
    }

    public static User ToEntity(CreateUserDTO dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            AddressId = dto.AddressId
        };
    }
}

public static class CreateUserDTOUserDTOExtensions
{
    public static String AsString(this CreateUserDTO user)
    {
        return $"<User> {user.FirstName} {user.LastName}" +
               $"\n\t{user.AddressId}" +
               $"\n\t{user.Email}" +
               $"\n\t{user.Phone}";
    }
    
    public static String AsString(this List<CreateUserDTO> users)
    {
        var sb = new StringBuilder();
        foreach (var user in users)
        {
            sb.AppendLine(user.AsString());
        }
        return sb.ToString();
    }
}