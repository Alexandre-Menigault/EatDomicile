using EatDomicile.Core.Dtos.Pasta;

namespace EatDomicile.Core.Services.Abstractions;

public interface IPastaService
{
    Task<IEnumerable<PastaDTO>> GetAllPastas();
    Task<PastaDTO> GetPastaById(int id);
    Task<PastaDTO> CreatePasta(CreatePastaDto pastaDto);
    Task UpdatePasta(int id, CreatePastaDto pastaDto);
    Task DeletePasta(int id);
}