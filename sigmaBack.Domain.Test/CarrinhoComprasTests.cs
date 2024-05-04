using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class CarrinhoCompraTests
    {
        [Fact]
        public void CarrinhoCompra_ComParametrosValidos_DeveSerCriado()
        {
            int idUsuario = 1;
            DateTime dataHoraCriacaoCarrinho = DateTime.Now;
            bool ativo = true;

            var carrinhoCompra = new CarrinhoCompra(idUsuario, dataHoraCriacaoCarrinho, ativo);

            Assert.NotNull(carrinhoCompra);
            Assert.Equal(idUsuario, carrinhoCompra.IDUsuario);
            Assert.Equal(dataHoraCriacaoCarrinho, carrinhoCompra.DataHoraCriacaoCarrinho);
            Assert.Equal(ativo, carrinhoCompra.Ativo);
        }

        [Fact]
        public void CarrinhoCompra_ComIDUsuarioInvalido_DeveLancarExcecao()
        {
            int idUsuario = 0;
            DateTime dataHoraCriacaoCarrinho = DateTime.Now;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new CarrinhoCompra(idUsuario, dataHoraCriacaoCarrinho, ativo));
        }

        [Fact]
        public void CarrinhoCompra_ComDataHoraCriacaoCarrinhoInvalida_DeveLancarExcecao()
        {
            int idUsuario = 1;
            DateTime dataHoraCriacaoCarrinho = default;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new CarrinhoCompra(idUsuario, dataHoraCriacaoCarrinho, ativo));
        }
    }
}
