using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatDomicile.Core.Contexts;
using EatDomicile.Core.Dtos.Drink;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EatDomicile.Core.Services;

public class DrinkService : IDrinkService
{
    private readonly ILogger<DrinkService> _logger;
    private readonly ProductContext _context;


    public DrinkService(ILogger<DrinkService> logger, ProductContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    //CREATE
    public async Task<DrinkDTO> AddDrink(CreateDrinkDto drinkDto)
    {
        if (DrinkExistsByName(drinkDto))
        {
            throw new EntityAlreadyExistsException<Drink>(nameof(drinkDto.Name), drinkDto.Name);
        }
        var drink = drinkDto.ToEntity();
        await _context.Drinks.AddAsync(drink);
        await _context.SaveChangesAsync();
        return drink.ToDto();
    }

    //READ

    public async Task<List<DrinkDTO>> GetAllDrinks()
    {
        var drinkList = await _context.Drinks.Select(d => d.ToDto()).ToListAsync();
        return drinkList;
    }

    public async Task<DrinkDTO> GetDrinkById(int id)
    {
        var drink = await _context.Drinks.FirstOrDefaultAsync(d => d.Id == id);

        if (drink is null)
        {
            _logger.LogInformation($"Drink not found with id: {id}");
            throw new EntityNotFoundException<Drink>(id);
        }
        
        return drink.ToDto();
    }

    //UPDATE

    public async Task UpdateDrink(int id, CreateDrinkDto drinkDto)
    {
        var drink = await _context.Drinks.FirstOrDefaultAsync(d => d.Id == id);
        if (drink is null)
        {
            throw new EntityNotFoundException<Drink>(id);
        }
        if (DrinkExistsByName(drinkDto))
        {
            throw new EntityAlreadyExistsException<Drink>(nameof(drinkDto.Name), drinkDto.Name);
        }
        
        drink.Name = drinkDto.Name.IsNullOrEmpty() ? drink.Name : drinkDto.Name;
        drink.Price = drinkDto.Price != drink.Price ? drinkDto.Price : drink.Price;
        drink.Fizzy = drinkDto.Fizzy != drink.Fizzy ? drinkDto.Fizzy : drink.Fizzy;
        drink.KCal = drinkDto.KCal != drink.KCal ? drinkDto.KCal : drink.KCal;
        
        _context.Drinks.Update(drink);
        await _context.SaveChangesAsync();
    }

    //DELETE

    public async Task DeleteDrink(int id)
    {
        var drink = await _context.Drinks.FindAsync(id);
        
        if (drink == null) throw new EntityNotFoundException<Drink>(id);
        
        _context.Drinks.Remove(drink);
        await _context.SaveChangesAsync();
    }

    private bool IsNullOrEquals(string? a, string b)
    {
        return a == null || a == b;
    }
    
    private bool DrinkExistsByName(CreateDrinkDto drinkDto)
    {
        return _context.Drinks.Any(d => d.Name == drinkDto.Name);
    }
}
