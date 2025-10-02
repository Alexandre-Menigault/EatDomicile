namespace EatDomicile.Core.Dtos.Burger;

public class CreateBurgerDto : FoodDTO
{
    public IEnumerable<int> Ingredients { get; set; } = new List<int>();
}