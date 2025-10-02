using System.Net.Http;
using System.Net.Http.Json;
using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services.Abstracts;

namespace EatDomicile.Web.Services.Services;

public class OrdersService : IApiOrderService
{

    private readonly HttpClient _httpClient;

    // public OrdersService(HttpClient httpClient)
    public OrdersService(IHttpClientFactory httpClientFactory)
    {
    //     this._httpClient = httpClient;
    //
    //     this._httpClient.BaseAddress = new Uri("https://localhost:7151/api/orders");
        this._httpClient = httpClientFactory.CreateClient("orders");
    }

    public async Task DeleteOrderAsync(int Id)
    {
        var response = await this._httpClient.DeleteAsync($"{Id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<OrderDTO> GetOrder(int Id)
    {
        var order = await this._httpClient.GetFromJsonAsync<OrderDTO>($"{Id}");
        return order ?? null;
    }

    public async Task<IEnumerable<OrderDTO>> GetOrdersAsync()
    {
        var orders = await this._httpClient.GetFromJsonAsync<IEnumerable<OrderDTO>>(string.Empty);
        return orders ?? [];
    }

    public async Task UpdateOrderAsync(int Id, OrderDTO orderDTO)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{Id}", orderDTO);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task CreateOrderAsync(OrderDTO orderDTO)
    {
        var response = await this._httpClient.PostAsJsonAsync(string.Empty, orderDTO);
        _ = response.EnsureSuccessStatusCode();
    }
}