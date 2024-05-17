using sigmaBack.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigmaBack.Domain.Interfaces
{
    public interface IUsuarioJogoRepository
    {
        Task<IEnumerable<UsuarioJogo>> ObterTodosUsuarioJogo();
        Task<UsuarioJogo> ObterUsuarioJogoPorId(int id);
        Task<int> CriarNovoUsuarioJogo(UsuarioJogo usuarioJogo);
        Task AtualizarUsuarioJogo(UsuarioJogo usuarioJogo);
        Task HabilitarUsuarioJogo(int id);
        Task DesabilitarUsuarioJogo(int id);
    }
}
