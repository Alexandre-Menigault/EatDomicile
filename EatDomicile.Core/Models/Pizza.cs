using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatDomicile.Core.Models
{
    [Table("Pizzas")]
    public class Pizza
    {
        [Key]
        [Required]
        [ForeignKey("Id")]
        public required Food Food { get; set; }

        [Required]
        [StringLength(50)]
        public required Dough Dough { get; set; }


    }
}
