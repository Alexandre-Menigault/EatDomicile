namespace EatDomicile.Web.Services.Dtos;

public class BurgerDTO : FoodDTO
{

    public List<IngredientDTO> Ingredients { get; set; } = new();
    public BurgerDTO(string name, decimal price, bool vegetarien) : base(name, price, vegetarien)
    {
        
    }
    
}


public static class BurgerExtentions 
{
    public static String AsString(this BurgerDTO burger)
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"<Burger> {burger.Name} ({burger.Price}€)");
        sb.AppendLine("Ingredients:");
        foreach (var ingredient in burger.Ingredients)
        {
            sb.AppendLine($"\t- {ingredient.Name} ({ingredient.Kcal} Kcal, Allergene: {(ingredient.Allergene ? "Oui" : "Non")})");
        }
        return sb.ToString();
    }
}