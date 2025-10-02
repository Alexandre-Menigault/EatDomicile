using EatDomicile.Web.Services.Services;
using EatDomicile.Web.Services.Services.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace EatDomicile.Web.Services.Extentions;

public static class ServiceCollectionExtensions
{
    public static void AddAPIServices(this IServiceCollection services, IConfiguration configuration)
    {
        var uriApi = configuration.GetValue<string>("ApiSettings:BaseUrl");
        services.AddHttpClient("orders", client => client.BaseAddress = new($"{uriApi}/api/orders/"));

        services.TryAddTransient<OrdersService>();

        services.AddHttpClient("drinks", client => client.BaseAddress = new($"{uriApi}/api/drinks/"));

        services.TryAddTransient<DrinksService>();

        services.AddHttpClient("ingredients", client => client.BaseAddress = new($"{uriApi}/api/ingredients/"));

        services.TryAddTransient<IngredientsService>();
       
        services.AddHttpClient("users", client => client.BaseAddress = new($"{uriApi}/api/users/"));

        services.TryAddTransient<UsersService>();
    }
}