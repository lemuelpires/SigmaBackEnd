using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Application.Services
{
    public class CarrinhoCompraService : ICarrinhoCompraService
    {
        private readonly ICarrinhoCompraRepository _carrinhoRepository;

        public CarrinhoCompraService(ICarrinhoCompraRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public async Task<int> CriarNovoCarrinho(CarrinhoCompra carrinho)
        {
            if (carrinho == null)
            {
                throw new ArgumentNullException(nameof(carrinho));
            }

            return await _carrinhoRepository.CriarNovoCarrinho(carrinho);
        }

        public async Task AtualizarCarrinho(CarrinhoCompra carrinho)
        {
            if (carrinho == null)
            {
                throw new ArgumentNullException(nameof(carrinho));
            }

            await _carrinhoRepository.AtualizarCarrinho(carrinho);
        }

        public async Task<IEnumerable<CarrinhoCompra>> ObterTodosCarrinhos()
        {
            return await _carrinhoRepository.ObterTodosCarrinhos();
        }

        public async Task<CarrinhoCompra> ObterCarrinhoPorId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID do carrinho deve ser maior que zero.");
            }

            return await _carrinhoRepository.ObterCarrinhoPorId(id);
        }

        public async Task RemoverCarrinho(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID do carrinho deve ser maior que zero.");
            }

            await _carrinhoRepository.RemoverCarrinho(id);
        }
    }
}
