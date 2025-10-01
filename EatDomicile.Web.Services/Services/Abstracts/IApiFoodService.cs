using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services.Abstracts;

public interface IApiFoodService
{
    Task<IEnumerable<FoodDTO>> GetFoodsAsync();
    Task<FoodDTO> GetFood(int Id);
    Task CreateFoodAsync(FoodDTO foodDTO);

    Task DeleteFoodAsync(int Id);
    Task UpdateFoodAsync(int Id, FoodDTO foodDTO);
}
