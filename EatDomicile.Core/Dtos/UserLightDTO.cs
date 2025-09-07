using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class UserLightDTO
{
    public int Id { get; set; }
    public  string FirstName { get; set; }
    public  string LastName { get; set; }
    public  string Email { get; set; }
    public  string Phone { get; set; }
    public  int AddressId { get; set; }

    
    public UserLightDTO()
    {
        
    }
    
    public UserLightDTO(int id, string firstName, string lastName, string email, string phone, AddressDTO address)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Phone = phone;
        this.AddressId = address.Id;
    }

    public static UserLightDTO FromEntity(User user)
    {
        return new UserLightDTO(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Phone,
            AddressDTO.FromEntity(user.Address) 
        );
    }

    // public static User ToEntity(UserDTO dto)
    // {
    //     return new User
    //     {
    //         Id = dto.Id,
    //         FirstName = dto.FirstName,
    //         LastName = dto.LastName,
    //         Email = dto.Email,
    //         Phone = dto.Phone,
    //         Address = AddressDTO.ToEntity(dto.Address) 
    //     };
    // }
}

public static class UserLightDTOExtensions
{
    public static String AsString(this UserLightDTO user)
    {
        return $"<User> {user.FirstName} {user.LastName}" +
               $"\n\tAddressId: {user.AddressId}" +
               $"\n\t{user.Email}" +
               $"\n\t{user.Phone}";
    }
    
    public static String AsString(this List<UserLightDTO> users)
    {
        var sb = new StringBuilder();
        foreach (var user in users)
        {
            sb.AppendLine(user.AsString());
        }
        return sb.ToString();
    }
}