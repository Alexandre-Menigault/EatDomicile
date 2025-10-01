using EatDomicile.Core.Dtos.Address;

namespace EatDomicile.Core.Dtos.User;

public static class UserExtentions
{
    public static UserDTO ToDto(this Models.User user)
    {
        return new UserDTO()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address.ToDto(),
            Email = user.Email,
            Phone = user.Phone,
        };
    }
}