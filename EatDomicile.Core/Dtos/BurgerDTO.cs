using EatDomicile.Core.Models;

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