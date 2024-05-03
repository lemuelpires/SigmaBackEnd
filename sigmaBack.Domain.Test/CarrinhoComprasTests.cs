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
            bool ativo = true;

            // Act
            var carrinhoCompra = new CarrinhoCompra(idUsuario, dataHoraCriacaoCarrinho, ativo);

            // Assert
            Assert.NotNull(carrinhoCompra);
            Assert.Equal(idUsuario, carrinhoCompra.IDUsuario);
            Assert.Equal(dataHoraCriacaoCarrinho, carrinhoCompra.DataHoraCriacaoCarrinho);
            Assert.Equal(ativo,carrinhoCompra.Ativo);       
        }

        [Fact]
        public void CarrinhoCompra_ComIDUsuarioInvalido_DeveLancarExcecao()
        {
            // Arrange
            int idUsuario = 0;
            DateTime dataHoraCriacaoCarrinho = DateTime.Now;
            bool ativo = true;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new CarrinhoCompra(idUsuario, dataHoraCriacaoCarrinho, ativo));
        }

        [Fact]
        public void CarrinhoCompra_ComDataHoraCriacaoCarrinhoInvalida_DeveLancarExcecao()
        {
            // Arrange
            int idUsuario = 1;
            DateTime dataHoraCriacaoCarrinho = default;
            bool ativo = true;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new CarrinhoCompra(idUsuario, dataHoraCriacaoCarrinho, ativo));
        }

        // Adicione mais testes conforme necessário para cobrir outros cenários
    }
}
//