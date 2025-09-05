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

    [Required] public OrderStatus Status { get; set; } = OrderStatus.Validee;

    [Required]
    public List<Product>? Products { get; set; } = new();
    
    [Required]
    public User? User { get; set; }
    [Required]
    [Column("DeliveryAddressId")]
    public Address? DeliveryAddress { get; set; }

}