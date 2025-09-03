using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class DrinkDTO : FoodDTO, IKCal
{
    public bool Fizzy { get; set; }
    public int KCal { get; set; }
    
    public DrinkDTO(string name, decimal price, bool vegetarien, bool fizzy, int kcal): base(name, price, vegetarien)
    {
        this.Fizzy = fizzy;
        this.KCal = kcal;
    }
}