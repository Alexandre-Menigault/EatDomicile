using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatDomicile.Core.Contexts;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Services;

public class DrinkService
{
    //CREATE

    public Drink AddDrink( Drink drink)
    {   
        using var context = new ProductContext();        
        context.Drinks.Add(drink);
        context.SaveChanges();
        return drink;
    }

    //READ

    public List<Drink> GetAllDrinks()
    {
        using var context = new ProductContext();
        var drinkList = context.Drinks.ToList();
        return drinkList;
    }

    //UPDATE

    public Drink UpdateDrink(Drink drink)
    {
        using var context = new ProductContext();
        context.Drinks.Update(drink);
        context.SaveChanges();
        return drink;
    }

    //DELETE

    public void DeleteDrink(int id)
    {
        using var context = new ProductContext();
        var drink = context.Drinks.Find(id);
        if (drink != null)
        {
            context.Drinks.Remove(drink);
            context.SaveChanges();
        }
    }
}
