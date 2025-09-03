using EatDomicile.Core.Models;

namespace EatDomicile.Core.Dtos;

public class DoughDTO
{
    public string Name { get; set; }
    
    public DoughDTO(string name) => Name = name;

    public static DoughDTO FromEntity(Dough dough)
    {
        return new DoughDTO(
            dough.Name
        );
    }

    public static Dough ToEntity(DoughDTO doughDTO)
    {
        return new Dough()
        {
            Name = doughDTO.Name
        };
    }
}