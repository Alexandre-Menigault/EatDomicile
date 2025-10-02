using EatDomicile.Core.Dtos.Burger;

namespace EatDomicile.Core.Services.Abstractions;

public interface IBurgerService
{
    Task<BurgerDTO> AddBurger(CreateBurgerDto burgerDto);
    Task<BurgerDTO> GetBurgerById(int id);
    Task<List<BurgerDTO>> GetAllBurgers();
    Task<BurgerDTO> UpdateBurger(int id, CreateBurgerDto burgerDto);
    Task DeleteBurger(int id);
}