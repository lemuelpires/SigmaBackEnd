using Xunit;
using sigmaBack.Domain.Entities;
using System;
using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Test
{
    public class CarrinhoCompraTests
    {
        [Fact]
        public void CarrinhoCompra_ComParametrosValidos_DeveSerCriado()
        {
            // Arrange
            int idUsuario = 1;
            DateTime dataHoraCriacaoCarrinho = DateTime.Now;

            // Act
            var carrinhoCompra = new CarrinhoCompra(idUsuario, dataHoraCriacaoCarrinho);

            // Assert
            Assert.NotNull(carrinhoCompra);
            Assert.Equal(idUsuario, carrinhoCompra.IDUsuario);
            Assert.Equal(dataHoraCriacaoCarrinho, carrinhoCompra.DataHoraCriacaoCarrinho);
        }

        [Fact]
        public void CarrinhoCompra_ComIDUsuarioInvalido_DeveLancarExcecao()
        {
            // Arrange
            int idUsuario = 0;
            DateTime dataHoraCriacaoCarrinho = DateTime.Now;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new CarrinhoCompra(idUsuario, dataHoraCriacaoCarrinho));
        }

        [Fact]
        public void CarrinhoCompra_ComDataHoraCriacaoCarrinhoInvalida_DeveLancarExcecao()
        {
            // Arrange
            int idUsuario = 1;
            DateTime dataHoraCriacaoCarrinho = default;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new CarrinhoCompra(idUsuario, dataHoraCriacaoCarrinho));
        }

        // Adicione mais testes conforme necessário para cobrir outros cenários
    }
}
