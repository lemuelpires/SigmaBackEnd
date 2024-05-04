using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Infra.Data.Repositories
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private readonly SigmaDbContext _dbContext;

        public CarrinhoCompraRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> CriarNovoCarrinho(CarrinhoCompra carrinho)
        {
            _dbContext.CarrinhosCompras.Add(carrinho);
            await _dbContext.SaveChangesAsync();
            return carrinho.IDCarrinho;
        }

        public async Task AtualizarCarrinho(CarrinhoCompra carrinho)
        {
            _dbContext.CarrinhosCompras.Update(carrinho);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarrinhoCompra>> ObterTodosCarrinhos()
        {
            return await _dbContext.CarrinhosCompras.ToListAsync();
        }

        public async Task<CarrinhoCompra> ObterCarrinhoPorId(int id)
        {
            return await _dbContext.CarrinhosCompras.FindAsync(id) ?? throw new ArgumentException("Carrinho não encontrado.");
        }

        public async Task HabilitarCarrinho(int id)
        {
            var carrinho = await _dbContext.CarrinhosCompras.FindAsync(id);
            if (carrinho != null)
            {
                carrinho.Ativo = true;
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DesabilitarCarrinho(int id)
        {
            var carrinho = await _dbContext.CarrinhosCompras.FindAsync(id);
            if (carrinho != null)
            {
                carrinho.Ativo = false;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
