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

    public BurgerDTO? Burger { get; set; } = null;
    
    public PizzaDTO? Pizza { get; set; } = null;

    public IngredientDTO(int id, string name, int kcal, BurgerDTO? burger = null, PizzaDTO? pizza = null)
    {
        this.Id = id;
        this.Name = name;
        this.Kcal = kcal;
        this.Burger = burger;
        this.Pizza = pizza;
    }

    public static IngredientDTO FromEntity(Ingredient ingredient)
    {
        return new IngredientDTO(
            ingredient.Id,
            ingredient.Name,
            ingredient.Kcal,
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
