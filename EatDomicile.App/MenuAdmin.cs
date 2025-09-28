using EatDomicile.Core.Dtos;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services;
using EatDomicile.Core.Utils;

namespace EatDomicile.App;

public class MenuAdmin
{
    private readonly UserService _userService;
    private readonly OrderService _orderService;
    private readonly IngredientService _ingredientService;

    public MenuAdmin(UserService userService, OrderService orderService, IngredientService ingredientService)
    {
        _userService = userService;
        _orderService = orderService;
        _ingredientService = ingredientService;
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
                    var produitMenu = new MenuProduit(_ingredientService);
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
        var users = _userService.GetAllUsers();

        Console.WriteLine(users.AsString());
    }

    private void ListeUtilisateursCommandes()
    {
        Console.WriteLine("\n--- Liste des utilisateurs qui ont commandé au moins une fois ---");

        var users = _orderService.GetUsersWithOrders();
        
        Console.WriteLine(users);
    }
    
    private void ListeCommandesVegetariennes()
    {
        Console.WriteLine("\n--- Liste des commandes uniquement végétariennes ---");
        var orders = _orderService.GetVegetarianOrders();
        Console.WriteLine(orders.AsString());
    }
    
    private void ListeCommandesEnCours()
    {
        Console.WriteLine("\n--- Liste des commandes en cours ---");
        var orders = _orderService.GetOrdersEnCours();
        Console.WriteLine(orders.AsString());
    }

    private void ListeIngredientsAllergene()
    {
        Console.WriteLine("\n--- Liste des ingrédients allergènes");
        var ingredents = _ingredientService.GetAllIngerdientsAllergene();
        
        Console.WriteLine(ingredents.AsString());
        
    }
    
}