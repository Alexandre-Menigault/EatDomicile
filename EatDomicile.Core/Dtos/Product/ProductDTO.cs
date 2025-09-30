namespace EatDomicile.Core.Dtos.Product;

public class ProductDTO
{
    public int Id { get; set; }
    public String Name { get; set; }
    public decimal Price { get; set; }

    public ProductDTO()
    {
        
    }
    
    public ProductDTO(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
    
    public static ProductDTO FromEntity(Models.Product product)
    {
        return new ProductDTO(
            product.Name,
            product.Price
        );
    }

    public static Models.Product ToEntity(ProductDTO productDTO)
    {
        return new Models.Product()
        {
            Name = productDTO.Name,
            Price = productDTO.Price
        };
    }

    public static List<ProductDTO> FromEntities(List<Models.Product> products)
    {
        return products
            .Select(ProductDTO.FromEntity)
            .ToList();
    }

    public static List<Models.Product> ToEntities(List<ProductDTO> products)
    {
        return products
            .Select(ProductDTO.ToEntity)
            .ToList();   
    }
}