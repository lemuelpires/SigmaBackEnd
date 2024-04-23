using System.Collections.Generic;
using System.Threading.Tasks;
using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> ObterTodosPedidos();
        Task<Pedido> ObterPedidoPorId(int id);
        Task<int> CriarNovoPedido(Pedido pedido);
        Task AtualizarPedido(Pedido pedido);
        Task RemoverPedido(int id);
        Task<IEnumerable<ItemPedido>> ObterItensDoPedido(int idPedido);
        Task AdicionarItemAoPedido(int idPedido, ItemPedido itemPedido);
        Task RemoverItemDoPedido(int idItemPedido);
    }
}

