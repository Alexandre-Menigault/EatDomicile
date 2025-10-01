using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services.Abstracts;

using System.Net.Http.Json;

namespace EatDomicile.Web.Services.Services;

public class UsersService: IApiUserService
{
    private readonly HttpClient _httpClient;
    
    // public UsersService(IHttpClientFactory httpClientFactory)
    public UsersService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
        this._httpClient.BaseAddress = new Uri("https://localhost:7151/api/users");

        //this._httpClient = httpClientFactory.CreateClient("Users");
    }

    public async Task<List<UserDTO>> GetUsers()
    {
        //var users = await _httpClient.GetFromJsonAsync<IEnumerable<UsersDto>>("");
        var users = new List<UserDTO>()
        {
            new UserDTO()
            {
                Id = 1,
                FirstName = "Firstname",
                LastName = "Lastname",
                Email = "e@email.com",
                Phone = "1234567890",
               // AddressId = 1,
            }
        };
        return users ?? [];
    }

    public async Task DeleteUserAsync(int Id)
    {
        var response = await this._httpClient.DeleteAsync($"{Id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<UserDTO> GetUser(int Id)
    {
        var user = await this._httpClient.GetFromJsonAsync<UserDTO>($"{Id}");
        return user ?? null;
    }

    public async Task<IEnumerable<UserDTO>> GetUsersAsync()
    {
        var books = await this._httpClient.GetFromJsonAsync<IEnumerable<UserDTO>>(string.Empty);
        return books ?? [];
    }

    public async Task UpdateUserAsync(int Id, UserDTO UserDTO)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{Id}", UserDTO);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task CreateUserAsync(UserDTO userDTO)
    {
        var response = await this._httpClient.PostAsJsonAsync(string.Empty, userDTO);
        _ = response.EnsureSuccessStatusCode();
    }
}
