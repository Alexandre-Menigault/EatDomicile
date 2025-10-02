namespace EatDomicile.Core.Dtos.Ingredient;

public class CreateIngredientDto
{
    public string Name { get; set; } = String.Empty;
    public int Kcal { get; set; }
    public bool Allergene { get; set; } = false;
}