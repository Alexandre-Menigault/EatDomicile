using EatDomicile.Core.Dtos;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services;
using EatDomicile.Core.Utils;

namespace EatDomicile.App;

public class MenuUser
{
    private UserDTO _userDto { get; set; }
    public MenuUser()
    {
        
    }
    
    public void Run()
    {
        var input = 0;
        do
        {
            Console.WriteLine("Menu User");
            Console.WriteLine("Que voulez-vous faire ?");
            Console.WriteLine("1. S'inscrire");
            Console.WriteLine("2. Se connecter (Non Implémenté)");
            Console.WriteLine("3. Commander (Non Implémenté)");
            Console.WriteLine("9. Quitter (Non Implémenté)");
            
            input = int.Parse(Console.ReadLine()!);
            
            switch (input)
            {
                case 1:
                    Inscription();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Choix invalide");
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
            
            user.FirstName = ConsoleUtils.ReadLineString("Quel est votre nom ? ");
            user.LastName = ConsoleUtils.ReadLineString("Quel est votre prénom");
            user.Email = ConsoleUtils.ReadLineString("Quel est votre email ? ");
            user.Phone = ConsoleUtils.ReadLineString("Quel est votre numéro de téléphone ? ");
            address.Street = ConsoleUtils.ReadLineString("Quel est votre adresse ? ");
            address.City = ConsoleUtils.ReadLineString("Quel est votre ville ? ");
            address.State = ConsoleUtils.ReadLineString("Quel est votre département ?");
            address.ZipCode = ConsoleUtils.ReadLineInt("Quel est votre code postal ? ");
            address.Country = ConsoleUtils.ReadLineString("Quel est votre pays ? ");
            user.Address = address;


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Retour au menu");
        }
        
        
        var userService = new UserService();

        var userAdded = userService.AddUser(user);
        Console.WriteLine("User ajouté");
        Console.WriteLine(userAdded.AsString());
    }
}