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
}