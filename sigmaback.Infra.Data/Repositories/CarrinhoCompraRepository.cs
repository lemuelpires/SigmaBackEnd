using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using sigmaBack.Infra.Data.Contexts;

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
            return carrinho.IDCarrinho; // Supondo que o ID seja gerado automaticamente
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
            return await _dbContext.CarrinhosCompras.FindAsync(id);
        }

        public async Task RemoverCarrinho(int id)
        {
            var carrinho = await _dbContext.CarrinhosCompras.FindAsync(id);
            if (carrinho != null)
            {
                _dbContext.CarrinhosCompras.Remove(carrinho);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
