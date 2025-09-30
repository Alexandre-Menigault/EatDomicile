using EatDomicile.Core.Contexts;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Dtos.Address;
using EatDomicile.Core.Enums;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services;
using EatDomicile.Core.Utils;
using Microsoft.EntityFrameworkCore;

namespace EatDomicile.App;

public class MenuUser
{
    private readonly UserService _userService;
    private readonly OrderService _orderService;

    public MenuUser(UserService userService, OrderService orderService)
    {
        _userService = userService;
        _orderService = orderService;
    }

    public void Run()
    {
        var input = 0;
        do
        {
            Console.WriteLine("\n--- Menu User ---");
            Console.WriteLine(" Que voulez-vous faire ? ");
            Console.WriteLine(" 1. S'inscrire ");
            Console.WriteLine(" 2. Se connecter (Non Implémenté) ");
            Console.WriteLine(" 3. Commander ");
            Console.WriteLine(" 9. Quitter (Non Implémenté) ");

            input = int.Parse(Console.ReadLine()!);

            switch (input)
            {
                case 1:
                    Inscription();
                    break;
                case 2:
                    break;
                case 3:
                    Commander();
                    break;
                default:
                    Console.WriteLine("\n--- Choix invalide ---");
                    break;
            }
        } while (input != 9);
    }

    private void Inscription()
    {
        UserDTO user = new UserDTO();
        AddressDTO address = new AddressDTO();
        Console.WriteLine("Inscription");
        try
        {
            user.FirstName = ConsoleUtils.ReadLineString(" Quel est votre nom ? ");
            user.LastName = ConsoleUtils.ReadLineString(" Quel est votre prénom ");
            user.Email = ConsoleUtils.ReadLineString(" Quel est votre email ? ");
            user.Phone = ConsoleUtils.ReadLineString(" Quel est votre numéro de téléphone ? ");
            address.Street = ConsoleUtils.ReadLineString(" Quel est votre adresse ? ");
            address.City = ConsoleUtils.ReadLineString(" Quel est votre ville ? ");
            address.State = ConsoleUtils.ReadLineString(" Quel est votre département ? ");
            address.ZipCode = ConsoleUtils.ReadLineInt(" Quel est votre code postal ? ");
            address.Country = ConsoleUtils.ReadLineString(" Quel est votre pays ? ");
            user.Address = address;


            var userAdded = _userService.AddUser(user);
            Console.WriteLine("\n--- User ajouté ---");
            Console.WriteLine(userAdded.AsString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("\n--- Retour au menu ---");
        }
    }

    private void Commander()
    {
        using var db = new ProductContext();


        Console.WriteLine("\n-- Passer une commande ---");
        // try
        // {
            var userId = ConsoleUtils.ReadLineInt("Quel est l'id de l'utilisateur ?");


            int productId = ConsoleUtils.ReadLineInt("Quel est l'Id du produit à commander ?");

            var produit = db.Products.Find(productId);
            if (produit is null)
                throw new Exception("Produit not found");

            var orderUser = db.Users
                .Where(u=> u.Id == userId)
                .Include(u => u.Address)
                .Select(UserDTO.FromEntity)
                .First();
            if (orderUser is null)
                throw new Exception("User not found");
            var address = db.Addresses.Find(orderUser.Address.Id);
            if(address is null)
                throw new Exception("Address not found");

            
            var order = new Order
            {
                UserId = orderUser.Id,
                DeliveryAddressId = address.Id,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Validee,
                Products = [produit!]
            };

            var orderDTO = OrderDTO.FromEntity(order);

            var create = _orderService.CreateOrder(orderDTO);
            Console.WriteLine($"Commande{create.Id} créée !");
        // }catch (Exception e)
        // {
        //     Console.WriteLine("Erreur lors de la commande");
        //     Console.WriteLine(e.Message);
        // }
    }
}