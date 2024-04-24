using sigmaBack.Domain.Validation;
using System;

namespace sigmaBack.Domain.Entities
{
    public class Pedido
    {
        public int IDPedido { get; private set; }
        public int IDUsuario { get; private set; }
        public DateTime DataPedido { get; private set; }
        public string StatusPedido { get; private set; }
        public decimal TotalPedido { get; private set; }
        public string MetodoPagamento { get; private set; }
        public string EnderecoEntrega { get; private set; }
        public string DetalhesEnvio { get; private set; }
        public ICollection<ItemPedido> ItensPedidos { get; set; }

        public Pedido() { } // Construtor vazio protegido para o Entity Framework Core

        public Pedido(int idUsuario, DateTime dataPedido, string statusPedido, decimal totalPedido, string metodoPagamento, string enderecoEntrega, string detalhesEnvio)
        {
            ValidationDomain(idUsuario, dataPedido, statusPedido, totalPedido, metodoPagamento, enderecoEntrega, detalhesEnvio);
        }

        public Pedido(int idPedido, int idUsuario, DateTime dataPedido, string statusPedido, decimal totalPedido, string metodoPagamento, string enderecoEntrega, string detalhesEnvio)
        {
            IDPedido = idPedido;
            ValidationDomain(idUsuario, dataPedido, statusPedido, totalPedido, metodoPagamento, enderecoEntrega, detalhesEnvio);
        }

        private void ValidationDomain(int idUsuario, DateTime dataPedido, string statusPedido, decimal totalPedido, string metodoPagamento, string enderecoEntrega, string detalhesEnvio)
        {
            DomainExceptionValidation.When(idUsuario < 0, "O ID do usuário é obrigatório.");
            DomainExceptionValidation.When(dataPedido == default, "A data do pedido é obrigatória.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(statusPedido), "O status do pedido é obrigatório.");
            DomainExceptionValidation.When(totalPedido < 0, "O total do pedido é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(metodoPagamento), "O método de pagamento é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(enderecoEntrega), "O endereço de entrega é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(detalhesEnvio), "Os detalhes de envio são obrigatórios.");

            IDUsuario = idUsuario;
            DataPedido = dataPedido;
            StatusPedido = statusPedido;
            TotalPedido = totalPedido;
            MetodoPagamento = metodoPagamento;
            EnderecoEntrega = enderecoEntrega;
            DetalhesEnvio = detalhesEnvio;
        }

        public void Update(int idPedido, int idUsuario, DateTime dataPedido, string statusPedido, decimal totalPedido, string metodoPagamento, string enderecoEntrega, string detalhesEnvio)
        {
            ValidationDomain(idUsuario, dataPedido, statusPedido, totalPedido, metodoPagamento, enderecoEntrega, detalhesEnvio);
            IDPedido = idPedido;
        }
    }
}
