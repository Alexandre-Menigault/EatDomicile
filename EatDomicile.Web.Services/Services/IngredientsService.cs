using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services.Abstracts;
using System.Net.Http;
using System.Net.Http.Json;

namespace EatDomicile.Web.Services.Services;

public class IngredientsService : IApiIngredientService
{
    private readonly HttpClient _httpClient;

   // public IngredientsService(IHttpClientFactory httpClientFactory)
     public IngredientsService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
        this._httpClient.BaseAddress = new Uri("https://localhost:7151/api/ingredients");
        //this.httpClient = httpClientFactory.CreateClient("Ingredients");
    }

    public async Task DeleteIngredientAsync(int Id)
    {
        var response = await this._httpClient.DeleteAsync($"{Id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<IngredientDTO> GetIngredient(int Id)
    {
        var ingredient = await this._httpClient.GetFromJsonAsync<IngredientDTO>($"{Id}");
        return ingredient ?? null;
    }

    public async Task<IEnumerable<IngredientDTO>> GetIngredientsAsync()
    {
        var ingredients = await this._httpClient.GetFromJsonAsync<IEnumerable<IngredientDTO>>(string.Empty);
        return ingredients ?? [];
    }

    public async Task UpdateIngredientAsync(int Id, IngredientDTO ingredientDTO)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{Id}", ingredientDTO);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task CreateIngredientAsync(IngredientDTO ingredientDTO)
    {
        var response = await this._httpClient.PostAsJsonAsync(string.Empty, ingredientDTO);
        _ = response.EnsureSuccessStatusCode();
    }
}
