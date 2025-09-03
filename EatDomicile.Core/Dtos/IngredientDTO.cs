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

    public IngredientDTO(int id, string name, int kcal)
    {
        this.Id = id;
        this.Name = name;
        this.Kcal = kcal;
    }

    public static IngredientDTO FromEntity(Ingredient ingredient)
    {
        return new IngredientDTO(
            ingredient.Id,
            ingredient.Name,
            ingredient.Kcal
        );
    }

    public static Ingredient ToEntity(IngredientDTO dto)
    {
        
        return new Ingredient
        {
            Id = dto.Id,
            Name = dto.Name,
            Kcal = dto.Kcal,
            
        };
    }
}
