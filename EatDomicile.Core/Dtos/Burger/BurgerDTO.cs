using System.Text;
using EatDomicile.Core.Dtos.Ingredient;

namespace EatDomicile.Core.Dtos.Burger;

public class BurgerDTO : FoodDTO
{

    public List<IngredientDTO> Ingredients { get; set; } = new();
    public BurgerDTO()
    {
        
    }
    public BurgerDTO(string name, decimal price, bool vegetarien) : base(name, price, vegetarien)
    {
        
    }


    public static BurgerDTO FromEntity(Models.Burger burger)
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
    
    public static Models.Burger ToEntity(BurgerDTO burgerDTO)
    {
        return new Models.Burger()
        {
            Name = burgerDTO.Name,
            Price = burgerDTO.Price,
            Vegetarien = burgerDTO.Vegetarien,
            Ingredients = IngredientDTO.ToEntities(burgerDTO.Ingredients)
        };
    }
    
}
