using EatDomicile.Core.Dtos;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services;
using EatDomicile.Core.Utils;

namespace EatDomicile.App;

public class MenuAdmin
{
    public MenuAdmin()
    {
        
    }

    public void Run()
    {
        var input = 0;
        do
        {
            Console.WriteLine("\n--- Menu Admin ---");
            Console.WriteLine("  Que voulez-vous faire ? ");
            Console.WriteLine("  1. Liste des utilisateurs ");
            Console.WriteLine("  2. Liste des commandes (Non Implémenté) ");
            Console.WriteLine("  3. Liste des produits ");
            Console.WriteLine("  9. Quitter ");
            
            input = int.Parse(Console.ReadLine()!);
            switch (input)
            {
                case 1:
                    ListeUtilisateurs();
                    break;
                case 3 : var produitMenu = new MenuProduit();
                    produitMenu.Run();
                    break;
               
                    break;
                    
                    break;
                default:
                    break;
            }
            
            
        } while (input != 9);
    }
    
    private void ListeUtilisateurs()
    {
        Console.WriteLine("\n--- Liste des utilisateurs ---");
        var userService = new UserService();
        var users = userService.GetAllUsers();

        Console.WriteLine(users.AsString());
    }

    

    
}