using System.Net.Http.Json;
using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services.Abstracts;

namespace EatDomicile.Web.Services.Services;

public class DrinksService : IApiDrinkService
{
    private readonly HttpClient _httpClient;


    // public IngredientsService(IHttpClientFactory httpClientFactory)
    public DrinksService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
        this._httpClient.BaseAddress = new Uri("https://localhost:7151/api/drinks");
        //this._httpClient = httpClientFactory.CreateClient("Drinks");
    }

    public async Task<List<DrinkDTO>> GetDrinks()
    {
        //var Drinks = await _httpClient.GetFromJsonAsync<IEnumerable<DrinksDto>>("");
        var drinks = new List<DrinkDTO>()
        {
            new DrinkDTO(name:"Name", price:10, fizzy:false, kcal:10)
            {

            }
        };
        return drinks ?? [];
    }

    public async Task DeleteDrinkAsync(int Id)
    {
        var response = await this._httpClient.DeleteAsync($"{Id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<DrinkDTO> GetDrink(int Id)
    {
        var drink = await this._httpClient.GetFromJsonAsync<DrinkDTO>($"{Id}");
        return drink ?? null;
    }

    public async Task<IEnumerable<DrinkDTO>> GetDrinksAsync()
    {
        var drinks = await this._httpClient.GetFromJsonAsync<IEnumerable<DrinkDTO>>(string.Empty);
        return drinks ?? [];
    }

    public async Task UpdateDrinkAsync(int Id, DrinkDTO drinkDTO)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{Id}", drinkDTO);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task CreateDrinkAsync(DrinkDTO drinkDTO)
    {
        var response = await this._httpClient.PostAsJsonAsync(string.Empty, drinkDTO);
        _ = response.EnsureSuccessStatusCode();
    }
}