namespace EatDomicile.Core.Dtos;

public class ProductDTO
{
    public String Name { get; set; }
    public decimal Price { get; set; }
    
    public ProductDTO(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}