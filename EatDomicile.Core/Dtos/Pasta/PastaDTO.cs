using EatDomicile.Core.Abstractions;
using EatDomicile.Core.Enums;

namespace EatDomicile.Core.Dtos.Pasta;

public class PastaDTO: FoodDTO, IKCal
{
    public PastaType Type { get; set; }
    public int KCal { get; set; }

    public PastaDTO()
    {
        
    }
    
    public PastaDTO(string name, decimal price, bool vegetarien, PastaType type, int kcal): base(name, price, vegetarien)
    {
        this.Type = type;
        this.KCal = kcal;
    }

    public static PastaDTO FromEntity(Models.Pasta pasta)
    {
        return new PastaDTO(
            pasta.Name, 
            pasta.Price,
            pasta.Vegetarien, 
            pasta.Type, 
            pasta.KCal
        );
    }
    
    public static Models.Pasta ToEntity(PastaDTO pastaDTO)
    {
        return new Models.Pasta()
        {
            Name = pastaDTO.Name,
            Price = pastaDTO.Price,
            Vegetarien = pastaDTO.Vegetarien,
            Type = pastaDTO.Type,
            KCal = pastaDTO.KCal
        };
    }
}