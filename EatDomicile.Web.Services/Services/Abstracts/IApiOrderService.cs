using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services.Abstracts;

public interface IApiOrderService
{

    Task<IEnumerable<OrderDTO>> GetOrdersAsync();
    Task<OrderDTO> GetOrder(int Id);
    Task CreateOrderAsync(OrderDTO orderDTO);

    Task DeleteOrderAsync(int Id);
    Task UpdateOrderAsync(int Id, OrderDTO orderDTO);
}
