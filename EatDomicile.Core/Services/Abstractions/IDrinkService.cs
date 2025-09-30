using EatDomicile.Core.Dtos.Drink;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Services.Abstractions;

public interface IDrinkService
{
    public Task<DrinkDTO> AddDrink(CreateDrinkDto drinkDto);
    public Task<List<DrinkDTO>> GetAllDrinks();
    public Task<DrinkDTO> GetDrinkById(int id);

    public Task UpdateDrink(int id, CreateDrinkDto drink);

    public Task DeleteDrink(int id);
}