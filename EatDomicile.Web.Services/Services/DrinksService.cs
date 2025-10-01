using System.Net.Http.Json;
using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services;

public class DrinksService
{
    private readonly HttpClient _httpClient;

    private static List<DrinksDto> _mockDrinks = new()
    {
        new DrinksDto { Id = 1, Name = "Coca-Cola", Price = 2.5m, Fizzy = true, KCal = 140 },
        new DrinksDto { Id = 2, Name = "Pepsi", Price = 2.3m, Fizzy = true, KCal = 138 }
    };

    public DrinksService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7151/api/drinks/");
    }

    public async Task<List<DrinksDto>> GetDrinks()
    {
        try
        {
            var drinks = await _httpClient.GetFromJsonAsync<List<DrinksDto>>("");
            if (drinks != null && drinks.Count > 0) return drinks;
        }
        catch { }
        return _mockDrinks;
    }

    public async Task<DrinksDto?> GetDrinkByIdAsync(int id)
    {
        try { return await _httpClient.GetFromJsonAsync<DrinksDto>($"{id}"); }
        catch { return _mockDrinks.FirstOrDefault(d => d.Id == id); }
    }

    public async Task CreateDrinkAsync(DrinksDto drink)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("", drink);
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            drink.Id = _mockDrinks.Count > 0 ? _mockDrinks.Max(d => d.Id) + 1 : 1;
            _mockDrinks.Add(drink);
        }
    }

    public async Task UpdateDrinkAsync(DrinksDto drink)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{drink.Id}", drink);
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            var existing = _mockDrinks.FirstOrDefault(d => d.Id == drink.Id);
            if (existing != null)
            {
                existing.Name = drink.Name;
                existing.Price = drink.Price;
                existing.Fizzy = drink.Fizzy;
                existing.KCal = drink.KCal;
            }
        }
    }

    public async Task DeleteDrinkAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{id}");
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            _mockDrinks.RemoveAll(d => d.Id == id);
        }
    }
}
