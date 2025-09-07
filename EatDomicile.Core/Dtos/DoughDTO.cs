using EatDomicile.Core.Models;
using System.Text;

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

    public static class DoughExtensions
    {
        public static String AsString(this Dough dough)
        {
            return $"Dough: {dough.Id} {","} {dough.Name}";

        }

        public static String AsString(this List<Dough> doughs)
        {
            var sb = new StringBuilder();
            foreach (var dough in doughs)
            {
                sb.AppendLine(dough.AsString());
            }
            return sb.ToString();
        }
    }
    