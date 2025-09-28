using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EatDomicile.Core.Models;

[Table("Users")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [Column("FirstName")]
    [MaxLength(50)]
    public required string FirstName { get; set; }
    [Required]
    [Column("LastName")]
    [MaxLength(50)]
    public required string LastName { get; set; }
    
    [Required]
    [Column("Email")]
    [MaxLength(100)]
    public required string Email { get; set; }
    
    [Required]
    [Column("Phone")]
    [MaxLength(15)]
    public required string Phone { get; set; }

    [ForeignKey("Address")]
    public int AddressId { get; set; }

    [Required] 
    [DeleteBehavior(DeleteBehavior.ClientSetNull)]
    public Address Address { get; set; } = null!;
}
