using EatDomicile.Core.Abstractions;
using EatDomicile.Core.Enums;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class PastaDTO: FoodDTO, IKCal
{
    public PastaType Type { get; set; }
    public int KCal { get; set; }
    
    public PastaDTO(string name, decimal price, bool vegetarien, PastaType type, int kcal): base(name, price, vegetarien)
    {
        this.Type = type;
        this.KCal = kcal;
    }

    public static PastaDTO FromEntity(Pasta pasta)
    {
        return new PastaDTO(
            pasta.Name, 
            pasta.Price,
            pasta.Vegetarien, 
            pasta.Type, 
            pasta.KCal
        );
    }
    
    public static Pasta ToEntity(PastaDTO pastaDTO)
    {
        return new Pasta()
        {
            Name = pastaDTO.Name,
            Price = pastaDTO.Price,
            Vegetarien = pastaDTO.Vegetarien,
            Type = pastaDTO.Type,
            KCal = pastaDTO.KCal
        };
    }
}