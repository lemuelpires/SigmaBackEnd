using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> ObterTodosEnderecos();
        Task<Endereco> ObterEnderecoPorId(int id);
        Task<int> CriarNovoEndereco(Endereco endereco);
        Task AtualizarEndereco(Endereco endereco);
        Task DesabilitarEndereco(int id);
        Task HabilitarEndereco(int id);
    }
}