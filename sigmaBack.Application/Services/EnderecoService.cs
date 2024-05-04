using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository ?? throw new ArgumentNullException(nameof(enderecoRepository));
        }

        public async Task<IEnumerable<Endereco>> ObterTodosEnderecos()
        {
            return await _enderecoRepository.ObterTodosEnderecos();
        }

        public async Task<Endereco> ObterEnderecoPorId(int id)
        {
            return await _enderecoRepository.ObterEnderecoPorId(id);
        }

        public async Task<int> CriarNovoEndereco(Endereco endereco)
        {
            if (endereco == null)
            {
                throw new ArgumentNullException(nameof(endereco));
            }

            return await _enderecoRepository.CriarNovoEndereco(endereco);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (endereco == null)
            {
                throw new ArgumentNullException(nameof(endereco));
            }

            await _enderecoRepository.AtualizarEndereco(endereco);
        }

        public async Task DesabilitarEndereco(int id)
        {
            await _enderecoRepository.DesabilitarEndereco(id);
        }

        public async Task HabilitarEndereco(int id)
        {
            await _enderecoRepository.HabilitarEndereco(id);
        }
    }
}
