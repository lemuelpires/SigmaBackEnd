// Interface IItemPedidoService
using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IItemPedidoService
    {
        Task<IEnumerable<ItemPedido>> ObterTodosItensPedido();
        Task<ItemPedido> ObterItemPedidoPorId(int id);
        Task<int> CriarNovoItemPedido(ItemPedido itemPedido);
        Task AtualizarItemPedido(int id, ItemPedido itemPedido); // Corrigido para aceitar o ID do item
        Task RemoverItemPedido(int id);
    }
}
