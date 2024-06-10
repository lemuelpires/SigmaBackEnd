using sigmaBack.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigmaBack.Domain.Interfaces
{
    public interface IJogoRepository
    {
        Task<IEnumerable<Jogo>> ObterTodosJogos();
        Task<Jogo> ObterJogoPorId(int id);
        Task<IEnumerable<Jogo>> ObterJogosPorCategoria(string categoria);
        Task<IEnumerable<Jogo>> ObterJogosAtivos();
        Task<IEnumerable<Jogo>> PesquisarJogos(string termoPesquisa);
        Task InserirJogo(Jogo jogo);
        Task AtualizarJogo(Jogo jogo);
        Task HabilitarJogo(int id);
        Task DesabilitarJogo(int id);
        Task AtualizarReferenciaImagem(int id, string referenciaImagem);
    }
}
