using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IAnuncioRepository
    {
        Task<IEnumerable<Anuncio>> ObterTodosAnuncios();
        Task<Anuncio> ObterAnuncioPorId(int id);
        Task<IEnumerable<Anuncio>> ObterAnunciosPorPreco(decimal precoMin, decimal precoMax);
        Task<IEnumerable<Anuncio>> ObterAnunciosAtivos();
        Task<IEnumerable<Anuncio>> PesquisarAnuncios(string termoPesquisa);
        Task InserirAnuncio(Anuncio anuncio);
        Task AtualizarAnuncio(Anuncio anuncio);
        Task HabilitarAnuncio(int id);
        Task DesabilitarAnuncio(int id);
    }
}
