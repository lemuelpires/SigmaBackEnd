using sigmaBack.Domain.Entities;

namespace sigmaBack.Domain.Interfaces
{
    public interface IAvaliacaoService
    {
        Task<IEnumerable<Avaliacao>> GetAllAvaliacoesAsync();
        Task<Avaliacao> GetAvaliacaoByIdAsync(int id);
        Task<Avaliacao> CreateAvaliacaoAsync(Avaliacao avaliacao);
        Task UpdateAvaliacaoAsync(Avaliacao avaliacao);
        Task DisabilitarAvaliacaoAsync(int id);
        Task HabilitarAvaliacaoAsync(int id);

    }
}



