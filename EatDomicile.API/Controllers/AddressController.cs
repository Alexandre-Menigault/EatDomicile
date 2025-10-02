using EatDomicile.API.Errors;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Dtos.Address;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EatDomicile.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : Controller
{
    private readonly ILogger<AddressController> _logger;
    private readonly IAddressService _addressService;

    public AddressController(ILogger<AddressController> logger  , IAddressService addressService)
    {
        _logger = logger;
        _addressService = addressService;
    }
    
    // GET ALL

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AddressDTO>))]
    public async Task<IResult> GetAll()
    {
        var addressDtos = await _addressService.GetAddresses();
        return Results.Ok(addressDtos);
    }
    
    // GET ONE
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> GetById(int id)
    {
        try
        {
            return  Results.Ok(await _addressService.GetAddress(id));

        }
        catch (EntityNotFoundException<Address> e)
        {
            return Results.NotFound(e.Message);
        }
    }
    // POST

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AddressDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResult))]
    public async Task<IResult> CreateAddress([FromBody] CreateAddressDto createAddressDto)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
            return Results.BadRequest(new ModelStateInvalidError("Impossible to create the createAddressDto, the body is in an invalid format", errors));
        }

        var address = await _addressService.CreateAddress(createAddressDto);
        var location = Url.Action("GetById", new {id = address.Id});
        return Results.Created(location, address);
    }
    // PUT
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> UpdateAddress(int id, [FromBody] CreateAddressDto addressDto)
    {
        try
        {
            await _addressService.UpdateAddress(id, addressDto);
            return Results.NoContent();
        } catch (EntityNotFoundException<Address> e)
        {
            return Results.NotFound(e.Message);
        }
        
    }
    
    // DELETE
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IResult> DeleteAddress(int id)
    {
        try
        {
            await _addressService.DeleteAddress(id);
        } catch (EntityNotFoundException<Address> e)
        {
            return Results.NotFound(e.Message);
        }
        return Results.NoContent();
    }
}