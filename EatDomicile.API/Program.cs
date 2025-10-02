using EatDomicile.Core.Contexts;
using EatDomicile.Core.Extentions;
using EatDomicile.Core.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ProductContext>(options =>
{
    var connexionString = builder.Configuration["Database:ConnectionString"];
    if(connexionString is null)
        throw new Exception("Connection string is null");
    options.UseSqlServer(connexionString);
});

builder.Services.AddCoreServices();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<ProductContext>().Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Theme = ScalarTheme.Purple;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();