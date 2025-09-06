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
            Console.WriteLine("  2. Liste des commandes en cours ");
            Console.WriteLine("  3. Liste des produits ");
            Console.WriteLine("  4. Liste des utilisateurs qui ont effectué une commande");
            Console.WriteLine("  5. Liste des commandes uniquement végétariennes");
            Console.WriteLine("  6. Liste des ingrédients allergènes");
            Console.WriteLine("  9. Quitter ");
            
            input = int.Parse(Console.ReadLine()!);
            switch (input)
            {
                case 1:
                    ListeUtilisateurs();
                    break;
                case 2:
                    ListeCommandesEnCours();
                    break;
                case 3 : 
                    var produitMenu = new MenuProduit();
                    produitMenu.Run();
                    break;
               case 4:
                   ListeUtilisateursCommandes();
                    break;
                case 5:
                    ListeCommandesVegetariennes();
                    break;
                case 6:
                    ListeIngredientsAllergene();
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

    private void ListeUtilisateursCommandes()
    {
        Console.WriteLine("\n--- Liste des utilisateurs qui ont commandé au moins une fois ---");

        var orderService = new OrderService();
        var users = orderService.GetUsersWithOrders();
        
        Console.WriteLine(users.AsString());
    }
    
    private void ListeCommandesVegetariennes()
    {
        Console.WriteLine("\n--- Liste des commandes uniquement végétariennes ---");
        var orderService = new OrderService();
        var orders = orderService.GetVegetarianOrders();
        Console.WriteLine(orders.AsString());
    }
    
    private void ListeCommandesEnCours()
    {
        Console.WriteLine("\n--- Liste des commandes en cours ---");
        var orderService = new OrderService();
        var orders = orderService.GetOrdersEnCours();
        Console.WriteLine(orders.AsString());
    }

    private void ListeIngredientsAllergene()
    {
        Console.WriteLine("\n--- Liste des ingrédients allergènes");
        var ingredientServce = new IngredientService();
        var ingredents = ingredientServce.GetAllIngerdientsAllergene();
        
        Console.WriteLine(ingredents.AsString());
        
    }
    
}