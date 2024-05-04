using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Application.Services
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public ItemPedidoService(IItemPedidoRepository itemPedidoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository ?? throw new ArgumentNullException(nameof(itemPedidoRepository));
        }

        public async Task<IEnumerable<ItemPedido>> ObterTodosItensPedido()
        {
            return await _itemPedidoRepository.ObterTodosItensPedido();
        }

        public async Task<ItemPedido> ObterItemPedidoPorId(int id)
        {
            return await _itemPedidoRepository.ObterItemPedidoPorId(id);
        }

        public async Task<int> CriarNovoItemPedido(ItemPedido itemPedido)
        {
            return await _itemPedidoRepository.CriarNovoItemPedido(itemPedido);
        }

        public async Task AtualizarItemPedido(int id, ItemPedido itemPedido)
        {
            await _itemPedidoRepository.AtualizarItemPedido(itemPedido);
        }

        public async Task HabilitarItemPedido(int id)
        {
            await _itemPedidoRepository.HabilitarItemPedido(id);
        }

        public async Task DesabilitarItemPedido(int id)
        {
            await _itemPedidoRepository.DesabilitarItemPedido(id);
        }
    }
}
