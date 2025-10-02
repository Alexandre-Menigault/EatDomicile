using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services.Abstracts;
using System.Net.Http.Json;

namespace EatDomicile.Web.Services.Services;

public class DoughsService : IApiDoughService
{
    private readonly HttpClient _httpClient;


    // public IngredientsService(IHttpClientFactory httpClientFactory)
    public DoughsService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
        this._httpClient.BaseAddress = new Uri("https://localhost:7151/api/doughs");
        //this._httpClient = httpClientFactory.CreateClient("Doughes");
    }

    public async Task DeleteDoughAsync(int Id)
    {
        var response = await this._httpClient.DeleteAsync($"{Id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<DoughDTO> GetDough(int Id)
    {
        var dough = await this._httpClient.GetFromJsonAsync<DoughDTO>($"{Id}");
        return dough ?? null;
    }

    public async Task<IEnumerable<DoughDTO>> GetDoughsAsync()
    {
        var doughs = await this._httpClient.GetFromJsonAsync<IEnumerable<DoughDTO>>(string.Empty);
        return doughs ?? [];
    }

    public async Task UpdateDoughAsync(int Id, DoughDTO doughDTO)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{Id}", doughDTO);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task CreateDoughAsync(DoughDTO doughDTO)
    {
        var response = await this._httpClient.PostAsJsonAsync(string.Empty, doughDTO);
        _ = response.EnsureSuccessStatusCode();
    }
}
