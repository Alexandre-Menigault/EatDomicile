using EatDomicile.Web.Services.Services.Abstracts;

namespace EatDomicile.Web.Services.Dtos;

public class DrinkDTO : ProductDTO, IKCal
{
    public bool Fizzy { get; set; }
    public int KCal { get; set; }
    
    public DrinkDTO(string name, decimal price, bool fizzy, int kcal): base(name, price)
    {
        this.Fizzy = fizzy;
        this.KCal = kcal;
    }
}