using EatDomicile.Web.Services.Services;
using EatDomicile.Web.Services.Services.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace EatDomicile.Web.Services.Extentions;

public static class ServiceCollectionExtensions
{
    public static void AddAPIServices(this IHostApplicationBuilder builder)
    {
        var uriApi = builder.Configuration.GetValue<string>("ApiSettings:BaseUrl");
        _ = builder.Services.AddHttpClient("orders", client => client.BaseAddress = new($"{uriApi}/api/orders/"));

        builder.Services.TryAddTransient<IApiOrderService, OrdersService>();

        _ = builder.Services.AddHttpClient("drinks", client => client.BaseAddress = new($"{uriApi}/api/drinks/"));

        builder.Services.TryAddTransient<IApiDrinkService, DrinksService>();

        _ = builder.Services.AddHttpClient("ingredients", client => client.BaseAddress = new($"{uriApi}/api/ingredients/"));

        builder.Services.TryAddTransient<IApiIngredientService, IngredientsService>();
       
        _ = builder.Services.AddHttpClient("users", client => client.BaseAddress = new($"{uriApi}/api/users/"));

        builder.Services.TryAddTransient<IApiUserService, UsersService>();
    }
}