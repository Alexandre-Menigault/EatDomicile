using EatDomicile.Core.Models;
using EatDomicile.Core.Services;

namespace EatDomicile.App;


public class MenuProduit
{
    public void Run()
    {
        var input = 0;
        do
        {
            Console.WriteLine("\n---Menu Produit ---");
            Console.WriteLine(" 1. Liste des ingrédients  ");
            Console.WriteLine(" 2. Ajouter des ingrédients ");
            Console.WriteLine(" 3. Quitter ");

        input = int.Parse(Console.ReadLine()!);
        switch (input)
        {
            case 1:
                ListeIngredients();
                break;
            case 2:
                AjouterIngredient();
                break;
            default:
                break;
        }
    }while (input != 3);
}
    private void ListeIngredients()
    {
        Console.WriteLine("\n---Liste des ingrédients ---");
        var ingredientService = new IngredientService();
        var ingredients = ingredientService.GetAllIngredients();
        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"Id: {ingredient.Id}, Nom: {ingredient.Name}, Kcal: {ingredient.Kcal}");
        }
    }

    private void AjouterIngredient()
    {
        Console.WriteLine("\n--- Ajouter un ingrédient ---");

        var service = new IngredientService();

        
        Console.Write(" Nom de l'ingrédient : ");
        string name = Console.ReadLine() ?? "";

        
        Console.Write(" Calories (kcal) : ");
        int kcal = int.Parse(Console.ReadLine() ?? "0");

        
        var ingredient = new Ingredient
        {
            Name = name.Trim(),
            Kcal = kcal
        };

     
        var saved = service.AddIngredient(ingredient);

        
        Console.WriteLine($"\n--- Ingrédient ajouté : #{saved.Id} - {saved.Name} ({saved.Kcal} kcal) ---");
    }
    
}

