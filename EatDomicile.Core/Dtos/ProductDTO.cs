using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class ProductDTO
{
    public int Id { get; set; }
    public String Name { get; set; }
    public decimal Price { get; set; }
    
    public ProductDTO(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
    
    public static ProductDTO FromEntity(Product product)
    {
        return new ProductDTO(
            product.Name,
            product.Price
        );
    }

    public static Product ToEntity(ProductDTO productDTO)
    {
        return new Product()
        {
            Name = productDTO.Name,
            Price = productDTO.Price
        };
    }

    public static List<ProductDTO> FromEntities(List<Product> products)
    {
        return products
            .Select(ProductDTO.FromEntity)
            .ToList();
    }

    public static List<Product> ToEntities(List<ProductDTO> products)
    {
        return products
            .Select(ProductDTO.ToEntity)
            .ToList();   
    }
}