using EatDomicile.Core.Dtos.Burger;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EatDomicile.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BurgersController : Controller
{
    private readonly ILogger<BurgersController> _logger;
    private readonly IBurgerService _burgerService;

    public BurgersController(ILogger<BurgersController> logger, IBurgerService burgerService)
    {
        _logger = logger;
        _burgerService = burgerService;
    }
    
    // GET ALL

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BurgerDTO>))]
    public async Task<IResult> GetBurgers()
    {
        var burgers = await _burgerService.GetAllBurgers();
        return Results.Ok(burgers);
    }
    
    // GET ONE
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BurgerDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> GetBurgerById(int id)
    {
        try
        {
            var burger = await _burgerService.GetBurgerById(id);
            return Results.Ok(burger);
        }
        catch (EntityNotFoundException<Burger> e)
        {
            return Results.NotFound(e.Message);
        }
    }
    
    // POST
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BurgerDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IResult> AddBurger([FromBody] CreateBurgerDto burgerDto)
    {
        try
        {
            var burger = await _burgerService.AddBurger(burgerDto);
            var location = Url.Action("GetBurgerById", new { id = burger.Id });
            return Results.Created(location, burger);
        }
        catch (EntityNotFoundException<Ingredient> e)
        {
            return Results.BadRequest(e.Message);
        }
        catch (EntityCollectionPropertyIsEmptyException<CreateBurgerDto> e)
        {
            return Results.BadRequest(e.Message);
        }
    }
    
    // PUT
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IResult> UpdateBurger(int id, [FromBody] CreateBurgerDto burgerDto)
    {
        try
        {
            var burger = await _burgerService.UpdateBurger(id, burgerDto);
            return Results.NoContent();       
        }
        catch (EntityNotFoundException<Burger> e)
        {
            return Results.NotFound(e.Message);
        }
        catch (EntityNotFoundException<Ingredient> e)
        {
            return Results.BadRequest(e.Message);
        }
        catch (EntityCollectionPropertyIsEmptyException<CreateBurgerDto> e)
        {
            return Results.BadRequest(e.Message);
        }
    }    
    // DELETE
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> DeleteBurger(int id)
    {
        try
        {
            await _burgerService.DeleteBurger(id);
            return Results.NoContent();
        }
        catch (EntityNotFoundException<Burger> e)
        {
            return Results.NotFound(e.Message);
        }
    }
}