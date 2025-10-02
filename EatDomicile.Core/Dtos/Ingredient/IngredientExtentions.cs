namespace EatDomicile.Core.Dtos.Ingredient;

public static class IngredientExtentions
{
    public static IngredientDTO ToDto(this Models.Ingredient ingredient)
    {
        return new IngredientDTO()
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Kcal = ingredient.Kcal,
            Allergene = ingredient.Allergene,
        };
    }

    public static Models.Ingredient ToEntity(this CreateIngredientDto dto)
    {
        return new Models.Ingredient()
        {
            Name = dto.Name,
            Kcal = dto.Kcal,
            Allergene = dto.Allergene,
        };
    }
}