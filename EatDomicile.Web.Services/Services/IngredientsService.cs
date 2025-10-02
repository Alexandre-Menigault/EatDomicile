using System.Net.Http.Json;
using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services;

public class IngredientsService
{
    private readonly HttpClient _httpClient;

    private static List<IngredientsDto> _mockIngredients = new()
    {
        new IngredientsDto { Id = 1, Name = "Tomate", Kcal = 18, Allergene = false },
        new IngredientsDto { Id = 2, Name = "Fromage", Kcal = 300, Allergene = true }
    };

    public IngredientsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7151/api/ingredients/");
    }

    public async Task<List<IngredientsDto>> GetIngredients()
    {
        try
        {
            var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientsDto>>("");
            if (ingredients != null && ingredients.Count > 0) return ingredients;
        }
        catch { }
        return _mockIngredients;
    }

    public async Task<IngredientsDto?> GetIngredientByIdAsync(int id)
    {
        try { return await _httpClient.GetFromJsonAsync<IngredientsDto>($"{id}"); }
        catch { return _mockIngredients.FirstOrDefault(i => i.Id == id); }
    }

    public async Task CreateIngredientAsync(IngredientsDto ingredient)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("", ingredient);
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            ingredient.Id = _mockIngredients.Count > 0 ? _mockIngredients.Max(i => i.Id) + 1 : 1;
            _mockIngredients.Add(ingredient);
        }
    }

    public async Task UpdateIngredientAsync(IngredientsDto ingredient)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{ingredient.Id}", ingredient);
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            var existing = _mockIngredients.FirstOrDefault(i => i.Id == ingredient.Id);
            if (existing != null)
            {
                existing.Name = ingredient.Name;
                existing.Kcal = ingredient.Kcal;
                existing.Allergene = ingredient.Allergene;
            }
        }
    }

    public async Task DeleteIngredientAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{id}");
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            _mockIngredients.RemoveAll(i => i.Id == id);
        }
    }
}
