using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services.Abstracts;

public interface IApiBurgerService
{
    Task<IEnumerable<BurgerDTO>> GetBurgersAsync();
    Task<BurgerDTO> GetBurger(int Id);
    Task CreateBurgerAsync(BurgerDTO burgerDTO);

    Task DeleteBurgerAsync(int Id);
    Task UpdateBurgerAsync(int Id, BurgerDTO burgerDTO);
}
