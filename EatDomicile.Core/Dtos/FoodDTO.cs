using EatDomicile.Core.Dtos.Product;
using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class FoodDTO : ProductDTO
{
    
    public bool Vegetarien { get; set; }

    public FoodDTO()
    {
        
    }
    
    public FoodDTO(string name, decimal price, bool vegetarien): base(name, price)
    {
        this.Vegetarien = vegetarien;
    }
}