using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IAnuncioService
    {
        Task<IEnumerable<Anuncio>> ObterTodosAnuncios();
        Task<Anuncio> ObterAnuncioPorId(int id);
        Task<int> CriarAnuncio(Anuncio anuncio);
        Task AtualizarAnuncio(int id, Anuncio anuncio);
        Task HabilitarAnuncio(int id);
        Task DesabilitarAnuncio(int id);
        Task AtualizarReferenciaImagem(int id, string referenciaImagem);
    }
}

