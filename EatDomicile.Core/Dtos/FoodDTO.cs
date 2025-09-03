using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class FoodDTO : ProductDTO
{
    
    public bool Vegetarien { get; set; }
    
    public FoodDTO(string name, bool vegetarien): base(name)
    {
        this.Vegetarien = vegetarien;
    }
}