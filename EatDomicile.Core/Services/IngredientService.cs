using EatDomicile.Core.Contexts;
using EatDomicile.Core.Models;
using EatDomicile.Core.Dtos;
using System;


namespace EatDomicile.Core.Services;

public class IngredientService
{
    private readonly ProductContext _context;


    public IngredientService(ProductContext context)
    {
        _context = context;
    }
    
    // READ
    public List<Ingredient> GetAllIngredients()
    {
        var IngredientList = _context.Ingredients.ToList();
        return IngredientList;
    }



    // CREATE
    public IngredientDTO AddIngredient( Ingredient ingredient)
    {
        _context.Ingredients.Add(ingredient);
        _context.SaveChanges();
        return IngredientDTO.FromEntity(ingredient);
    }

    // UPDATE
    public Ingredient UpdateIngredient(Ingredient ingredient)
    {
        var existingIngredient = _context.Ingredients.Find(ingredient.Id);
        _context.Ingredients.Update(ingredient);
        _context.SaveChanges();
        return ingredient;
    }

    // DELETE
    public void DeleteIngredient(int id)
    {
        var ingredient = _context.Ingredients.Find(id);
        if (ingredient != null)
        {
            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();
        }
    }

    public List<IngredientDTO> GetAllIngerdientsAllergene()
    {
        var ingredientList = _context.Ingredients
            .Where(i => i.Allergene)
            .Select(IngredientDTO.FromEntity)
            .ToList();
        
        return ingredientList;
    }
}
