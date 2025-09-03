namespace EatDomicile.Core.Dtos;

public class ProductDTO
{
    public String Name { get; set; }
    
    public ProductDTO(string name) => Name = name;
}