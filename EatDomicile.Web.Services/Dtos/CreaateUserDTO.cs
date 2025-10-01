

using System.Text;

namespace EatDomicile.Web.Services.Dtos;

public class CreateUserDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
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