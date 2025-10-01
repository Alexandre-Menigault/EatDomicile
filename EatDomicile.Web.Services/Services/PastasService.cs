using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services.Abstracts;
using System.Net.Http.Json;

namespace EatDomicile.Web.Services.Services;

public class PastasService : IApiPastaService
{

    private readonly HttpClient _httpClient;

    public PastasService(HttpClient httpClient)
    //public PastasService(IHttpClientFactory httpClientFactory)
    {
        this._httpClient = httpClient;

        this._httpClient.BaseAddress = new Uri("https://localhost:7151/api/pastas");
        //this._httpClient = httpClientFactory.CreateClient("Pastas");
    }

    public async Task DeletePastaAsync(int Id)
    {
        var response = await this._httpClient.DeleteAsync($"{Id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<PastaDTO> GetPasta(int Id)
    {
        var pasta = await this._httpClient.GetFromJsonAsync<PastaDTO>($"{Id}");
        return pasta ?? null;
    }

    public async Task<IEnumerable<PastaDTO>> GetPastasAsync()
    {
        var pastas = await this._httpClient.GetFromJsonAsync<IEnumerable<PastaDTO>>(string.Empty);
        return pastas ?? [];
    }

    public async Task UpdatePastaAsync(int Id, PastaDTO pastaDTO)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{Id}", pastaDTO);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task CreatePastaAsync(PastaDTO pastaDTO)
    {
        var response = await this._httpClient.PostAsJsonAsync(string.Empty, pastaDTO);
        _ = response.EnsureSuccessStatusCode();
    }
}
