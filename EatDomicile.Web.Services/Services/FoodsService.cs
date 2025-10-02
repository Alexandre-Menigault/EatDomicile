using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services.Abstracts;
using System.Net.Http.Json;

namespace EatDomicile.Web.Services.Services;

public class FoodsService: IApiFoodService
{

    private readonly HttpClient _httpClient;

    public FoodsService(HttpClient httpClient)
    //public FoodsService(IHttpClientFactory httpClientFactory)
    {
        this._httpClient = httpClient;

        this._httpClient.BaseAddress = new Uri("https://localhost:7151/api/foods");
        //this._httpClient = httpClientFactory.CreateClient("Foods");
    }

    public async Task DeleteFoodAsync(int Id)
    {
        var response = await this._httpClient.DeleteAsync($"{Id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<FoodDTO> GetFood(int Id)
    {
        var food = await this._httpClient.GetFromJsonAsync<FoodDTO>($"{Id}");
        return food ?? null;
    }

    public async Task<IEnumerable<FoodDTO>> GetFoodsAsync()
    {
        var foods = await this._httpClient.GetFromJsonAsync<IEnumerable<FoodDTO>>(string.Empty);
        return foods ?? [];
    }

    public async Task UpdateFoodAsync(int Id, FoodDTO foodDTO)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{Id}", foodDTO);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task CreateFoodAsync(FoodDTO foodDTO)
    {
        var response = await this._httpClient.PostAsJsonAsync(string.Empty, foodDTO);
        _ = response.EnsureSuccessStatusCode();
    }
}
