using System.ComponentModel.DataAnnotations;

namespace EatDomicile.Web.ViewModels;

public class OrderViewModel
{
    public int Id { get; set; }

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
    public int DeliveryAddressId { get; set; }


    public List<string> Products { get; set; } = new();

}
