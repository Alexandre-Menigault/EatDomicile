using EatDomicile.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatDomicile.Core.Models
{
    public class Pasta : AbstractKCal
    {
        [Key]
        [Required]
        [ForeignKey("Id")]
        public required Food Food { get; set; }

        [Required]
        [Column("Type")]
        public required PastaType Type{ get; set; }
    }
}
