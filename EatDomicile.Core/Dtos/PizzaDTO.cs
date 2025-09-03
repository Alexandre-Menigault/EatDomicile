using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class PizzaDTO : FoodDTO
{
    public DoughDTO Dough { get; set; }
    
    public PizzaDTO(string name, bool vegetarien, DoughDTO dough): base(name, vegetarien)
    {
        this.Dough = dough;
    }

    public static PizzaDTO FromEntity(Pizza pizza)
    {
        return new PizzaDTO(
            pizza.Name,
            pizza.Vegetarien,
            DoughDTO.FromEntity(pizza.Dough) 
        );
    } 
    
    public static Pizza ToEntity(PizzaDTO pizzaDTO)
    {
        return new Pizza()
        {
            Name = pizzaDTO.Name,
            Vegetarien = pizzaDTO.Vegetarien,
            Dough = DoughDTO.ToEntity(pizzaDTO.Dough)
        };
    }
}