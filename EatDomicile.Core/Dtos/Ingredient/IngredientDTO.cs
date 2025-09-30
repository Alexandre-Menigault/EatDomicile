using System.Text;

namespace EatDomicile.Core.Dtos.Ingredient;

public class IngredientDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Kcal { get; set; }

    public bool Allergene { get; set; } = false;


    public IngredientDTO()
    {
        
    }

    public IngredientDTO(int id, string name, int kcal, bool allergene)
    {
        this.Id = id;
        this.Name = name;
        this.Kcal = kcal;
        this.Allergene = allergene;
    }

    public static IngredientDTO FromEntity(Models.Ingredient ingredient)
    {
        return new IngredientDTO(
            ingredient.Id,
            ingredient.Name,
            ingredient.Kcal,
            ingredient.Allergene
        );
    }

    public static Models.Ingredient ToEntity(IngredientDTO dto)
    {
        
        return new Models.Ingredient
        {
            Id = dto.Id,
            Name = dto.Name,
            Kcal = dto.Kcal,
            Allergene = dto.Allergene
        };
    }
    
    public static List<IngredientDTO> FromEntities(List<Models.Ingredient> ingredients)
    {
        return ingredients
            .Select(IngredientDTO.FromEntity)
            .ToList();
    }
    
    public static List<Models.Ingredient> ToEntities(List<IngredientDTO> ingredients)
    {
        return ingredients
            .Select(IngredientDTO.ToEntity)
            .ToList();
    }
}

public static class IngredientExtensions
{
    public static String AsString(this IngredientDTO ingredient)
    {
        return $"<Ingredient> {ingredient.Name} {ingredient.Kcal} Kcal, Allergene = {(ingredient.Allergene ? "Oui" : "Non")}";
    }

    public static String AsString(this List<IngredientDTO> ingredients)
    {
        var sb = new StringBuilder();
        foreach (var ingredient in ingredients)
        {
            sb.AppendLine(ingredient.AsString());
        }
        return sb.ToString();
    }
}