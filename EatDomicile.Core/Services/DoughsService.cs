
using EatDomicile.Core.Contexts;
using EatDomicile.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EatDomicile.Core.Services;

public class DoughsService
{
    private readonly ProductContext _context;


    public DoughsService(ProductContext context)
    {
        _context = context;
    }
    // Read all

    public List<Dough> GetAllDoughs()
    {
        var doughsList = _context.Doughs.ToList();
        return doughsList;
     }

    public Dough AddDough(Dough dough)
    {
        _context.Doughs.Add(dough);
        _context.SaveChanges();
        return dough;
    }

    public void RemoveDough(Dough doughToRemove)
    {
        var dough = _context.Doughs.Find(doughToRemove.Id);
        _context.Doughs.Remove(dough);
        _context.SaveChanges();
    }

    public Dough GetDough(int id)
    {
        var Dough = _context.Doughs.Find(id);
        return Dough;
    }

    public Dough UpdateDough(Dough newDough)
    {
        var dough = _context.Doughs.Find(newDough.Id);
        dough.Name = newDough.Name;
        _context.SaveChanges();
        return dough;
    }

}
