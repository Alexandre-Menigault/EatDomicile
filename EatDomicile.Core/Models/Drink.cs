using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatDomicile.Core.Models;

[Table("Drinks")]
public class Drink : Product, IKCal
{
    [Required]
    public bool Fizzy { get; set; }
    [Required]
    public int KCal { get; set; }
    
}