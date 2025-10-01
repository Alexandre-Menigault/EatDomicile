namespace EatDomicile.Core.Dtos.Address;

public static class AddressEntentions
{
    public static Models.Address ToEntity(this CreateAddressDto address)
    {
        return new Models.Address
        {
            Street = address.Street,
            City = address.City,
            State = address.State,
            ZipCode = address.ZipCode,
            Country = address.Country
        };
    }

    public static AddressDTO ToDto(this Models.Address address)
    {
        return new AddressDTO
        {
            Id = address.Id,
            Street = address.Street,
            City = address.City,
            State = address.State,
            ZipCode = address.ZipCode,
            Country = address.Country
        };
    }
}