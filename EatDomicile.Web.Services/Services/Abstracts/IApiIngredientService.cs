using EatDomicile.Web.Services.Dtos;
namespace EatDomicile.Web.Services.Services.Abstracts;

public interface IApiIngredientService
{
    Task<IEnumerable<IngredientDTO>> GetIngredientsAsync();
    Task<IngredientDTO> GetIngredient(int Id);
    Task CreateIngredientAsync(IngredientDTO IngredientDTO);

    Task DeleteIngredientAsync(int Id);
    Task UpdateIngredientAsync(int Id, IngredientDTO IngredientDTO);
}
