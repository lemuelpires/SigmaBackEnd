using System.Collections.Generic;
using System.Threading.Tasks;
using sigmaBack.Domain.Entities;

namespace sigmaBack.Domain.Interfaces
{
    public interface IJogoService
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
        Task AtualizarReferenciaImagem(int idJogo, string referenciaImagem);
    }
}
