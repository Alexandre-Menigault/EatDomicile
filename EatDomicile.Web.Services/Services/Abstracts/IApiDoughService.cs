using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services.Abstracts;

public interface IApiDoughService
{
    Task<IEnumerable<DoughDTO>> GetDoughsAsync();
    Task<DoughDTO> GetDough(int Id);
    Task CreateDoughAsync(DoughDTO doughDTO);

    Task DeleteDoughAsync(int Id);
    Task UpdateDoughAsync(int Id, DoughDTO doughDTO);
}
