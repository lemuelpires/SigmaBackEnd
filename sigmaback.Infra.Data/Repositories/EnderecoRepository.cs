using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using sigmaBack.Infra.Data.Contexts;

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
            return await _dbContext.Enderecos.FindAsync(id);
        }

        public async Task<int> CriarNovoEndereco(Endereco endereco)
        {
            _dbContext.Enderecos.Add(endereco);
            await _dbContext.SaveChangesAsync();
            return endereco.IDEndereco; // Supondo que o ID seja gerado automaticamente
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            _dbContext.Enderecos.Update(endereco);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoverEndereco(int id)
        {
            var endereco = await _dbContext.Enderecos.FindAsync(id);
            if (endereco != null)
            {
                _dbContext.Enderecos.Remove(endereco);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
