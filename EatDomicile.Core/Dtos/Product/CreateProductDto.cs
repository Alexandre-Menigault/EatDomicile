using System.ComponentModel.DataAnnotations;

namespace EatDomicile.Core.Dtos.Product;

public class CreateProductDto
{
    [Required]
    public String Name { get; set; }
    [Required]
    public decimal Price { get; set; }
}