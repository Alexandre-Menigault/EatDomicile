namespace EatDomicile.Web.Services.Dtos;

public class DrinksDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool Fizzy { get; set; }

    public int KCal { get; set; }

}
