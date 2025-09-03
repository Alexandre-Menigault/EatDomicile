using System.ComponentModel.DataAnnotations.Schema;

namespace EatDomicile.Core.Models;

[Table("Burgers")]
public class Burger : Food
{
    public List<Ingredient> Ingredients { get; set; } = new();
}