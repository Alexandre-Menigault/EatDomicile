using EatDomicile.Core.Contexts;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Dtos.Pasta;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EatDomicile.Core.Services;

public class PastaService : IPastaService
{
    private readonly ILogger<PastaService> _logger;
    private readonly ProductContext _context;

    public PastaService(ILogger<PastaService> logger, ProductContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IEnumerable<PastaDTO>> GetAllPastas()
    {
        return await _context.Pastas
            .Select(p => p.ToDto())
            .ToListAsync();
    }

    public async Task<PastaDTO> GetPastaById(int id)
    {
        var pasta = await _context.Pastas
            .FirstOrDefaultAsync(p => p.Id == id);
        if (pasta is null)
        {
            throw new EntityNotFoundException<Pasta>(id);
        }
        
        return pasta.ToDto();
        
    }

    public async Task<PastaDTO> CreatePasta(CreatePastaDto pastaDto)
    {
        var pasta = pastaDto.ToEntity();
        
        _context.Pastas.Add(pasta);
        await _context.SaveChangesAsync();
        return PastaDTO.FromEntity(pasta);
        
    }

    public async Task UpdatePasta(int id, CreatePastaDto pastaDto)
    {
        var pasta = await _context.Pastas
            .FirstOrDefaultAsync(p => p.Id == id);
        if (pasta is null)
        {
            throw new EntityNotFoundException<Pasta>(id);
        }

        pasta.Name = pastaDto.Name.IsNullOrEmpty() && pasta.Name == pastaDto.Name ? pasta.Name : pastaDto.Name;
        pasta.Vegetarien = pasta.Vegetarien != pastaDto.Vegetarien ? pastaDto.Vegetarien : pasta.Vegetarien;
        pasta.Price = pasta.Price != pastaDto.Price ? pastaDto.Price : pasta.Price;
        pasta.KCal = pasta.KCal != pastaDto.KCal ? pastaDto.KCal : pasta.KCal;
        
        _context.Pastas.Update(pasta);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeletePasta(int id)
    {
        var pasta = await _context.Pastas
            .FirstOrDefaultAsync(p => p.Id == id);
        if (pasta is null)
        {
            throw new EntityNotFoundException<Pasta>(id);
        }
        _context.Pastas.Remove(pasta);
        await _context.SaveChangesAsync();
    }
    
}