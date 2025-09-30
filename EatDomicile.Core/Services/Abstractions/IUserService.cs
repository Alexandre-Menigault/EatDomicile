using EatDomicile.Core.Dtos;

namespace EatDomicile.Core.Services.Abstractions;

public interface IUserService
{
    public UserDTO AddUser(UserDTO dto);
    public Task<UserDTO> CreateUser(CreateUserDTO createUserDto);

    public List<UserDTO> GetAllUsers();

    public UserDTO? GetUser(int id);

    public Task UpdateUser(int id, UserLightDTO user);

    public void DeleteUser(int id);
}