using Xunit;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Test
{
    public class PedidoTests
    {
        [Fact]
        public void Pedido_ComCamposCorretos_DeveSerCriado()
        {
            // Arrange
            int idUsuario = 1;
            var dataPedido = new System.DateTime(2024, 4, 19);
            string statusPedido = "Em andamento";
            decimal totalPedido = 100.00m;
            string metodoPagamento = "Cartão de crédito";
            string enderecoEntrega = "Rua Exemplo, 123";
            string detalhesEnvio = "Deixar na portaria";

            // Act
            var pedido = new Pedido(idUsuario, dataPedido, statusPedido, totalPedido, metodoPagamento, enderecoEntrega, detalhesEnvio);

            // Assert
            Assert.NotNull(pedido);
            Assert.Equal(idUsuario, pedido.IDUsuario);
            Assert.Equal(dataPedido, pedido.DataPedido);
            Assert.Equal(statusPedido, pedido.StatusPedido);
            Assert.Equal(totalPedido, pedido.TotalPedido);
            Assert.Equal(metodoPagamento, pedido.MetodoPagamento);
            Assert.Equal(enderecoEntrega, pedido.EnderecoEntrega);
            Assert.Equal(detalhesEnvio, pedido.DetalhesEnvio);
        }

        [Theory]
        [InlineData(-1, "2024-04-19", "Em andamento", 100.00, "Cartão de crédito", "Rua Exemplo, 123", "Deixar na portaria")]
        // Adicione mais casos de teste com campos obrigatórios em branco
        public void Pedido_ComCampoObrigatorioEmBrancoOuInvalido_DeveLancarExcecao(int idUsuario, string dataPedido, string statusPedido, decimal totalPedido, string metodoPagamento, string enderecoEntrega, string detalhesEnvio)
        {
            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Pedido(idUsuario, System.DateTime.Parse(dataPedido), statusPedido, totalPedido, metodoPagamento, enderecoEntrega, detalhesEnvio));
        }

        // Adicione mais testes para outros cenários, como total do pedido negativo, status em branco, etc.
    }
}
//
