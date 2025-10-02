using EatDomicile.Core.Dtos.Ingredient;

namespace EatDomicile.Core.Services.Abstractions;

public interface IIngredientService
{
    Task<IEnumerable<IngredientDTO>> GetAllIngredients();
    Task<IngredientDTO> GetIngredientById(int id);
    Task<IngredientDTO> AddIngredient(CreateIngredientDto ingredientDto);
    Task UpdateIngredient(int id, CreateIngredientDto ingredientDto);
    Task DeleteIngredient(int id);

    Task<IEnumerable<IngredientDTO>> GetAllIngerdientsAllergene();
}