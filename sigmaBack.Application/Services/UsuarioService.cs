using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigmaBack.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
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
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            if (await VerificarExistenciaEmail(usuario.Email))
            {
                throw new InvalidOperationException("O email já está em uso por outro usuário.");
            }

            return await _usuarioRepository.InserirUsuario(usuario);
        }

        public async Task AtualizarPerfilUsuario(Usuario usuario)
        {
            await _usuarioRepository.AtualizarUsuario(usuario);
        }

        public async Task HabilitarUsuario(int id)
        {
            await _usuarioRepository.HabilitarUsuario(id);
        }

        public async Task DesabilitarUsuario(int id)
        {
            await _usuarioRepository.DesabilitarUsuario(id);
        }

        public async Task<bool> VerificarExistenciaEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email), "O email não pode ser nulo.");
            }

            return await _usuarioRepository.VerificarExistenciaEmail(email);
        }

        public Task<bool> AutenticarUsuario(string email, string senha)
        {
            // Implemente a lógica para autenticar o usuário
            return Task.FromResult(false);
        }

        public Task<bool> AlterarSenha(int idUsuario, string senhaAntiga, string novaSenha)
        {
            // Implemente a lógica para alterar a senha do usuário
            return Task.FromResult(false);
        }

        public Task<IEnumerable<Endereco>> ObterEnderecosUsuario(int idUsuario)
        {
            // Implemente a lógica para obter os endereços do usuário
            return Task.FromResult<IEnumerable<Endereco>>(new List<Endereco>());
        }

        public Task AdicionarEnderecoUsuario(int idUsuario, Endereco endereco)
        {
            // Implemente a lógica para adicionar um endereço ao usuário
            return Task.CompletedTask;
        }

        public Task RemoverEnderecoUsuario(int idEndereco)
        {
            // Implemente a lógica para remover um endereço do usuário
            return Task.CompletedTask;
        }
    }
}
