using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<IEnumerable<Avaliacao>> ObterTodasAvaliacoes();
        Task<Avaliacao> ObterAvaliacaoPorId(int id);
        Task<int> CriarNovaAvaliacao(Avaliacao avaliacao);
        Task AtualizarAvaliacao(Avaliacao avaliacao);
        Task DesabilitarAvaliacao(int id);
    }
}


