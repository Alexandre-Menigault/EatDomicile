using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatDomicile.Core.Models
{
    [Table("Foods")]
    public abstract class Food: Products
    {
        [Required]
        [DefaultValue(false)]
        public bool Vegetarien { get; set; } = false;
    }
}
