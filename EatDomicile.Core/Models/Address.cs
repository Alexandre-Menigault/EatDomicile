using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatDomicile.Core.Models;

[Table("Addresses")]
public class Address
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column("Street")]
    [MaxLength(200)]
    public required string Street { get; set; }

    [Required]
    [Column("City")]
    [MaxLength(100)]
    public required string City { get; set; }

    [Required]
    [Column("State")]
    [MaxLength(100)]
    public required string State { get; set; }

    [Required]
    [Column("ZipCode")]
    
    public required int ZipCode { get; set; }

    [Required]
    [Column("Country")]
    [MaxLength(100)]
    public required string Country { get; set; } 
    
    public List<User> Users { get; set; } = new();
}
