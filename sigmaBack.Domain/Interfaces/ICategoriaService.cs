using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ObterTodasCategorias();
        Task<Categoria> ObterCategoriaPorId(int id);
        Task<int> CriarNovaCategoria(Categoria categoria);
        Task AtualizarCategoria(Categoria categoria);
        Task DesabilitarCategoria(int id);
        Task HabilitarCategoria(int id);
    }
}
