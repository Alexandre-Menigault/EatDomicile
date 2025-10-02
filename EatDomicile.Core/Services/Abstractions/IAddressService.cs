using EatDomicile.Core.Dtos;
using EatDomicile.Core.Dtos.Address;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Services.Abstractions;

public interface IAddressService
{
    Task<IEnumerable<AddressDTO>> GetAddresses();
    Task<AddressDTO> GetAddress(int id);
    Task<AddressDTO> CreateAddress(CreateAddressDto address);
    Task UpdateAddress(int id, CreateAddressDto address);
    Task DeleteAddress(int id);
    Task<bool> AddressExists(int id);
}