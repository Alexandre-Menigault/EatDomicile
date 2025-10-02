using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services.Abstracts;

public interface IApiAddressService
{
    Task<IEnumerable<AddressDTO>> GetAddressesAsync();
    Task<AddressDTO> GetAddress(int Id);
    Task CreateAddressAsync(AddressDTO addressDTO);

    Task DeleteAddressAsync(int Id);
    Task UpdateAddressAsync(int Id, AddressDTO addressDTO);
}

