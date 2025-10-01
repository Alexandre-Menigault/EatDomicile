using System.Text;

namespace EatDomicile.Web.Services.Dtos;

public class PizzaDTO : FoodDTO
{
    public DoughDTO Dough { get; set; }
    public List<IngredientDTO> Ingredients { get; set; } = new();
    
    public PizzaDTO(string name, decimal price, bool vegetarien, DoughDTO dough): base(name, price, vegetarien)
    {
        this.Dough = dough;
    }
}

public static class PizzaExtentions 
{
    public static String AsString(this PizzaDTO pizza)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"<Pizza> {pizza.Name} ({pizza.Price}€) - Dough: {pizza.Dough.Name}");
        sb.AppendLine("Ingredients:");
        foreach (var ingredient in pizza.Ingredients)
        {
            sb.AppendLine($"\t- {ingredient.Name} ({ingredient.Kcal} Kcal, Allergene: {(ingredient.Allergene ? "Oui" : "Non")})");
        }
        return sb.ToString();
    }
}