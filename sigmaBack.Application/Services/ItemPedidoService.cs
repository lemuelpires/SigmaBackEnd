// ItemPedidoService
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;

namespace SigmaBack.Application.Services
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
            if (itemPedido == null)
            {
                throw new ArgumentNullException(nameof(itemPedido));
            }

            // Implemente aqui a lógica para criar um novo item de pedido

            // Exemplo de implementação:
            return await _itemPedidoRepository.CriarNovoItemPedido(itemPedido);
        }

        public async Task AtualizarItemPedido(int id, ItemPedido itemPedido)
        {
            if (itemPedido == null)
            {
                throw new ArgumentNullException(nameof(itemPedido));
            }

            // Implemente aqui a lógica para atualizar um item de pedido

            // Exemplo de implementação:
            await _itemPedidoRepository.AtualizarItemPedido(itemPedido);
        }

        public async Task RemoverItemPedido(int id)
        {
            // Implemente aqui a lógica para remover um item de pedido

            // Exemplo de implementação:
            await _itemPedidoRepository.RemoverItemPedido(id);
        }
    }
}
//