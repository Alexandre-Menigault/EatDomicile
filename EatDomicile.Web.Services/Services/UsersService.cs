using System.Net.Http.Json;
using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services;

public class UsersService
{
    private readonly HttpClient _httpClient;

    // ✅ Liste statique pour mock persistant
    private static List<UsersDto> _mockUsers = new()
    {
        new UsersDto { Id = 1, FirstName = "Alice", LastName = "Dupont", Email = "alice@test.com", Phone = "0600000001", Address = "10 rue Victor Hugo, Tours" },
        new UsersDto { Id = 2, FirstName = "Bob", LastName = "Martin", Email = "bob@test.com", Phone = "0600000002", Address = "21 allée des acacias, Montlouis" }
    };

    public UsersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7151/api/users/");
    }

    public async Task<List<UsersDto>> GetUsers()
    {
        try
        {
            var users = await _httpClient.GetFromJsonAsync<List<UsersDto>>("");
            if (users != null && users.Count > 0) return users;
        }
        catch { }
        return _mockUsers;
    }

    public async Task<UsersDto?> GetUserByIdAsync(int id)
    {
        try { return await _httpClient.GetFromJsonAsync<UsersDto>($"{id}"); }
        catch { return _mockUsers.FirstOrDefault(u => u.Id == id); }
    }

    public async Task CreateUserAsync(UsersDto user)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("", user);
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            user.Id = _mockUsers.Count > 0 ? _mockUsers.Max(u => u.Id) + 1 : 1;
            _mockUsers.Add(user);
        }
    }

    public async Task UpdateUserAsync(UsersDto user)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{user.Id}", user);
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            var existing = _mockUsers.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                existing.FirstName = user.FirstName;
                existing.LastName = user.LastName;
                existing.Email = user.Email;
                existing.Phone = user.Phone;
                existing.Address = user.Address;
            }
        }
    }

    public async Task DeleteUserAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{id}");
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            _mockUsers.RemoveAll(u => u.Id == id);
        }
    }
}
