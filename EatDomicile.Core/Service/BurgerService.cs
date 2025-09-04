using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatDomicile.Core.Contexts;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Service;

internal class BurgerService
{
    //CREATE
    public Burger AddBurger( Burger burger)
    {   
        using var context = new ProductContext();        
        context.Burgers.Add(burger);
        context.SaveChanges();
        return burger;
    }

    //READ
    public List<Burger> GetAllBurgers()
    {
        using var context = new ProductContext();
        var burgerList = context.Burgers.ToList();
        return burgerList;
    }

    //UPDATE
    public Burger UpdateBurger(Burger burger)
    {
        using var context = new ProductContext();
        context.Burgers.Update(burger);
        context.SaveChanges();
        return burger;
    }

    //DELETE
    public void DeleteBurger(int id)
    {
        using var context = new ProductContext();
        var burger = context.Burgers.Find(id);
        if (burger != null)
        {
            context.Burgers.Remove(burger);
            context.SaveChanges();
        }
    }


}
