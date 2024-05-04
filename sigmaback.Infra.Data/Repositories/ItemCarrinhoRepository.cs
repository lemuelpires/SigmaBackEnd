using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;

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
            return await _dbContext.ItensCarrinhos.FindAsync(id) ?? throw new ArgumentException("Item não encontrado.");
        }

        public async Task<int> CriarNovoItemCarrinho(ItemCarrinho itemCarrinho)
        {
            _dbContext.ItensCarrinhos.Add(itemCarrinho);
            await _dbContext.SaveChangesAsync();
            return itemCarrinho.IDItemCarrinho;
        }

        public async Task AtualizarItemCarrinho(ItemCarrinho itemCarrinho)
        {
            _dbContext.ItensCarrinhos.Update(itemCarrinho);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DesabilitarItemCarrinho(int id)
        {
            var itemCarrinho = await _dbContext.ItensCarrinhos.FindAsync(id);
            if (itemCarrinho != null)
            {
                itemCarrinho.Ativo = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task HabilitarItemCarrinho(int id)
        {
            var itemCarrinho = await _dbContext.ItensCarrinhos.FindAsync(id);
            if (itemCarrinho != null)
            {
                itemCarrinho.Ativo = true;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
