using EatDomicile.API.Errors;
using EatDomicile.Core.Dtos.Drink;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EatDomicile.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrinksController : Controller
{
    private readonly ILogger<DrinksController> _logger;
    private readonly IDrinkService _drinkService;

    public DrinksController(ILogger<DrinksController> logger, IDrinkService drinkService)
    {
        _logger = logger;
        _drinkService = drinkService;
    }
    
    // GET ALL
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DrinkDTO>))]
    public async Task<IResult> GetDrinks()
    {
        var drinks = await _drinkService.GetAllDrinks();
        return Results.Ok(drinks);
    }
    // GET BY ID
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DrinkDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> GetDrinkById(int id)
    {
        try
        {
            var drink = await _drinkService.GetDrinkById(id);
            return Results.Ok(drink);
        }
        catch (EntityNotFoundException<Drink> e)
        {
            return Results.NotFound(e.Message);
        }
    }
    
    // POST
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DrinkDTO))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(DrinkAlreadyExistsByName))]
    public async Task<IResult> AddDrink([FromBody] CreateDrinkDto drinkDto)
    {
        try
        {
            var drink = await _drinkService.AddDrink(drinkDto);
            var location = Url.Action("GetDrinkById", new { id = drink.Id });
            return Results.Created(location, drink);
        }
        catch (EntityAlreadyExistsException<Drink> e)
        {
            return Results.Conflict(new DrinkAlreadyExistsByName{Name = drinkDto.Name});
        }
    }
    
    // PUT
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(DrinkAlreadyExistsByName))]
    public async Task<IResult> UpdateDrink(int id, [FromBody] CreateDrinkDto drinkDto)
    {
        try
        {
            await _drinkService.UpdateDrink(id, drinkDto);
            return Results.NoContent();
        } catch (EntityNotFoundException<Drink> e)
        {
            return Results.NotFound(e.Message);
        } catch (EntityAlreadyExistsException<Drink> e)
        {
            return Results.Conflict(new DrinkAlreadyExistsByName{Name = drinkDto.Name});
        }
    }
    
    // DELETE
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> DeleteDrink(int id)
    {
        try
        {
            await _drinkService.DeleteDrink(id);
            return Results.NoContent();
        } catch (EntityNotFoundException<Drink> e)
        {
            return Results.NotFound(e.Message);
        }
    }
    
}