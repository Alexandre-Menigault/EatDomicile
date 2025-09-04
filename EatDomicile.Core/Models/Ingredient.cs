using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatDomicile.Core.Models;

[Table("Ingredients")]
public class Ingredient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column("Name")]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    [Column("Kcal")]
    public int Kcal { get; set; }

    public Burger? Burger { get; set; } = null;
    public Pizza? Pizza { get; set; } = null;

}
