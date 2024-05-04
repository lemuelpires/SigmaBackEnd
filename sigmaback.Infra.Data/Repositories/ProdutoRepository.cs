using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SigmaDbContext _dbContext;

        public ProdutoRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> ObterProdutoPorId(int id)
        {
            return await _dbContext.Produtos.FindAsync(id) ?? throw new ArgumentException("Produto não encontrado.");
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorCategoria(string categoria)
        {
            return await _dbContext.Produtos.Where(p => p.Categoria == categoria).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorPreco(decimal precoMin, decimal precoMax)
        {
            return await _dbContext.Produtos.Where(p => p.Preco >= precoMin && p.Preco <= precoMax).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosEmEstoque()
        {
            return await _dbContext.Produtos.Where(p => p.QuantidadeEstoque > 0).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> PesquisarProdutos(string termoPesquisa)
        {
            if (_dbContext == null || _dbContext.Produtos == null)
            {
                throw new NullReferenceException("_dbContext ou _dbContext.Produtos é nulo. Verifique se foram inicializados corretamente.");
            }

            return await _dbContext.Produtos
                .Where(p => p.NomeProduto != null && p.NomeProduto.Contains(termoPesquisa))
                .ToListAsync();
        }

        public async Task InserirProduto(Produto produto)
        {
            _dbContext.Produtos.Add(produto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AtualizarProduto(Produto produto)
        {
            _dbContext.Entry(produto).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DesabilitarProduto(int id)
        {
            var produto = await _dbContext.Produtos.FindAsync(id);
            if (produto != null)
            {
                produto.Ativo = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task HabilitarProduto(int id)
        {
            var produto = await _dbContext.Produtos.FindAsync(id);
            if (produto != null)
            {
                produto.Ativo = true;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
