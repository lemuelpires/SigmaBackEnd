using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> ObterTodosPedidos();
        Task<Pedido> ObterPedidoPorId(int id);
        Task<int> CriarNovoPedido(Pedido pedido);
        Task AtualizarPedido(Pedido pedido);
        Task<IEnumerable<ItemPedido>> ObterItensDoPedido(int idPedido);
        Task AdicionarItemAoPedido(int idPedido, ItemPedido itemPedido);
        Task DesabilitarPedido(int id);
        Task HabilitarPedido(int id);
    }
}

