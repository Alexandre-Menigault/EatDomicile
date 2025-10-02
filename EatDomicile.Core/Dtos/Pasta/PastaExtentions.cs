namespace EatDomicile.Core.Dtos.Pasta;

public static class PastaExtentions
{
    public static PastaDTO ToDto(this Models.Pasta pasta)
    {
        return new PastaDTO()
        {
            Id = pasta.Id,
            Name = pasta.Name,
            Price = pasta.Price,
            Vegetarien = pasta.Vegetarien,
            Type = pasta.Type,
            KCal = pasta.KCal
        };
    }

    public static Models.Pasta ToEntity(this CreatePastaDto pastaDTO)
    {
        return new Models.Pasta()
        {
            Name = pastaDTO.Name,
            Price = pastaDTO.Price,
            Vegetarien = pastaDTO.Vegetarien,
            Type = pastaDTO.Type,
            KCal = pastaDTO.KCal
        };
    }
}