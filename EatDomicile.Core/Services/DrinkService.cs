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
    private readonly ProductContext _context;


    public DrinkService(ProductContext context)
    {
        _context = context;
    }
    
    //CREATE

    public Drink AddDrink( Drink drink)
    {
        _context.Drinks.Add(drink);
        _context.SaveChanges();
        return drink;
    }

    //READ

    public List<Drink> GetAllDrinks()
    {
        var drinkList = _context.Drinks.ToList();
        return drinkList;
    }

    //UPDATE

    public Drink UpdateDrink(Drink drink)
    {
        _context.Drinks.Update(drink);
        _context.SaveChanges();
        return drink;
    }

    //DELETE

    public void DeleteDrink(int id)
    {
        var drink = _context.Drinks.Find(id);
        if (drink != null)
        {
            _context.Drinks.Remove(drink);
            _context.SaveChanges();
        }
    }
}
