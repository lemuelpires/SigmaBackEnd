using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository ?? throw new ArgumentNullException(nameof(pedidoRepository));
        }

        public async Task<IEnumerable<Pedido>> ObterTodosPedidos()
        {
            return await _pedidoRepository.ObterTodosPedidos();
        }

        public async Task<Pedido> ObterPedidoPorId(int id)
        {
            return await _pedidoRepository.ObterPedidoPorId(id);
        }

        public async Task<int> CriarPedido(Pedido pedido)
        {
            return await _pedidoRepository.CriarNovoPedido(pedido);
        }

        public async Task AtualizarPedido(int id, Pedido pedido)
        {
            var pedidoExistente = await _pedidoRepository.ObterPedidoPorId(id);
            if (pedidoExistente == null)
            {
                throw new ArgumentException("Pedido não encontrado.");
            }

            pedidoExistente.DataPedido = pedido.DataPedido;
            pedidoExistente.IDPedido = pedido.IDPedido;

            await _pedidoRepository.AtualizarPedido(pedidoExistente);
        }

        public async Task HabilitarPedido(int id)
        {
            var pedido = await _pedidoRepository.ObterPedidoPorId(id);
            if (pedido == null)
            {
                throw new ArgumentException("Pedido não encontrado.");
            }

            pedido.Ativo = true;
            await _pedidoRepository.AtualizarPedido(pedido);
        }

        public async Task DesabilitarPedido(int id)
        {
            var pedido = await _pedidoRepository.ObterPedidoPorId(id);
            if (pedido == null)
            {
                throw new ArgumentException("Pedido não encontrado.");
            }

            pedido.Ativo = false;
            await _pedidoRepository.AtualizarPedido(pedido);
        }
    }
}
