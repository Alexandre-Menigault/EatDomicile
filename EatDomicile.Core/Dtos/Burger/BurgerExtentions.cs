using System.Text;
using EatDomicile.Core.Dtos.Ingredient;

namespace EatDomicile.Core.Dtos.Burger;

public static class BurgerExtentions
{

    /// <summary>
    ///
    /// 
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>Returns the Burger entity from the DTO without the ingredients from the database</returns>
    public static Models.Burger ToEntity(this CreateBurgerDto dto)
    {
        return new Models.Burger()
        {
            Name = dto.Name,
            Price = dto.Price,
            Vegetarien = dto.Vegetarien,
        };
    }

    public static BurgerDTO ToDto(this Models.Burger burger)
    {
        return new BurgerDTO()
        {
            Id = burger.Id,
            Name = burger.Name,
            Price = burger.Price,
            Vegetarien = burger.Vegetarien,
            Ingredients = burger.Ingredients.Select(i => i.ToDto()).ToList()
        };
    }
    
    public static String AsString(this BurgerDTO burger)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"<Burger> {burger.Name} ({burger.Price}€)");
        sb.AppendLine("Ingredients:");
        foreach (var ingredient in burger.Ingredients)
        {
            sb.AppendLine($"\t- {ingredient.Name} ({ingredient.Kcal} Kcal, Allergene: {(ingredient.Allergene ? "Oui" : "Non")})");
        }
        return sb.ToString();
    }
}