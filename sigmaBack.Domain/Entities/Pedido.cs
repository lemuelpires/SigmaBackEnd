using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class Pedido
    {
        public int IDPedido { get; set; }
        public int IDUsuario { get; set; }
        public DateTime DataPedido { get; set; }
        public string? StatusPedido { get; set; }
        public decimal TotalPedido { get; set; }
        public string? MetodoPagamento { get; set; }
        public string? EnderecoEntrega { get; set; }
        public string? DetalhesEnvio { get; set; }
        public ICollection<ItemPedido>? ItensPedidos { get; set; }
        public bool Ativo { get; set; }

        public Pedido() { }

        public Pedido(int idUsuario, DateTime dataPedido, string statusPedido, decimal totalPedido, string metodoPagamento, string enderecoEntrega, string detalhesEnvio, bool ativo)
        {
            ValidationDomain(idUsuario, dataPedido, statusPedido, totalPedido, metodoPagamento, enderecoEntrega, detalhesEnvio);
            Ativo = ativo;
        }

        public Pedido(int idPedido, int idUsuario, DateTime dataPedido, string statusPedido, decimal totalPedido, string metodoPagamento, string enderecoEntrega, string detalhesEnvio, bool ativo)
        {
            IDPedido = idPedido;
            ValidationDomain(idUsuario, dataPedido, statusPedido, totalPedido, metodoPagamento, enderecoEntrega, detalhesEnvio);
            Ativo = ativo;
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

        public void Update(int idPedido, int idUsuario, DateTime dataPedido, string statusPedido, decimal totalPedido, string metodoPagamento, string enderecoEntrega, string detalhesEnvio, bool ativo)
        {
            ValidationDomain(idUsuario, dataPedido, statusPedido, totalPedido, metodoPagamento, enderecoEntrega, detalhesEnvio);
            IDPedido = idPedido;
            Ativo = ativo;
        }
    }
}
