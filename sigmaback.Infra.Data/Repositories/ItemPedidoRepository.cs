using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sigmaBack.Infra.Data.Contexts;

namespace SigmaBack.Infra.Data.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly SigmaDbContext _dbContext;

        public ItemPedidoRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ItemPedido>> ObterTodosItensPedido()
        {
            return await _dbContext.ItensPedidos.ToListAsync();
        }

        public async Task<ItemPedido> ObterItemPedidoPorId(int id)
        {
            return await _dbContext.ItensPedidos.FindAsync(id);
        }

        public async Task<int> CriarNovoItemPedido(ItemPedido itemPedido)
        {
            _dbContext.ItensPedidos.Add(itemPedido);
            await _dbContext.SaveChangesAsync();
            return itemPedido.IDItemPedido; // Retornando o ID do item de pedido criado
        }

        public async Task AtualizarItemPedido(ItemPedido itemPedido)
        {
            _dbContext.Entry(itemPedido).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoverItemPedido(int id)
        {
            var itemPedido = await _dbContext.ItensPedidos.FindAsync(id);
            if (itemPedido != null)
            {
                _dbContext.ItensPedidos.Remove(itemPedido);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
//