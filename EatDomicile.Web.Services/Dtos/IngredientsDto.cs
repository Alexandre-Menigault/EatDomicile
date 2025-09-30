using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatDomicile.Web.Services.Dtos;

public class IngredientsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int Kcal { get; set; }

    public bool Allergene { get; set; } = false;
}
