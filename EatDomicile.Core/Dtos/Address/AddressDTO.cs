using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EatDomicile.Core.Dtos.Address;

public class AddressDTO
{
    public int Id { get; set; } 
    [MaxLength(200)]
    public string Street { get; set; } = String.Empty;
    [MaxLength(100)]
    public string City { get; set; } = String.Empty;
    [MaxLength(100)]
    public string State { get; set; } = String.Empty;
    public int ZipCode { get; set; }
    [MaxLength(100)]
    public string Country { get; set; } = String.Empty;
    
    
    public AddressDTO()
    {
        
    }

    public AddressDTO(int id, string street, string city, string state, int zipCode, string country)
    {
        this.Id = id;
        this.Street = street;
        this.City = city;
        this.State = state;
        this.ZipCode = zipCode;
        this.Country = country;
    }

    public static AddressDTO FromEntity(Models.Address address)
    {
        return new AddressDTO(
            address.Id,
            address.Street,
             address.City,
            address.State,
            address.ZipCode,
             address.Country
            );
        }

    public static Models.Address ToEntity(AddressDTO dto)
        
        {
        return new Models.Address
        {
            Id = dto.Id,
            Street = dto.Street,
            City = dto.City,
            State = dto.State,
            ZipCode = dto.ZipCode,
            Country = dto.Country
        };
           
        }
}

public static class AddressDTOExtensions
{
    public static String AsString(this AddressDTO address)
    {
        var sb = new StringBuilder();
        sb.Append($"<Address> {address.Street} {address.City} {address.State} {address.ZipCode} {address.Country}");
        
        return sb.ToString();
    }
}
