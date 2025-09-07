using EatDomicile.Core.Models;
using System.Text;

namespace EatDomicile.Core.Dtos;

public class BurgerDTO : FoodDTO
{

    public List<IngredientDTO> Ingredients { get; set; } = new();
    public BurgerDTO(string name, decimal price, bool vegetarien) : base(name, price, vegetarien)
    {
        
    }


    public static BurgerDTO FromEntity(Burger burger)
    {
        return new BurgerDTO(
            burger.Name,
            burger.Price,
            burger.Vegetarien
            
        )
        { 
            Ingredients = IngredientDTO.FromEntities(burger.Ingredients)
        }  ;
    }
    
    public static Burger ToEntity(BurgerDTO burgerDTO)
    {
        return new Burger()
        {
            Name = burgerDTO.Name,
            Price = burgerDTO.Price,
            Vegetarien = burgerDTO.Vegetarien,
            Ingredients = IngredientDTO.ToEntities(burgerDTO.Ingredients)
        };
    }
    
}


public static class BurgerExtentions 
{
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