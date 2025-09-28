using EatDomicile.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EatDomicile.App;

public class HostedService : IHostedService, IHostedLifecycleService
{
    private readonly IServiceProvider _serviceProvider;

    public HostedService(IHostApplicationLifetime appLifetime,
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        appLifetime.ApplicationStarted.Register(OnStarted);
    }

    private void OnStarted()
    {
        Console.WriteLine(" \n--- Bienvenue au programme EatDomicile ---");

        var input = 0;

        do
        {
            Console.WriteLine("\n--- Menu Principal: ---");
            Console.WriteLine(" 1. Admin");
            Console.WriteLine(" 2. Client ");
            Console.WriteLine(" 3. Quitter");
    
            input = int.Parse(Console.ReadLine()!);

            var userService = this._serviceProvider.GetRequiredService<UserService>();
            var orderService = this._serviceProvider.GetRequiredService<OrderService>();
            var ingredientService = this._serviceProvider.GetRequiredService<IngredientService>();
            var odderService = this._serviceProvider.GetRequiredService<OrderService>();
            switch (input)
            {
                case 1:
                    var adminMenu = new MenuAdmin(userService, orderService, ingredientService);
                    adminMenu.Run();
                    break;
                case 2:
                    var userMenu = new MenuUser(userService, odderService);
                    userMenu.Run();
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine(" Choix invalide ");
                    break;
            }
    
        } while (input != 3);


    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}