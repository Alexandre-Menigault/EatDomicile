using System.Net.Http.Json;
using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services;

public class OrdersService
{
    private readonly HttpClient _httpClient;


    private static List<OrdersDto> _mockOrders = new()
    {
        new OrdersDto { Id = 1, UserId = 1, OrderDate = DateTime.Now.AddDays(-2), DeliveryDate = DateTime.Now.AddDays(-1), Status = "Livrée", DeliveryAddress = "12 rue de Paris", Products = new List<string> { "Ingredient:1", "Drink:1" } },
        new OrdersDto { Id = 2, UserId = 2, OrderDate = DateTime.Now.AddDays(-1), DeliveryDate = null, Status = "En préparation", DeliveryAddress = "45 avenue Victor Hugo", Products = new List<string> { "Ingredient:2" } }
    };

    public OrdersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7151/api/orders/");
    }


    public async Task<List<OrdersDto>> GetOrders()
    {
        try
        {
            var orders = await _httpClient.GetFromJsonAsync<List<OrdersDto>>("");
            if (orders != null && orders.Count > 0)
                return orders;
        }
        catch
        {

        }

        return _mockOrders;
    }


    public async Task<OrdersDto?> GetOrderByIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<OrdersDto>($"{id}");
        }
        catch
        {
            return _mockOrders.FirstOrDefault(o => o.Id == id);
        }
    }


    public async Task CreateOrderAsync(OrdersDto orderDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("", orderDto);
            response.EnsureSuccessStatusCode();
        }
        catch
        {

            orderDto.Id = _mockOrders.Any() ? _mockOrders.Max(o => o.Id) + 1 : 1;
            _mockOrders.Add(orderDto);
            Console.WriteLine($"[MOCK] Commande ajoutée : Id={orderDto.Id}, UserId={orderDto.UserId}, Status={orderDto.Status}");
        }
    }


    public async Task UpdateOrderAsync(OrdersDto orderDto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{orderDto.Id}", orderDto);
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            var existing = _mockOrders.FirstOrDefault(o => o.Id == orderDto.Id);
            if (existing != null)
            {
                existing.UserId = orderDto.UserId;
                existing.OrderDate = orderDto.OrderDate;
                existing.DeliveryDate = orderDto.DeliveryDate;
                existing.Status = orderDto.Status;
                existing.DeliveryAddress = orderDto.DeliveryAddress;
                existing.Products = orderDto.Products;
                Console.WriteLine($"[MOCK] Commande modifiée : Id={orderDto.Id}");
            }
        }
    }


    public async Task DeleteOrderAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{id}");
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            var order = _mockOrders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _mockOrders.Remove(order);
                Console.WriteLine($"[MOCK] Commande supprimée : Id={id}");
            }
        }
    }
}
