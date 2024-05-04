using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IItemPedidoRepository
    {
        Task<IEnumerable<ItemPedido>> ObterTodosItensPedido();
        Task<ItemPedido> ObterItemPedidoPorId(int id);
        Task<int> CriarNovoItemPedido(ItemPedido itemPedido);
        Task AtualizarItemPedido(ItemPedido itemPedido);
        Task HabilitarItemPedido(int id);
        Task DesabilitarItemPedido(int id);
    }
}

