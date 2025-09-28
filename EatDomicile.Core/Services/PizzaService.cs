using EatDomicile.Core.Contexts;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Services;

public class PizzaService
{
    private readonly ProductContext _context;

    public PizzaService(ProductContext context)
    {
        _context = context;
    }
    public List<Pizza> GetAllPizzas()
    {
        var PizzasList = _context.Pizzas.ToList();
        return PizzasList;
    }

    public Pizza AddPizza(Pizza pizza)
    {
        var existingDough = _context.Set<Dough>().Find(pizza.Dough.Id);
        if (existingDough != null)
        {
            pizza.Dough = existingDough;
        }
        _context.Pizzas.Add(pizza);
        _context.SaveChanges();
        return pizza;
    }


    public void RemovePizza(Pizza pizzaToRemove)
    {
        var pizza = _context.Pizzas.Find(pizzaToRemove.Id);
        _context.Pizzas.Remove(pizza);
        _context.SaveChanges();
    }

    public Pizza GetPizza(int id)
    {
        var pizza = _context.Pizzas.Find(id);
        return pizza;
    }

    public Pizza UpdatePizza(Pizza existingPizza, Dough newDough, string newName)
    {
        var pizza = _context.Pizzas.Find(existingPizza.Id);
        
        pizza.Dough = newDough;

        pizza.Name = newName;
        
        _context.SaveChanges();
        return pizza;
    }
}
