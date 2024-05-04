using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObterTodosUsuarios();
        Task<Usuario> ObterUsuarioPorId(int id);
        Task<int> RegistrarNovoUsuario(Usuario usuario);
        Task AtualizarPerfilUsuario(Usuario usuario);
        Task HabilitarUsuario(int id);
        Task DesabilitarUsuario(int id);
        Task<bool> VerificarExistenciaEmail(string email);
        Task<bool> AutenticarUsuario(string email, string senha);
        Task<bool> AlterarSenha(int idUsuario, string senhaAntiga, string novaSenha);
        Task<IEnumerable<Endereco>> ObterEnderecosUsuario(int idUsuario);
        Task AdicionarEnderecoUsuario(int idUsuario, Endereco endereco);
        Task RemoverEnderecoUsuario(int idEndereco);
    }
}

