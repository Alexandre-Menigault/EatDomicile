using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

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

    public static AddressDTO FromEntity(Address address)
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

    public static Address ToEntity(AddressDTO dto)
        
        {
        return new Address
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
