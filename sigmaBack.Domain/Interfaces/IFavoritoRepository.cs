using System.Collections.Generic;
using System.Threading.Tasks;
using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IFavoritoRepository
    {
        Task<IEnumerable<Favorito>> ObterTodosFavoritos();
        Task<Favorito> ObterFavoritoPorId(int id);
        Task<int> AdicionarFavorito(Favorito favorito);
        Task AtualizarFavorito(Favorito favorito);
        Task HabilitarFavorito(int id);
        Task DesabilitarFavorito(int id);
    }
}

