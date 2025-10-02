using EatDomicile.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using EatDomicile.Core.Dtos.Pasta;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EatDomicile.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PastaController : Controller
{
    private readonly ILogger<PastaController> _logger;
    private readonly IPastaService _pastaService;

    public PastaController(ILogger<PastaController> logger, IPastaService pastaService)
    {
        _logger = logger;
        _pastaService = pastaService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PastaDTO>))]
    public async Task<IResult> GetAll()
    {
        var pastas = await _pastaService.GetAllPastas();
        return Results.Ok(pastas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PastaDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]   
    public async Task<IResult> Get(int id)
    {
        try
        {
            var pasta = await _pastaService.GetPastaById(id);
            return Results.Ok(pasta);
        }
        catch (EntityNotFoundException<Pasta> e)
        {
            return Results.NotFound(e.Message);       
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PastaDTO))]
    public async Task<IResult> Create([FromBody] CreatePastaDto pastaDto)
    {
        var pasta = await _pastaService.CreatePasta(pastaDto);
        var location = Url.Action(nameof(Get), new { id = pasta.Id });
        return Results.Created(location, pasta);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]   
    public async Task<IResult> Update(int id, [FromBody] CreatePastaDto pastaDto)
    {
        try
        {
            await _pastaService.UpdatePasta(id, pastaDto);
            return Results.NoContent();
        } catch(EntityNotFoundException<Pasta> e)
        {
            return Results.NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]   
    public async Task<IResult> Delete(int id)
    {
        try
        {
            await _pastaService.DeletePasta(id);
            return Results.NoContent();
        }
        catch (EntityNotFoundException<Pasta> e)
        {
            return Results.NotFound(e.Message);       
        }
    }
}