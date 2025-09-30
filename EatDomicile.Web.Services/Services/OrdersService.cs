using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services;

public class OrdersService
{
    private readonly HttpClient _httpClient;

    public OrdersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7151/api/orders");
    }

    public async Task<List<OrdersDto>> GetOrders()
    {
        // TODO : appel réel à l’API
        var orders = new List<OrdersDto>
        {
            new OrdersDto
            {
                Id = 1,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(1),
                Status = "En cours",
                UserId = 1,
                DeliveryAddressId = 1
            }
        };
        return orders ?? new List<OrdersDto>();
    }
}
