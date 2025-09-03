using EatDomicile.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatDomicile.Core.Models
{
    [Table("Pastas")]
    public class Pasta : Food, IKCal
    {
        [Required]
        [Column("Type")]
        public required PastaType Type{ get; set; }

        [Required]
        [Column("Kcal")]
        public int KCal { get ; set ; }
    }
}
