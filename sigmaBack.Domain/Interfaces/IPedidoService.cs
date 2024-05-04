using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> ObterTodosPedidos();
        Task<Pedido> ObterPedidoPorId(int id);
        Task<int> CriarPedido(Pedido pedido);
        Task AtualizarPedido(int id, Pedido pedido);
        Task HabilitarPedido(int id);
        Task DesabilitarPedido(int id);
    }
}
