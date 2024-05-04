using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface ICarrinhoCompraRepository
    {
        Task<IEnumerable<CarrinhoCompra>> ObterTodosCarrinhos();
        Task<CarrinhoCompra> ObterCarrinhoPorId(int id);
        Task<int> CriarNovoCarrinho(CarrinhoCompra carrinho);
        Task AtualizarCarrinho(CarrinhoCompra carrinho);
        Task HabilitarCarrinho(int id);
        Task DesabilitarCarrinho(int id);
    }
}
