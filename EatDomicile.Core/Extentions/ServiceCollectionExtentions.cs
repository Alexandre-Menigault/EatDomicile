using EatDomicile.Core.Services;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace EatDomicile.Core.Extentions;

public static class ServiceCollectionExtentions
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IAddressService, AddressService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IDrinkService, DrinkService>();
    }
}