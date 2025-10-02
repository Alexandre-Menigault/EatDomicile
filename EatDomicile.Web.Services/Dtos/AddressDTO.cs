
namespace EatDomicile.Web.Services.Dtos;


public class AddressDTO
{
    public int Id { get; set; } 
    public  string Street { get; set; }
    public string City { get; set; }
    public  string State { get; set; }
    public int ZipCode { get; set; }
    public  string Country { get; set; }
    
    
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
}

public static class AddressDTOExtensions
{
    public static String AsString(this AddressDTO address)
    {
        var sb = new System.Text.StringBuilder();
        sb.Append($"<Address> {address.Street} {address.City} {address.State} {address.ZipCode} {address.Country}");
        
        return sb.ToString();
    }
}
