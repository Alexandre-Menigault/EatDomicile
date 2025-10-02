using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class IngredientDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Kcal { get; set; }

    public bool Allergene { get; set; } = false;

    public BurgerDTO? Burger { get; set; } = null;
    
    public PizzaDTO? Pizza { get; set; } = null;

    public IngredientDTO(int id, string name, int kcal, bool allergene, BurgerDTO? burger = null, PizzaDTO? pizza = null)
    {
        this.Id = id;
        this.Name = name;
        this.Kcal = kcal;
        this.Allergene = allergene;
        this.Burger = burger;
        this.Pizza = pizza;
    }

    public static IngredientDTO FromEntity(Ingredient ingredient)
    {
        return new IngredientDTO(
            ingredient.Id,
            ingredient.Name,
            ingredient.Kcal,
            ingredient.Allergene,
            ingredient.Burger == null ? null : BurgerDTO.FromEntity(ingredient.Burger),
            ingredient.Pizza == null ? null : PizzaDTO.FromEntity(ingredient.Pizza)
        );
    }

    public static Ingredient ToEntity(IngredientDTO dto)
    {
        
        return new Ingredient
        {
            Id = dto.Id,
            Name = dto.Name,
            Kcal = dto.Kcal,
            Allergene = dto.Allergene,
            Burger = dto.Burger == null ? null : BurgerDTO.ToEntity(dto.Burger),
            Pizza = dto.Pizza == null ? null : PizzaDTO.ToEntity(dto.Pizza)
        };
    }
    
    public static List<IngredientDTO> FromEntities(List<Ingredient> ingredients)
    {
        return ingredients
            .Select(IngredientDTO.FromEntity)
            .ToList();
    }
    
    public static List<Ingredient> ToEntities(List<IngredientDTO> ingredients)
    {
        return ingredients
            .Select(IngredientDTO.ToEntity)
            .ToList();
    }
}

public static class IngredientExtensions
{
    public static String AsString(this IngredientDTO ingredient)
    {
        return $"<Ingredient> {ingredient.Name} {ingredient.Kcal} Kcal, Allergene = {(ingredient.Allergene ? "Oui" : "Non")}";
    }

    public static String AsString(this List<IngredientDTO> ingredients)
    {
        var sb = new StringBuilder();
        foreach (var ingredient in ingredients)
        {
            sb.AppendLine(ingredient.AsString());
        }
        return sb.ToString();
    }
}