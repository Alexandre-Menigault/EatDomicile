using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services.Abstracts;

public interface IApiPizzaService
{
    Task<IEnumerable<PizzaDTO>> GetPizzasAsync();
    Task<PizzaDTO> GetPizza(int Id);
    Task CreatePizzaAsync(PizzaDTO pizzaDTO);

    Task DeletePizzaAsync(int Id);
    Task UpdatePizzaAsync(int Id, PizzaDTO pizzaDTO);
}
