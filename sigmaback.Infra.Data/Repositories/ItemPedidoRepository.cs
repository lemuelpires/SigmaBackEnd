using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;

namespace SigmaBack.Infra.Data.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly SigmaDbContext _dbContext;

        public ItemPedidoRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<ItemPedido>> ObterTodosItensPedido()
        {
            return await _dbContext.ItensPedidos.ToListAsync();
        }

        public async Task<ItemPedido> ObterItemPedidoPorId(int id)
        {
            var itemPedido = await _dbContext.ItensPedidos.FindAsync(id);
            if (itemPedido == null)
            {
                throw new Exception($"Item de pedido com ID {id} não encontrado.");
            }
            return itemPedido;
        }

        public async Task<int> CriarNovoItemPedido(ItemPedido itemPedido)
        {
            _dbContext.ItensPedidos.Add(itemPedido);
            await _dbContext.SaveChangesAsync();
            return itemPedido.IDItemPedido;
        }

        public async Task AtualizarItemPedido(ItemPedido itemPedido)
        {
            _dbContext.Entry(itemPedido).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DesabilitarItemPedido(int id)
        {
            var itemPedido = await _dbContext.ItensPedidos.FindAsync(id);
            if (itemPedido != null)
            {
                itemPedido.Ativo = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task HabilitarItemPedido(int id)
        {
            var itemPedido = await _dbContext.ItensPedidos.FindAsync(id);
            if (itemPedido != null)
            {
                itemPedido.Ativo = true;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
