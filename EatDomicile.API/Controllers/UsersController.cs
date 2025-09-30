using EatDomicile.API.Errors;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Exceptions;
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
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IResult> Create<T>([FromBody] CreateUserDTO createUserDTO)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
            return Results.BadRequest(new ModelStateInvalidError("Impossible to update the user, the body in invalid format", errors));
        }

        try
        {
            var userDto = await _userService.CreateUser(createUserDTO);
            var location = Url.Action("GetById", new {id = userDto.Id});
            return Results.Created(location, userDto);
        }
        catch (EntityNotFoundException<Address> e)
        {
            return Results.BadRequest(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    //PUT
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IResult> Update(int id, [FromBody] UserLightDTO userLightDTO)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
            return Results.BadRequest(new ModelStateInvalidError("Impossible to update the user, the body in invalid format", errors));
        }

        try
        {
            await _userService.UpdateUser(id, userLightDTO);
            return Results.NoContent();
        }
        catch (EntityNotFoundException<User> e)
        {
            return Results.NotFound(e.Message);
        }
        catch (EntityNotFoundException<Address> e)
        {
            return Results.BadRequest(e.Message);
        }
        catch
        {
            return Results.InternalServerError();
        }
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
        catch (EntityNotFoundException<User> e)
        {
            return Results.NotFound(e.Message);
        }
    }
}