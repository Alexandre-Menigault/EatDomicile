
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
        var DoughsList = context.Doughs.ToList();
        return DoughsList;
        
    }

    public Dough AddDough(Dough Dough)
    {
        using var context = new ProductContext();
        context.Doughs.Add(Dough);
        context.SaveChanges();
        return Dough;
    }

}
