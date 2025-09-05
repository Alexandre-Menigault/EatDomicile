// See https://aka.ms/new-console-template for more information

using EatDomicile.App;
using EatDomicile.Core.Contexts;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Enums;
using EatDomicile.Core.Migrations;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

// Console.WriteLine("Bienvenue au programme EatDomicile");

// Console.WriteLine("======== Test =========");

// Address address = new Address()
// {
//     City = "Orléans",
//     Country = "France",
//     State = "Centre Val de Loire",
//     Street = "1 avenue de Paris",
//     ZipCode = 45000
// };
//
// User user = new User()
// {
//     Address = address,
//     Email = "me@example.com",
//     FirstName = "Jeane",
//     LastName = "Doe",
//     Phone = "0112233455"
// };

// Dough dough = new Dough()
// {
//     Name = "Thick"
// };

// List<Ingredient> ingredients =
// [
//     new Ingredient()
//     {
//         Name = "Steak",
//         Kcal = 1000,
//     },
//
//     new Ingredient()
//     {
//         Name = "Salade",
//         Kcal = 2,
//     },
// ];
//
// Burger burger = new Burger()
// {
//     Name = "Végétarienne",
//     Price = 10,
//     Vegetarien = false,
//     Ingredients = ingredients
// };
//
// Order orderModel = new Order()
// {
//     OrderDate = DateTime.Now,
//     User = user,
//     DeliveryAddress = address,
//     Products = [burger]
// };

// OrderService korderService = new OrderService();
// orderService.CreateOrder(orderModel);

// var orders = orderService.GetOrdersEnCours();
//
// Console.WriteLine(orders.AsString());
//
// var usersWithOrders = orderService.GetUsersWithOrders();
//
// Console.WriteLine(usersWithOrders.AsString());

// var order = orderService.GetOrderById(1);



// orderService.UpdateOrderEnCuisine(order!.Id);
// Console.WriteLine(order.AsString());
//
//
// orderService.UpdateOrderEnLivraison(order!.Id);
// order = orderService.GetOrderById(1);
// Console.WriteLine(order!.AsString());
//
// orderService.UpdateOrderLivree(order!.Id);
// order = orderService.GetOrderById(1);
// Console.WriteLine(order!.AsString());
//
// orderService.DeleteOrder(order!.Id);
// order = orderService.GetOrderById(1);
// if (order is null)
// {
//     Console.WriteLine("Order should not be null");   
// }

// Console.WriteLine("======== Fin Test =========");

Console.WriteLine(" \n--- Bienvenue au programme EatDomicile ---");

var input = 0;

do
{
    Console.WriteLine("\n--- Menu Principal: ---");
    Console.WriteLine(" 1. Admin");
    Console.WriteLine(" 2. Client ");
    Console.WriteLine(" 3. Quitter");
    
    input = int.Parse(Console.ReadLine()!);

    switch (input)
    {
        case 1:
            var adminMenu = new MenuAdmin();
            adminMenu.Run();
            break;
        case 2:
            var userMenu = new MenuUser();
            userMenu.Run();
            break;
        case 3:
            break;
        default:
            Console.WriteLine(" Choix invalide ");
            break;
    }
    
} while (input != 3);

