using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatDomicile.Core.Contexts;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Dtos.Burger;
using EatDomicile.Core.Dtos.Ingredient;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EatDomicile.Core.Services;

public class BurgerService : IBurgerService
{
    private readonly ILogger<BurgerService> _logger;
    private readonly ProductContext _context;


    public BurgerService(ILogger<BurgerService> logger, ProductContext productContext)
    {
        _logger = logger;
        _context = productContext;
    }
    
    //CREATE
    public async Task<BurgerDTO> AddBurger(CreateBurgerDto burgerDto)
    {

        if (burgerDto.Ingredients.IsNullOrEmpty())
        {
            throw new EntityCollectionPropertyIsEmptyException<CreateBurgerDto>(nameof(burgerDto.Ingredients));
        }
        
        var burger = burgerDto.ToEntity();
        var ingredients = await _context.Ingredients.Where(i => burgerDto.Ingredients.Contains(i.Id)).ToListAsync();

        if (ingredients.Count != burgerDto.Ingredients.Count())
        {
            var missingIngredients = burgerDto.Ingredients.Except(ingredients.Select(i => i.Id));
            throw new EntityNotFoundException<Ingredient>(missingIngredients.First());
        }
        
        burger.Ingredients = ingredients;
        
        _context.Burgers.Add(burger);
        await _context.SaveChangesAsync();
        return burger.ToDto();
    }
    
    public async Task<BurgerDTO> GetBurgerById(int id)
    {
        var burger = await _context.Burgers.Include(b => b.Ingredients).FirstOrDefaultAsync(b => b.Id == id);
        if (burger is null)
        {
            throw new EntityNotFoundException<Burger>(id);
        }
        
        return burger.ToDto();
    }

    //READ
    public async Task<List<BurgerDTO>> GetAllBurgers()
    {
        var burgerList = await _context.Burgers.Include(b=>b.Ingredients).Select(b => b.ToDto()).ToListAsync();
        return burgerList;
    }

    //UPDATE
    public async Task<BurgerDTO> UpdateBurger(int id, CreateBurgerDto burgerDto)
    {
        
        if (!burgerDto.Ingredients.Any())
        {
            throw new EntityCollectionPropertyIsEmptyException<CreateBurgerDto>(nameof(burgerDto.Ingredients));
        }
        
        var burger = await _context.Burgers.FirstOrDefaultAsync(b => b.Id == id);

        if (burger is null)
        {
            throw new EntityNotFoundException<Burger>(id);
        }
        
        var ingredients = await _context.Ingredients.Where(i => burgerDto.Ingredients.Contains(i.Id)).ToListAsync();

        if (ingredients.Count != burgerDto.Ingredients.Count())
        {
            var missingIngredients = burgerDto.Ingredients.Except(ingredients.Select(i => i.Id));
            throw new EntityNotFoundException<Ingredient>(missingIngredients.First());
        }
        
        burger.Price = burgerDto.Price != burger.Price ? burgerDto.Price : burger.Price;
        burger.Name = (!burgerDto.Name.IsNullOrEmpty() &&  burgerDto.Name != burger.Name) ? burgerDto.Name : burger.Name;
        burger.Vegetarien = burgerDto.Vegetarien != burger.Vegetarien ? burgerDto.Vegetarien : burger.Vegetarien;

        burger.Ingredients = ingredients;
        
        _context.Burgers.Update(burger);
        await _context.SaveChangesAsync();
        return burger.ToDto();
    }

    //DELETE
    public async Task DeleteBurger(int id)
    {
        var burger = await _context.Burgers.FirstOrDefaultAsync(b => b.Id == id);
        if (burger == null) throw new EntityNotFoundException<Burger>(id);
        
        // Put Ingredient.BurgerId=null to avoid foreign key constraint
        var ingredients = await _context.Ingredients.Where(i => i.Burger.Id == id).ToListAsync();
        ingredients.ForEach(i => i.BurgerId = null);
        _context.Ingredients.UpdateRange(ingredients);
        
        _context.Burgers.Remove(burger);
        await _context.SaveChangesAsync();
    }


}
