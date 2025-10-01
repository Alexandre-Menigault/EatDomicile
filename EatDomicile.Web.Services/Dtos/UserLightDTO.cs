
using System.Text;

namespace EatDomicile.Web.Services.Dtos;

public class UserLightDTO
{
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
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Phone = phone;
        this.AddressId = address.Id;
    }
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