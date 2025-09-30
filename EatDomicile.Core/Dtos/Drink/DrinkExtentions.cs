namespace EatDomicile.Core.Dtos.Drink;

public static class DrinkExtentions
{
    public static Models.Drink ToEntity(this CreateDrinkDto dto)
    {
        return new Models.Drink()
        {
            Name = dto.Name,
            Price = dto.Price,
            Fizzy = dto.Fizzy,
            KCal = dto.KCal,
        };
    }

    public static DrinkDTO ToDto(this Models.Drink drink)
    {
        return new DrinkDTO
        {
            Id = drink.Id,
            Name = drink.Name,
            Price = drink.Price,
            Fizzy = drink.Fizzy,
            KCal = drink.KCal,
        };
    }
}