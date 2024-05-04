using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IItemCarrinhoRepository
    {
        Task<IEnumerable<ItemCarrinho>> ObterTodosItensCarrinho();
        Task<ItemCarrinho> ObterItemCarrinhoPorId(int id);
        Task<int> CriarNovoItemCarrinho(ItemCarrinho itemCarrinho);
        Task AtualizarItemCarrinho(ItemCarrinho itemCarrinho);
        Task HabilitarItemCarrinho(int id);
        Task DesabilitarItemCarrinho(int id);
    }
}

