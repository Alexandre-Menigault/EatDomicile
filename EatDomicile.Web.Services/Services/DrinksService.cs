using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services;

public class DrinksService
{
    private readonly HttpClient _httpClient;

    public DrinksService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7151/api/drinks");
    }

    public async Task<List<DrinksDto>> GetDrinks()
    {
        // TODO : appel réel à l’API
        var drinks = new List<DrinksDto>
        {
            new DrinksDto
            {
                Id = 1,
                Name = "Coca-Cola",
                Price = 2.5m,
                Fizzy = true,
                KCal = 140
            }
        };
        return drinks ?? [];
    }
}
