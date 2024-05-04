using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Application.Services
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
            return await _itemCarrinhoRepository.CriarNovoItemCarrinho(itemCarrinho);
        }

        public async Task AtualizarItemCarrinho(ItemCarrinho itemCarrinho)
        {
            await _itemCarrinhoRepository.AtualizarItemCarrinho(itemCarrinho);
        }

        public async Task DesabilitarItemCarrinho(int id)
        {
            var itemCarrinho = await _itemCarrinhoRepository.ObterItemCarrinhoPorId(id);
            if (itemCarrinho != null)
            {
                itemCarrinho.Ativo = false;
                await _itemCarrinhoRepository.AtualizarItemCarrinho(itemCarrinho);
            }
        }

        public async Task HabilitarItemCarrinho(int id)
        {
            var itemCarrinho = await _itemCarrinhoRepository.ObterItemCarrinhoPorId(id);
            if (itemCarrinho != null)
            {
                itemCarrinho.Ativo = true;
                await _itemCarrinhoRepository.AtualizarItemCarrinho(itemCarrinho);
            }
        }
    }
}
