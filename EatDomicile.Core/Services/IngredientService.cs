using EatDomicile.Core.Contexts;
using EatDomicile.Core.Models;
using EatDomicile.Core.Dtos;
using System;
using EatDomicile.Core.Dtos.Ingredient;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


namespace EatDomicile.Core.Services;

public class IngredientService : IIngredientService
{
    private readonly ILogger<IngredientService> _logger;
    private readonly ProductContext _context;


    public IngredientService(ILogger<IngredientService> logger, ProductContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    // READ
    public async Task<IEnumerable<IngredientDTO>> GetAllIngredients()
    {
        var ingredientList = await _context.Ingredients.Select(i => i.ToDto()).ToListAsync();
        return ingredientList;
    }

    public async Task<IngredientDTO> GetIngredientById(int id)
    {
        var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
        if (ingredient is null)
        {
            _logger.LogInformation($"Ingredient not found with id: {id}");
            throw new EntityNotFoundException<Ingredient>(id);
        }
        return ingredient.ToDto();
        
    }
    
    // CREATE
    public async Task<IngredientDTO> AddIngredient( CreateIngredientDto ingredientDto)
    {
        var ingredient = ingredientDto.ToEntity();
        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
        return IngredientDTO.FromEntity(ingredient);
    }

    // UPDATE
    public async Task UpdateIngredient(int id, CreateIngredientDto ingredientDto)
    {
        var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
        if (ingredient is null)
        {
            throw new EntityNotFoundException<Ingredient>(id);
        }
        
        ingredient.Name = ingredientDto.Name.IsNullOrEmpty() ? ingredient.Name : ingredientDto.Name;
        ingredient.Allergene = ingredientDto.Allergene != ingredient.Allergene ? ingredientDto.Allergene : ingredient.Allergene;
        ingredient.Kcal = ingredientDto.Kcal != ingredient.Kcal ? ingredientDto.Kcal : ingredient.Kcal;
        
        _context.Ingredients.Update(ingredient);
        await _context.SaveChangesAsync();
    }

    // DELETE
    public async Task DeleteIngredient(int id)
    {
        var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
        if (ingredient != null)
        {
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return;
        }
        throw new EntityNotFoundException<Ingredient>(id);
    }

    public async Task<IEnumerable<IngredientDTO>> GetAllIngerdientsAllergene()
    {
        var ingredientList = await _context.Ingredients
            .Where(i => i.Allergene)
            .Select(i => i.ToDto())
            .ToListAsync();
        
        return ingredientList;
    }
}
