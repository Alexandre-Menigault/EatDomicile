using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services.Abstracts;

public interface IApiDrinkService
{
    Task<IEnumerable<DrinkDTO>> GetDrinksAsync();
    Task<DrinkDTO> GetDrink(int Id);
    Task CreateDrinkAsync(DrinkDTO drinkDTO);

    Task DeleteDrinkAsync(int Id);
    Task UpdateDrinkAsync(int Id, DrinkDTO drinkDTO);
}
