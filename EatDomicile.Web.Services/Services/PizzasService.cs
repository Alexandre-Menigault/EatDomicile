using EatDomicile.Web.Services.Dtos;
using System.Net.Http.Json;

namespace EatDomicile.Web.Services.Services;

public class PizzasService
{

    private readonly HttpClient _httpClient;

    public PizzasService(HttpClient httpClient)
    //public PizzasService(IHttpClientFactory httpClientFactory)
    {
        this._httpClient = httpClient;

        this._httpClient.BaseAddress = new Uri("https://localhost:7151/api/pizzas");
        //this._httpClient = httpClientFactory.CreateClient("Pizzas");
    }

    public async Task DeletePizzaAsync(int Id)
    {
        var response = await this._httpClient.DeleteAsync($"{Id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<PizzaDTO> GetPizza(int Id)
    {
        var pizza = await this._httpClient.GetFromJsonAsync<PizzaDTO>($"{Id}");
        return pizza ?? null;
    }

    public async Task<IEnumerable<PizzaDTO>> GetPizzasAsync()
    {
        var pizzas = await this._httpClient.GetFromJsonAsync<IEnumerable<PizzaDTO>>(string.Empty);
        return pizzas ?? [];
    }

    public async Task UpdatePizzaAsync(int Id, PizzaDTO pizzaDTO)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{Id}", pizzaDTO);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task CreatePizzaAsync(PizzaDTO pizzaDTO)
    {
        var response = await this._httpClient.PostAsJsonAsync(string.Empty, pizzaDTO);
        _ = response.EnsureSuccessStatusCode();
    }
}
