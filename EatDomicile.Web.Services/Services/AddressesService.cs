using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EatDomicile.Web.Services.Services;

public class AddressesService: IApiAddressService

{
    private readonly HttpClient _httpClient;


    // public IngredientsService(IHttpClientFactory httpClientFactory)
    public AddressesService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
        this._httpClient.BaseAddress = new Uri("https://localhost:7151/api/addresses");
        //this._httpClient = httpClientFactory.CreateClient("Addresses");
    }

    public async Task DeleteAddressAsync(int Id)
    {
        var response = await this._httpClient.DeleteAsync($"{Id}");
        _ = response.EnsureSuccessStatusCode();
    }

    public async Task<AddressDTO> GetAddress(int Id)
    {
        var Address = await this._httpClient.GetFromJsonAsync<AddressDTO>($"{Id}");
        return Address ?? null;
    }

    public async Task<IEnumerable<AddressDTO>> GetAddressesAsync()
    {
        var addresses = await this._httpClient.GetFromJsonAsync<IEnumerable<AddressDTO>>(string.Empty);
        return addresses ?? [];
    }

    public async Task UpdateAddressAsync(int Id, AddressDTO addressDTO)
    {
        var response = await this._httpClient.PutAsJsonAsync($"{Id}", addressDTO);
        _ = response.EnsureSuccessStatusCode();
    }
    public async Task CreateAddressAsync(AddressDTO addressDTO)
    {
        var response = await this._httpClient.PostAsJsonAsync(string.Empty, addressDTO);
        _ = response.EnsureSuccessStatusCode();
    }
}
