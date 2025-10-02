namespace EatDomicile.Core.Dtos.Product;

public static class ProductExtentions
{
    public static ProductDTO ToDto(this Models.Product product)
    {
        return new ProductDTO()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }
}