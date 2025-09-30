using System.ComponentModel.DataAnnotations;

namespace EatDomicile.Web.ViewModels;

public class IngredientViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom de l'ingrédient est requis.")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Calories (kcal)")]
    [Range(0, 2000, ErrorMessage = "Les calories doivent être comprise entre 0 et 2000.")]
    public int Kcal { get; set; }

    [Display(Name = "Allergène")]
    public bool Allergene { get; set; } = false;

}
