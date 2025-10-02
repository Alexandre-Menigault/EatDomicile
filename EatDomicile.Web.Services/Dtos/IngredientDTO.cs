
using System.Text;

namespace EatDomicile.Web.Services.Dtos;

public class IngredientDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Kcal { get; set; }

    public bool Allergene { get; set; } = false;

    public BurgerDTO? Burger { get; set; } = null;
    
    public PizzaDTO? Pizza { get; set; } = null;

    public IngredientDTO(int id, string name, int kcal, bool allergene, BurgerDTO? burger = null, PizzaDTO? pizza = null)
    {
        this.Id = id;
        this.Name = name;
        this.Kcal = kcal;
        this.Allergene = allergene;
        this.Burger = burger;
        this.Pizza = pizza;
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