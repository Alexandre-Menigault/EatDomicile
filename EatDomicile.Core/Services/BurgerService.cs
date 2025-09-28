using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatDomicile.Core.Contexts;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Services;

public  class BurgerService
{
    private readonly ProductContext _context;


    public BurgerService(ProductContext productContext)
    {
        _context = productContext;
    }
    
    //CREATE
    public Burger AddBurger( Burger burger)
    {   
        _context.Burgers.Add(burger);
        _context.SaveChanges();
        return burger;
    }

    //READ
    public List<Burger> GetAllBurgers()
    {
        var burgerList = _context.Burgers.ToList();
        return burgerList;
    }

    //UPDATE
    public Burger UpdateBurger(Burger burger)
    {
        _context.Burgers.Update(burger);
        _context.SaveChanges();
        return burger;
    }

    //DELETE
    public void DeleteBurger(int id)
    {
        var burger = _context.Burgers.Find(id);
        if (burger != null)
        {
            _context.Burgers.Remove(burger);
            _context.SaveChanges();
        }
    }


}
