using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using sigmaBack.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace sigmaBack.Infra.Data.Repositories
{
    public class ItemCarrinhoRepository : IItemCarrinhoRepository
    {
        private readonly SigmaDbContext _dbContext;

        public ItemCarrinhoRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<ItemCarrinho>> ObterTodosItensCarrinho()
        {
            return await _dbContext.ItensCarrinhos.ToListAsync();
        }

        public async Task<ItemCarrinho> ObterItemCarrinhoPorId(int id)
        {
            return await _dbContext.ItensCarrinhos.FindAsync(id);
        }

        public async Task<int> CriarNovoItemCarrinho(ItemCarrinho itemCarrinho)
        {
            _dbContext.ItensCarrinhos.Add(itemCarrinho);
            await _dbContext.SaveChangesAsync();
            return itemCarrinho.IDItemCarrinho; // Supondo que o ID seja gerado automaticamente
        }

        public async Task AtualizarItemCarrinho(ItemCarrinho itemCarrinho)
        {
            _dbContext.ItensCarrinhos.Update(itemCarrinho);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoverItemCarrinho(int id)
        {
            var itemCarrinho = await _dbContext.ItensCarrinhos.FindAsync(id);
            if (itemCarrinho != null)
            {
                _dbContext.ItensCarrinhos.Remove(itemCarrinho);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
//