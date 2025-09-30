using System.ComponentModel.DataAnnotations;

namespace EatDomicile.Core.Dtos.Address;

public class CreateAddressDto
{
    [MaxLength(200)]
    public string Street { get; set; } = String.Empty;
    [MaxLength(100)]
    public string City { get; set; } = String.Empty;
    [MaxLength(100)]
    public string State { get; set; } = String.Empty;
    public int ZipCode { get; set; }
    [MaxLength(100)]
    public string Country { get; set; } = String.Empty;
}

