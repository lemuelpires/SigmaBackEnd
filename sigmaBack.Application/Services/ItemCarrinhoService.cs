using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;

namespace SigmaBack.Application.Services
{
    public class ItemCarrinhoService : IItemCarrinhoService
    {
        private readonly IItemCarrinhoRepository _itemCarrinhoRepository;

        public ItemCarrinhoService(IItemCarrinhoRepository itemCarrinhoRepository)
        {
            _itemCarrinhoRepository = itemCarrinhoRepository ?? throw new ArgumentNullException(nameof(itemCarrinhoRepository));
        }

        public async Task<IEnumerable<ItemCarrinho>> ObterTodosItensCarrinho()
        {
            return await _itemCarrinhoRepository.ObterTodosItensCarrinho();
        }

        public async Task<ItemCarrinho> ObterItemCarrinhoPorId(int id)
        {
            return await _itemCarrinhoRepository.ObterItemCarrinhoPorId(id);
        }

        public async Task<int> AdicionarItemCarrinho(ItemCarrinho itemCarrinho)
        {
            if (itemCarrinho == null)
            {
                throw new ArgumentNullException(nameof(itemCarrinho));
            }

            // Implemente aqui a lógica para adicionar um novo item ao carrinho

            // Exemplo de implementação:
            return await _itemCarrinhoRepository.CriarNovoItemCarrinho(itemCarrinho);
        }

        public async Task AtualizarItemCarrinho(ItemCarrinho itemCarrinho)
        {
            if (itemCarrinho == null)
            {
                throw new ArgumentNullException(nameof(itemCarrinho));
            }

            // Implemente aqui a lógica para atualizar um item do carrinho

            // Exemplo de implementação:
            await _itemCarrinhoRepository.AtualizarItemCarrinho(itemCarrinho);
        }

        public async Task RemoverItemCarrinho(int id)
        {
            // Implemente aqui a lógica para remover um item do carrinho

            // Exemplo de implementação:
            await _itemCarrinhoRepository.RemoverItemCarrinho(id);
        }
    }
}
//
