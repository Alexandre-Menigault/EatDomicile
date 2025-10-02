using EatDomicile.Core.Abstractions;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class DrinkDTO : ProductDTO, IKCal
{
    public bool Fizzy { get; set; }
    public int KCal { get; set; }
    
    public DrinkDTO(string name, decimal price, bool fizzy, int kcal): base(name, price)
    {
        this.Fizzy = fizzy;
        this.KCal = kcal;
    }

    public static DrinkDTO FromEntity(Drink drink)
    {
        return new DrinkDTO(
            drink.Name,
            drink.Price,
            drink.Fizzy,
            drink.KCal
        );
    }

    public static Drink ToEntity(DrinkDTO drink)
    {
        return new Drink()
        {
            Id = drink.Id,
            Name = drink.Name,
            Price = drink.Price,
            Fizzy = drink.Fizzy,
            KCal = drink.KCal,
        };
    }
}