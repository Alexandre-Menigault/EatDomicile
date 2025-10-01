using EatDomicile.Core.Dtos.Order;
using EatDomicile.Core.Enums;

namespace EatDomicile.Core.Services.Abstractions;

public interface IOrderService
{
    Task<List<OrderDTO>> GetAllOrders();
    Task<OrderDTO> GetOrderById(int id);
    Task<OrderDTO> CreateOrder(CreateOrderDto orderDto);
    Task UpdateOrderAddress(int orderId, int addressId);
    Task DeleteOrder(int id);
    Task UpdateOrderStatus(int orderId, OrderStatus status);
    Task<List<OrderDTO>> GetOrdersEnCours();
}