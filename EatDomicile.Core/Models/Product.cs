using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EatDomicile.Core.Models
{
    [Table("Products")]
    public abstract class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Name")]
        public required string Name { get; set; }
        
        [Required]
        [Column("Price", TypeName = "decimal(10,2)")]
        public required decimal Price { get; set; }
        
    }
}
