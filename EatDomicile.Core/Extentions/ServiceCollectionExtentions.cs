using EatDomicile.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EatDomicile.Core.Extentions;

public static class ServiceCollectionExtentions
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<UserService>();
        services.AddTransient<AddressService>();
    }
}