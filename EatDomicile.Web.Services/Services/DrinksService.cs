using System.Net.Http.Json;
using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services
{
    public class DrinksService
    {
        private readonly HttpClient _httpClient;

        public DrinksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7151/api/drinks");
        }


        public async Task<List<DrinksDto>> GetDrinks()
        {

            var drinks = await _httpClient.GetFromJsonAsync<List<DrinksDto>>("");


            if (drinks == null || drinks.Count == 0)
            {
                drinks = new List<DrinksDto>
                {
                    new DrinksDto
                    {
                        Id = 1,
                        Name = "Coca-Cola",
                        Price = 2.5m,
                        Fizzy = true,
                        KCal = 140
                    },
                    new DrinksDto
                    {
                        Id = 2,
                        Name = "Pepsi",
                        Price = 2.3m,
                        Fizzy = true,
                        KCal = 138
                    }
                };
            }

            return drinks;
        }


        public async Task<DrinksDto?> GetDrinkByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<DrinksDto>($"{id}");
        }


        public async Task CreateDrinkAsync(DrinksDto drinkDto)
        {
            var response = await _httpClient.PostAsJsonAsync("", drinkDto);
            response.EnsureSuccessStatusCode();
        }


        public async Task UpdateDrinkAsync(DrinksDto drinkDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{drinkDto.Id}", drinkDto);
            response.EnsureSuccessStatusCode();
        }


        public async Task DeleteDrinkAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
