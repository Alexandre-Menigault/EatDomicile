using EatDomicile.Core.Contexts;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Services;

public class PizzaService
{
    public PizzaService() { }
    public List<Pizza> GetAllPizzas()
    {
        using var context = new ProductContext();
        var PizzasList = context.Pizzas.ToList();
        return PizzasList;
    }

    public Pizza AddPizza(Pizza pizza)
    {
        using var context = new ProductContext();
        var existingDough = context.Set<Dough>().Find(pizza.Dough.Id);
        if (existingDough != null)
        {
            pizza.Dough = existingDough;
        }
        context.Pizzas.Add(pizza);
        context.SaveChanges();
        return pizza;
    }


    public void RemovePizza(Pizza pizzaToRemove)
    {
        using var context = new ProductContext();
        var pizza = context.Pizzas.Find(pizzaToRemove.Id);
        context.Pizzas.Remove(pizza);
        context.SaveChanges();
    }

    public Pizza GetPizza(int id)
    {
        using var context = new ProductContext();
        var pizza = context.Pizzas.Find(id);
        return pizza;
    }

    public Pizza UpdatePizza(Pizza existingPizza, Dough newDough, string newName)
    {
        using var context = new ProductContext();
        var pizza = context.Pizzas.Find(existingPizza.Id);
        
           pizza.Dough = newDough;

            pizza.Name = newName;
        
        context.SaveChanges();
        return pizza;
    }
}
