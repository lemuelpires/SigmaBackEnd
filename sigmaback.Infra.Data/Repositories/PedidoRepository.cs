using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Infra.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly SigmaDbContext _dbContext;

        public PedidoRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> CriarNovoPedido(Pedido pedido)
        {
            _dbContext.Pedidos.Add(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido.IDPedido; // Retorna o ID do pedido criado
        }

        public async Task<IEnumerable<Pedido>> ObterTodosPedidos()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }

        public async Task<Pedido> ObterPedidoPorId(int id)
        {
            return await _dbContext.Pedidos.FindAsync(id) ?? throw new ArgumentException("Pedido não encontrado.");
        }

        public async Task AtualizarPedido(Pedido pedido)
        {
            _dbContext.Entry(pedido).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemPedido>> ObterItensDoPedido(int idPedido)
        {
            return await _dbContext.ItensPedidos.Where(i => i.IDPedido == idPedido).ToListAsync();
        }

        public async Task AdicionarItemAoPedido(int idPedido, ItemPedido itemPedido)
        {
            var pedido = await _dbContext.Pedidos.Include(p => p.ItensPedidos).FirstOrDefaultAsync(p => p.IDPedido == idPedido);
            if (pedido != null)
            {
                if (pedido.ItensPedidos == null)
                {
                    pedido.ItensPedidos = new List<ItemPedido>(); // Inicialize a lista se for nula
                }
                pedido.ItensPedidos.Add(itemPedido);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DesabilitarPedido(int id)
        {
            var pedido = await _dbContext.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                pedido.Ativo = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task HabilitarPedido(int id)
        {
            var pedido = await _dbContext.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                pedido.Ativo = true;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
