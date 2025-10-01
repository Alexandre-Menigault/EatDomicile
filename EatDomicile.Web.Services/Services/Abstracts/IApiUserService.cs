using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services.Abstracts;

public interface IApiUserService
{
    Task<IEnumerable<UserDTO>> GetUsersAsync();
    Task<UserDTO> GetUser(int Id);
    Task CreateUserAsync(UserDTO userDTO);

    Task DeleteUserAsync(int Id);
    Task UpdateUserAsync(int Id, UserDTO userDTO);

}
