using EatDomicile.Web.Services.Dtos;

namespace EatDomicile.Web.Services.Services.Abstracts;

public interface IApiPastaService
{
    Task<IEnumerable<PastaDTO>> GetPastasAsync();
    Task<PastaDTO> GetPasta(int Id);
    Task CreatePastaAsync(PastaDTO PastaDTO);

    Task DeletePastaAsync(int Id);
    Task UpdatePastaAsync(int Id, PastaDTO PastaDTO);
}
