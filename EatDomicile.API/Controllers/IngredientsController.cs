using EatDomicile.API.Errors;
using EatDomicile.Core.Dtos.Ingredient;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EatDomicile.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : Controller
{
    private readonly ILogger<IngredientsController> _logger;
    private readonly IIngredientService _ingredientService;

    public IngredientsController(ILogger<IngredientsController> logger, IIngredientService ingredientService)
    {
        _logger = logger;
        _ingredientService = ingredientService;
    }
    
    // GET ALL

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IngredientDTO>))]
    public async Task<IResult> GetIngredients()
    {
        var ingredients = await _ingredientService.GetAllIngredients();
        return Results.Ok(ingredients);
    }
    
    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IResult> GetIngredientById(int id)
    {
        try
        {
            var ingredient = await _ingredientService.GetIngredientById(id);
            return Results.Ok(ingredient);
        }
        catch (EntityNotFoundException<Ingredient> e)
        {
            return Results.NotFound(e.Message);
        }
    }
    // GET ALL ALLERGENE
    [HttpGet("allergene")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<IngredientDTO>))]
    public async Task<IResult> GetIngredientsAllergene()
    {
        var ingredients = await _ingredientService.GetAllIngerdientsAllergene();
        return Results.Ok(ingredients);
    }
    
    // POST
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IngredientDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
    public async Task<IResult> CreateIngredient([FromBody] CreateIngredientDto ingredientDto)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
            return Results.BadRequest(new ModelStateInvalidError("Impossible to create the Ingredient, the body is in an invalid format", errors));
        }
        var ingredient = await _ingredientService.AddIngredient(ingredientDto);
        var location = Url.Action("GetIngredientById", new {id = ingredient.Id});
        return Results.Created(location, ingredient);
    }
    // PUT
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> UpdateIngredient(int id, [FromBody] CreateIngredientDto ingredientDto)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
            return Results.BadRequest(new ModelStateInvalidError("Impossible to create the Ingredient, the body is in an invalid format", errors));
        }

        try
        {
            await _ingredientService.UpdateIngredient(id, ingredientDto);
            return Results.NoContent();
        } catch (EntityNotFoundException<Ingredient> e)
        {
            return Results.NotFound(e.Message);
        }
        
    }
    
    // DELETE
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> DeleteIngredient(int id)
    {
        try
        {
            await _ingredientService.DeleteIngredient(id);
            return Results.NoContent();
        }
        catch (EntityNotFoundException<Ingredient> e)
        {
            return Results.NotFound(e.Message);
        }
    }
    
}