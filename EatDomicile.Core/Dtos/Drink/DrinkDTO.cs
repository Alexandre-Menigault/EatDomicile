using EatDomicile.Core.Abstractions;
using EatDomicile.Core.Dtos.Product;

namespace EatDomicile.Core.Dtos.Drink;

public class DrinkDTO : ProductDTO, IKCal
{
    public bool Fizzy { get; set; }
    public int KCal { get; set; }

    public DrinkDTO() : base()
    {
        
    }
    
    public DrinkDTO(string name, decimal price, bool fizzy, int kcal): base(name, price)
    {
        this.Fizzy = fizzy;
        this.KCal = kcal;
    }

    public static DrinkDTO FromEntity(Models.Drink drink)
    {
        return new DrinkDTO(
            drink.Name,
            drink.Price,
            drink.Fizzy,
            drink.KCal
        );
    }

    public static Models.Drink ToEntity(DrinkDTO drink)
    {
        return new Models.Drink()
        {
            Id = drink.Id,
            Name = drink.Name,
            Price = drink.Price,
            Fizzy = drink.Fizzy,
            KCal = drink.KCal,
        };
    }
}