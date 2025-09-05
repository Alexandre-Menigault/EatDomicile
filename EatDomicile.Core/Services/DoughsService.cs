
using EatDomicile.Core.Contexts;
using EatDomicile.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EatDomicile.Core.Services;

public class DoughsService
{
     public DoughsService()
    {

    }
    // Read all

    public List<Dough> GetAllDoughs()
    {
        using var context = new ProductContext();
        var doughsList = context.Doughs.ToList();
        return doughsList;
     }

    public Dough AddDough(Dough dough)
    {
        using var context = new ProductContext();
        context.Doughs.Add(dough);
        context.SaveChanges();
        return dough;
    }

    public void RemoveDough(Dough doughToRemove)
    {
        using var context = new ProductContext();
        var dough = context.Doughs.Find(doughToRemove.Id);
        context.Doughs.Remove(dough);
        context.SaveChanges();
    }

    public Dough GetDough(int id)
    {
        using var context = new ProductContext();
        var Dough = context.Doughs.Find(id);
        return Dough;
    }

    public Dough UpdateDough(Dough newDough)
    {
        using var context = new ProductContext();
        var dough = context.Doughs.Find(newDough.Id);
        dough.Name = newDough.Name;
        context.SaveChanges();
        return dough;
    }

}
