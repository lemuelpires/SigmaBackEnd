using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutos()
        {
            return await _produtoRepository.ObterTodosProdutos();
        }

        public async Task<Produto> ObterProdutoPorId(int id)
        {
            return await _produtoRepository.ObterProdutoPorId(id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorCategoria(string categoria)
        {
            return await _produtoRepository.ObterProdutosPorCategoria(categoria);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorPreco(decimal precoMin, decimal precoMax)
        {
            return await _produtoRepository.ObterProdutosPorPreco(precoMin, precoMax);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosEmEstoque()
        {
            return await _produtoRepository.ObterProdutosEmEstoque();
        }

        public async Task<IEnumerable<Produto>> PesquisarProdutos(string termoPesquisa)
        {
            return await _produtoRepository.PesquisarProdutos(termoPesquisa);
        }

        public async Task InserirProduto(Produto produto)
        {
            await _produtoRepository.InserirProduto(produto);
        }

        public async Task AtualizarProduto(Produto produto)
        {
            await _produtoRepository.AtualizarProduto(produto);
        }

        public async Task HabilitarProduto(int id)
        {
            await _produtoRepository.HabilitarProduto(id);
        }

        public async Task DesabilitarProduto(int id)
        {
            await _produtoRepository.DesabilitarProduto(id);
        }

        public async Task AplicarDescontoPromocional(int idProduto, decimal percentualDesconto)
        {
            await Task.Delay(1000);
        }

        public async Task VerificarDisponibilidadeEstoque(int idProduto, int quantidadeDesejada)
        {
            await Task.Delay(1000);
        }
    }
}
