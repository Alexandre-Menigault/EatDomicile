using EatDomicile.Core.Dtos;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EatDomicile.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }
    
    // GET
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    public IResult Index()
    {
        var users = _userService.GetAllUsers();
        
        return Results.Ok(users);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
    public IResult GetById(int id)
    {
        var user = _userService.GetUser(id);
        if (user is null)
        {
            return Results.NotFound();
        }
        return Results.Ok(user);
    }
    
    // POST
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
    public IResult Create([FromBody] CreateUserDTO createUserDTO)
    {
        if (!ModelState.IsValid)
        {
            return Results.BadRequest("Impossible to create a new user, the body in invalid format");
        }
        var userDto = _userService.CreateUser(createUserDTO);
        return Results.Created($"api/users/{userDto.Id}", userDto);
    }
    
    // DELETE
    [HttpDelete("{id}")]
    
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
    public IResult Delete(int id)
    {
        try
        {
            _userService.DeleteUser(id);
            return Results.NoContent();
        }
        catch (Exception e)
        {

            return Results.NotFound();
        }
    }
}