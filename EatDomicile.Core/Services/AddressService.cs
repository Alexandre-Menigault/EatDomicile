using EatDomicile.Core.Contexts;
using EatDomicile.Core.Dtos;
using EatDomicile.Core.Dtos.Address;
using EatDomicile.Core.Exceptions;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EatDomicile.Core.Services;

public class AddressService : IAddressService
{
    private readonly ILogger<AddressService> _logger;
    private readonly ProductContext _context;

    public AddressService(ILogger<AddressService> logger, ProductContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IEnumerable<AddressDTO>> GetAddresses()
    {
        return await _context.Addresses.Select<Address, AddressDTO>(
            a=> AddressDTO.FromEntity(a)
            ).ToListAsync();
    }

    public async Task<AddressDTO> GetAddress(int id)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        if (address is null)
        {
            _logger.LogInformation($"Address not found with id: {id}");
            throw new EntityNotFoundException<Address>(id);
        }
        return AddressDTO.FromEntity(address);
    }


    public async Task<AddressDTO> CreateAddress(CreateAddressDto address)
    {
        var entity = address.ToEntity();
        _context.Addresses.Add(entity);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Address created with id: {entity.Id}");
        return AddressDTO.FromEntity(entity);
    }
    public async Task UpdateAddress(int id, CreateAddressDto addressDto)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        if (address is null)
        {
            _logger.LogInformation($"Address not found with id: {id}");
            throw new EntityNotFoundException<Address>(id);
        }
        address.City = addressDto.City.IsNullOrEmpty() ? address.City : addressDto.City;
        address.Street = addressDto.Street.IsNullOrEmpty() ? address.Street : addressDto.Street;
        address.Country = addressDto.Country.IsNullOrEmpty() ? address.Country : addressDto.Country;
        address.ZipCode = addressDto.ZipCode == 0 ? address.ZipCode : addressDto.ZipCode;
        _context.Addresses.Update(address);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Address updated with id: {id}");
    }

    public async Task DeleteAddress(int id)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        if (address is null)
        {
            _logger.LogInformation($"Address not found with id: {id}");
            throw new EntityNotFoundException<Address>(id);
        }
        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Address deleted with id: {id}");
    }



    public async Task<bool> AddressExists(int id)
    {
        return await _context.Addresses.AnyAsync(a => a.Id == id);
    }
}