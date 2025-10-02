using EatDomicile.Web.Services.Enums;
using EatDomicile.Web.Services.Services.Abstracts;
namespace EatDomicile.Web.Services.Dtos;

public class PastaDTO: FoodDTO, IKCal
{
    public PastaType Type { get; set; }
    public int KCal { get; set; }
    
    public PastaDTO(string name, decimal price, bool vegetarien, PastaType type, int kcal): base(name, price, vegetarien)
    {
        this.Type = type;
        this.KCal = kcal;
    }
}