using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigmaBack.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<int> CriarPedido(Pedido pedido)
        {
            // Implemente aqui a lógica para criar um novo pedido
            return await _pedidoRepository.CriarNovoPedido(pedido);
        }

        public async Task<Pedido> ObterPedidoPorId(int id)
        {
            // Implemente aqui a lógica para obter um pedido por ID
            return await _pedidoRepository.ObterPedidoPorId(id);
        }

        public async Task<IEnumerable<Pedido>> ObterTodosPedidos()
        {
            // Implemente aqui a lógica para obter todos os pedidos
            return await _pedidoRepository.ObterTodosPedidos();
        }

        public async Task RemoverPedido(int id)
        {
            // Implemente aqui a lógica para remover um pedido
            await _pedidoRepository.RemoverPedido(id);
        }

        public async Task AtualizarPedido(int id, Pedido pedido)
        {
            // Implemente aqui a lógica para atualizar um pedido
            await _pedidoRepository.AtualizarPedido(pedido);
        }
    }
}

