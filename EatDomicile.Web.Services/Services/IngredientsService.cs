using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services;

public class IngredientsService
{
    private readonly HttpClient _httpClient;

    public IngredientsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7151/api/ingredients");
    }

    public async Task<List<IngredientsDto>> GetIngredients()
    {
        // TODO : appel réel à l’API
        var ingredients = new List<IngredientsDto>
        {
            new IngredientsDto
            {
                Id = 1,
                Name = "Tomate",
                Kcal = 18,
                Allergene = false
            }
        };
        return ingredients ?? [];
    }
}
