using System.Text;

namespace EatDomicile.Web.Services.Dtos;

public class DoughDTO
{
    public string Name { get; set; }

    public DoughDTO(string name) => Name = name;

}

    public static class DoughExtensions
    {
        public static String AsString(this DoughDTO dough)
        {
            return $"Dough: {dough.Name}";

        }

        public static String AsString(this List<DoughDTO> doughs)
        {
            var sb = new StringBuilder();
            foreach (var dough in doughs)
            {
                sb.AppendLine(dough.AsString());
            }
            return sb.ToString();
        }
    }
    