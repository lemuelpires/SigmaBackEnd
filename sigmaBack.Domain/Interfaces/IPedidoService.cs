// Na interface IPedidoService, adicione o método CriarPedido
using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> ObterTodosPedidos();
        Task<Pedido> ObterPedidoPorId(int id);
        Task<int> CriarPedido(Pedido pedido); // Adicionado o método CriarPedido
        Task AtualizarPedido(int id, Pedido pedido); // Corrigido para aceitar o ID do pedido
        Task RemoverPedido(int id);
    }
}
