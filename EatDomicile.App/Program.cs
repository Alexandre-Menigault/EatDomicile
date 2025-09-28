// See https://aka.ms/new-console-template for more information

using EatDomicile.App;
using EatDomicile.Core.Contexts;
using EatDomicile.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddDbContext<ProductContext>(options =>
{
    var connectionString = builder.Configuration["Database:ConnectionString"];
    if(connectionString is null)
        throw new Exception("Connection string is null");
    options.UseSqlServer(connectionString);
},  ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddTransient<BurgerService>();
builder.Services.AddTransient<DoughsService>();
builder.Services.AddTransient<DrinkService>();
builder.Services.AddTransient<IngredientService>();
builder.Services.AddTransient<OrderService>();
builder.Services.AddTransient<PizzaService>();
builder.Services.AddTransient<UserService>();


builder.Services.AddHostedService<HostedService>();

IHost host = builder.Build();

host.Services.GetRequiredService<ProductContext>().Database.EnsureCreated();


host.Run();

