using System.ComponentModel.DataAnnotations;

namespace EatDomicile.Web.ViewModels;

public class DrinkViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom est obligatoire")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Prix (€)")]
    [Range(0.1, 200, ErrorMessage = "Le prix doit être positif")]
    public decimal Price { get; set; }

    [Display(Name = "Gazeuse ?")]
    public bool Fizzy { get; set; }

    [Display(Name = "Calories (kCal)")]
    [Range(0, 2000)]
    public int KCal { get; set; }

}
