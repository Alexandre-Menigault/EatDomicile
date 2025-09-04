// See https://aka.ms/new-console-template for more information

using EatDomicile.Core.Contexts;
using EatDomicile.Core.Enums;
using EatDomicile.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using EatDomicile.Core.Service;
using EatDomicile.Core.Services;


Console.WriteLine("Hello, World!");

var service = new IngredientService();
var ing = service.AddIngredient(new Ingredient { Name = "Tomato", Kcal = 20 });
Console.WriteLine($"Ingredient {ing.Name} ajouté !");





// Pasta p = new Pasta()
// {
//     KCal = 100,
//     Name = "Spaghetti",
//     Price = 10,
//     Type = PastaType.Spaghetti,
//     Vegetarien = true 
// };

// Dough dough = new Dough()
// {
//     Name = "Fine"
// };
//
// Pizza piz = new Pizza()
// {
//     Name = "Reine",
//     Vegetarien = false, 
//     Dough = dough
// };
//
// var productsContext = new ProductContext();
//
// productsContext.Pastas.Add(p);
// productsContext.Pizzas.Add(piz);
// productsContext.SaveChanges();