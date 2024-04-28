using System.Collections.Generic;
using System.Threading.Tasks;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;

namespace SigmaBack.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await _usuarioRepository.ObterTodosUsuarios();
        }

        public async Task<Usuario> ObterUsuarioPorId(int id)
        {
            return await _usuarioRepository.ObterUsuarioPorId(id);
        }

        public async Task<int> RegistrarNovoUsuario(Usuario usuario)
        {
            return await _usuarioRepository.InserirUsuario(usuario);
        }

        public async Task AtualizarPerfilUsuario(Usuario usuario)
        {
            await _usuarioRepository.AtualizarUsuario(usuario);
        }

        public async Task RemoverUsuario(int id)
        {
            await _usuarioRepository.RemoverUsuario(id);
        }

        public async Task<bool> VerificarExistenciaEmail(string email)
        {
            return await _usuarioRepository.VerificarExistenciaEmail(email);
        }

        public async Task<bool> AutenticarUsuario(string email, string senha)
        {
            await Task.Run(() =>
            {
               

            });
            // Implemente a autenticação do usuário aqui
            return false; // Altere isso conforme a lógica de autenticação real
        }

        public async Task<bool> AlterarSenha(int idUsuario, string senhaAntiga, string novaSenha)
        {
            await Task.Run(() =>
            {
                

            });
            // Implemente a lógica de alteração de senha aqui
            return false; // Altere isso conforme a lógica real
        }

        public async Task<IEnumerable<Endereco>> ObterEnderecosUsuario(int idUsuario)
        {
            await Task.Run(() =>
            {
                // Implemente a obtenção de endereços do usuário aqui
                
            });
            return new List<Endereco>(); // Altere isso conforme a lógica real
           
        }

        public async Task AdicionarEnderecoUsuario(int idUsuario, Endereco endereco)
        {
            await Task.Run(() =>
            {
            // Implemente a adição de endereço do usuário aqui
            });
            
        }

        public async Task RemoverEnderecoUsuario(int idEndereco)
        {
            await Task.Run(() =>
            {
                // Implemente a remoção de endereço do usuário aqui
            });
        }


    }
}
//