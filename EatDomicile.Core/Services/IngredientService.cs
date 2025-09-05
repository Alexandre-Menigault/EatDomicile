using EatDomicile.Core.Contexts;
using EatDomicile.Core.Models;
using EatDomicile.Core.Dtos;
using System;


namespace EatDomicile.Core.Services;

public class IngredientService
{


    public IngredientService ()
    {
        }
    // READ
    public List<Ingredient> GetAllIngredients()
    {
        using var context = new ProductContext();
        var IngredientList = context.Ingredients.ToList();
        return IngredientList;
    }



    // CREATE
    public IngredientDTO AddIngredient( Ingredient ingredient)
    {
        using var context = new ProductContext();
        context.Ingredients.Add(ingredient);
        context.SaveChanges();
        return IngredientDTO.FromEntity(ingredient);
    }

    // UPDATE
    public Ingredient UpdateIngredient(Ingredient ingredient)
    {
        using var context = new ProductContext();
        var existingIngredient = context.Ingredients.Find(ingredient.Id);
        context.Ingredients.Update(ingredient);
        context.SaveChanges();
        return ingredient;
    }

    // DELETE
    public void DeleteIngredient(int id)
    {
        using var context = new ProductContext();
        var ingredient = context.Ingredients.Find(id);
        if (ingredient != null)
        {
            context.Ingredients.Remove(ingredient);
            context.SaveChanges();
        }
    }
}
