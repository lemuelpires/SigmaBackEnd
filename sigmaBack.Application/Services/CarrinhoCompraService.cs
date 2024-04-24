using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using sigmaBack.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sigmaBack.Application.Services
{
    public class CarrinhoCompraService : ICarrinhoCompraService
    {
        private readonly SigmaDbContext _context;

        public CarrinhoCompraService(SigmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarrinhoCompra>> ObterTodosCarrinhos()
        {
            return await _context.CarrinhosCompras.ToListAsync();
        }

        public async Task<CarrinhoCompra> ObterCarrinhoPorId(int id)
        {
            return await _context.CarrinhosCompras.FindAsync(id);
        }

        public async Task<int> CriarNovoCarrinho(CarrinhoCompra carrinho)
        {
            _context.CarrinhosCompras.Add(carrinho);
            await _context.SaveChangesAsync();
            return carrinho.IDCarrinho;
        }

        public async Task AtualizarCarrinho(CarrinhoCompra carrinho)
        {
            _context.Entry(carrinho).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverCarrinho(int id)
        {
            var carrinho = await _context.CarrinhosCompras.FindAsync(id);
            if (carrinho == null)
            {
                throw new ArgumentException("Carrinho não encontrado.");
            }

            _context.CarrinhosCompras.Remove(carrinho);
            await _context.SaveChangesAsync();
        }
    }
}
