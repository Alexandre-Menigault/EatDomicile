using EatDomicile.Web.Services.Dtos;


namespace EatDomicile.Web.Services.Services;

public class UsersService
{
    private readonly HttpClient _httpClient;

    public UsersService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
        this._httpClient.BaseAddress = new Uri("https://localhost:7151/api/users");
    }

    public async Task<List<UsersDto>> GetUsers()
    {
        //var users = await _httpClient.GetFromJsonAsync<IEnumerable<UsersDto>>("");
        var users = new List<UsersDto>()
        {
            new UsersDto()
            {
                Id = 1,
                FirstName = "Firstname",
                LastName = "Lastname",
                Email = "e@email.com",
                Phone = "1234567890",
                AddressId = 1,
            }
        };
        return users ?? [];
    }

}
