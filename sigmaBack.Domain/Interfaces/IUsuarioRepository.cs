using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObterTodosUsuarios();
        Task<Usuario> ObterUsuarioPorId(int id);
        Task<int> InserirUsuario(Usuario usuario);
        Task AtualizarUsuario(Usuario usuario);
        Task HabilitarUsuario(int id);
        Task DesabilitarUsuario(int id);
        Task<bool> VerificarExistenciaEmail(string email);
    }
}
