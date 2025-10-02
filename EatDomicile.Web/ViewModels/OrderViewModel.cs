using System.ComponentModel.DataAnnotations;

namespace EatDomicile.Web.ViewModels;

public class OrderViewModel
{
    public int Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Date de commande")]
    public DateTime OrderDate { get; set; }

    [Display(Name = "Date de livraison")]
    public DateTime? DeliveryDate { get; set; }

    [Required]
    [Display(Name = "Statut")]
    public string Status { get; set; } = string.Empty;


    [Required]
    [Display(Name = "Utilisateur")]
    public int UserId { get; set; }

    [Required]
    [Display(Name = "Adresse de livraison")]
    public string DeliveryAddress { get; set; } = string.Empty;


    [Display(Name = "Produits")]
    public List<int> SelectedProducts { get; set; } = new();

    [Display(Name = "Boissons")]
    public List<int> SelectedDrinks { get; set; } = new();

    public List<string>? Products { get; set; }

}
