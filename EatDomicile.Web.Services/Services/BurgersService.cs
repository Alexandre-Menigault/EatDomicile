using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services.Abstracts;
using System.Net.Http.Json;

namespace EatDomicile.Web.Services.Services;

public class BurgersService : IApiBurgerService
{

    private readonly HttpClient _httpClient;

    public BurgersService(HttpClient httpClient)
    //public BurgersService(IHttpClientFactory httpClientFactory)
    {
        this._httpClient = httpClient;

        this._httpClient.BaseAddress = new Uri("https://localhost:7151/api/burgers");
        //this._httpClient = httpClientFactory.CreateClient("Burgers");
    }

    public async Task DeleteBurgerAsync(int Id)
    {
        var response = await this._httpClient.DeleteAsync($"{Id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<BurgerDTO> GetBurger(int Id)
    {
        var burger = await this._httpClient.GetFromJsonAsync<BurgerDTO>($"{Id}");
        return burger ?? null;
    }

    public async Task<IEnumerable<BurgerDTO>> GetBurgersAsync()
    {
        var burgers = await this._httpClient.GetFromJsonAsync<IEnumerable<BurgerDTO>>(string.Empty);
        return burgers ?? [];
    }

    public async Task UpdateBurgerAsync(int Id, BurgerDTO burgerDTO)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{Id}", burgerDTO);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task CreateBurgerAsync(BurgerDTO burgerDTO)
    {
        var response = await this._httpClient.PostAsJsonAsync(string.Empty, burgerDTO);
        _ = response.EnsureSuccessStatusCode();
    }
}
