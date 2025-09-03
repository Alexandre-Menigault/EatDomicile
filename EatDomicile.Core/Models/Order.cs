using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EatDomicile.Core.Enums;

namespace EatDomicile.Core.Models;

[Table("Orders")]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    
    public DateTime? DeliveryDate { get; set; }
    
    [Required]
    public OrderStatus Status { get; set; }

    [Required]
    public List<Product> Products { get; set; } = new();
    // TODO: ajouter l'utilisateur et l'adresse de livraison

}