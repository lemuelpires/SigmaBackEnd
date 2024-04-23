using sigmaBack.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sigmaBack.Domain.Interfaces
{
    public interface IAvaliacaoService
    {
        Task<IEnumerable<Avaliacao>> GetAllAvaliacoesAsync();
        Task<Avaliacao> GetAvaliacaoByIdAsync(int id);
        Task<Avaliacao> CreateAvaliacaoAsync(Avaliacao avaliacao);
        Task UpdateAvaliacaoAsync(Avaliacao avaliacao);
        Task DeleteAvaliacaoAsync(int id);
    }
}


