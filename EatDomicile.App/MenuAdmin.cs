using EatDomicile.Core.Dtos;
using EatDomicile.Core.Services;

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
            Console.WriteLine("Menu Admin");
            Console.WriteLine("Que voulez-vous faire ?");
            Console.WriteLine("1. Liste des utilisateurs");
            Console.WriteLine("2. Liste des commandes (Non Implémenté)");
            Console.WriteLine("3. Liste des produits (Non Implémenté)");
            Console.WriteLine("4. Ajouter des ingrédients (Non Implémenté)");
            Console.WriteLine("9. Quitter");
            
            input = int.Parse(Console.ReadLine()!);
            switch (input)
            {
                case 1:
                    ListeUtilisateurs();
                    break;
                default:
                    break;
            }
            
            
        } while (input != 9);
    }
    
    private void ListeUtilisateurs()
    {
        Console.WriteLine("Liste des utilisateurs");
        var userService = new UserService();
        var users = userService.GetAllUsers();

        Console.WriteLine(users.AsString());
    }
}