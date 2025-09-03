using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class PizzaDTO : FoodDTO
{
    public DoughDTO Dough { get; set; }
    
    public PizzaDTO(string name, decimal price, bool vegetarien, DoughDTO dough): base(name, price, vegetarien)
    {
        this.Dough = dough;
    }

    public static PizzaDTO FromEntity(Pizza pizza)
    {
        return new PizzaDTO(
            pizza.Name,
            pizza.Price,
            pizza.Vegetarien,
            DoughDTO.FromEntity(pizza.Dough) 
        );
    } 
    
    public static Pizza ToEntity(PizzaDTO pizzaDTO)
    {
        return new Pizza()
        {
            Name = pizzaDTO.Name,
            Price = pizzaDTO.Price,
            Vegetarien = pizzaDTO.Vegetarien,
            Dough = DoughDTO.ToEntity(pizzaDTO.Dough)
        };
    }
}