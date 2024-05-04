using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Infra.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly SigmaDbContext _dbContext;

        public EnderecoRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Endereco>> ObterTodosEnderecos()
        {
            return await _dbContext.Enderecos.ToListAsync();
        }

        public async Task<Endereco> ObterEnderecoPorId(int id)
        {
            return await _dbContext.Enderecos.FindAsync(id) ?? throw new ArgumentException("Endereço não encontrado.");
        }

        public async Task<int> CriarNovoEndereco(Endereco endereco)
        {
            _dbContext.Enderecos.Add(endereco);
            await _dbContext.SaveChangesAsync();
            return endereco.IDEndereco;
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            _dbContext.Enderecos.Update(endereco);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DesabilitarEndereco(int id)
        {
            var endereco = await _dbContext.Enderecos.FindAsync(id);
            if (endereco != null)
            {
                endereco.Ativo = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task HabilitarEndereco(int id)
        {
            var endereco = await _dbContext.Enderecos.FindAsync(id);
            if (endereco != null)
            {
                endereco.Ativo = true;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
