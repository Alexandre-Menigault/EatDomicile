using System.ComponentModel.DataAnnotations;
using EatDomicile.Core.Abstractions;
using EatDomicile.Core.Dtos.Product;

namespace EatDomicile.Core.Dtos.Drink;

public class CreateDrinkDto : CreateProductDto, IKCal
{
    [Required]
    public bool Fizzy { get; set; }
    [Required]
    public int KCal { get; set; }
}