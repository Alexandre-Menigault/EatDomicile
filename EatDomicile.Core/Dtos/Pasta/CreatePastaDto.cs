using EatDomicile.Core.Abstractions;
using EatDomicile.Core.Enums;

namespace EatDomicile.Core.Dtos.Pasta;

public class CreatePastaDto: FoodDTO, IKCal
{
    public PastaType Type { get; set; }
    public int KCal { get; set; }
}