namespace EatDomicile.Web.Services.Dtos;


public class FoodDTO : ProductDTO
{
    
    public bool Vegetarien { get; set; }
    
    public FoodDTO(string name, decimal price, bool vegetarien): base(name, price)
    {
        this.Vegetarien = vegetarien;
    }
}