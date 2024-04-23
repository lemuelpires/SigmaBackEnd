using Xunit;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Test
{
    public class ItemPedidoTests
    {
        [Fact]
        public void ItemPedido_Construtor_DeveInicializarCorretamente()
        {
            // Arrange
            int idPedido = 1;
            int idProduto = 1;
            int quantidade = 2;
            decimal precoUnitario = 50.00m;

            // Act
            var itemPedido = new ItemPedido(idPedido, idProduto, quantidade, precoUnitario);

            // Assert
            Assert.NotNull(itemPedido);
            Assert.Equal(idPedido, itemPedido.IDPedido);
            Assert.Equal(idProduto, itemPedido.IDProduto);
            Assert.Equal(quantidade, itemPedido.Quantidade);
            Assert.Equal(precoUnitario, itemPedido.PrecoUnitario);
        }

        [Fact]
        public void ItemPedido_ConstrutorComDescricao_DeveInicializarCorretamente()
        {
            // Arrange
            int idItemPedido = 1;
            int idPedido = 1;
            int idProduto = 1;
            int quantidade = 2;
            decimal precoUnitario = 50.00m;
            string urlImagem = "url_da_imagem";
            string descricaoProduto = "Descrição do produto";

            // Act
            var itemPedido = new ItemPedido(idItemPedido, idPedido, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto);

            // Assert
            Assert.NotNull(itemPedido);
            Assert.Equal(idItemPedido, itemPedido.IDItemPedido);
            Assert.Equal(idPedido, itemPedido.IDPedido);
            Assert.Equal(idProduto, itemPedido.IDProduto);
            Assert.Equal(quantidade, itemPedido.Quantidade);
            Assert.Equal(precoUnitario, itemPedido.PrecoUnitario);
            Assert.Equal(urlImagem, itemPedido.URLImagem);
            Assert.Equal(descricaoProduto, itemPedido.DescricaoProduto);
        }

        [Theory]
        [InlineData(-1, 1, 2, 50.00, "url_da_imagem", "Descrição do produto")]
        [InlineData(1, -1, 2, 50.00, "url_da_imagem", "Descrição do produto")]
        [InlineData(1, 1, -2, 50.00, "url_da_imagem", "Descrição do produto")]
        [InlineData(1, 1, 2, -50.00, "url_da_imagem", "Descrição do produto")]
        [InlineData(1, 1, 2, 50.00, "", "Descrição do produto")]
        [InlineData(1, 1, 2, 50.00, "url_da_imagem", "")]
        public void ItemPedido_Construtor_ComArgumentosInvalidos_DeveLancarExcecao(int idPedido, int idProduto, int quantidade, decimal precoUnitario, string urlImagem, string descricaoProduto)
        {
            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new ItemPedido(1, idPedido, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto));
        }

        [Fact]
        public void ItemPedido_Update_DeveAtualizarCorretamente()
        {
            // Arrange
            var itemPedido = new ItemPedido(1, 1, 1, 2, 50.00m, "url_da_imagem", "Descrição do produto");
            int idItemPedido = 2;
            int idPedido = 2;
            int idProduto = 2;
            int quantidade = 3;
            decimal precoUnitario = 75.00m;
            string urlImagem = "nova_url_da_imagem";
            string descricaoProduto = "Nova descrição do produto";

            // Act
            itemPedido.Update(idItemPedido, idPedido, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto);

            // Assert
            Assert.Equal(idItemPedido, itemPedido.IDItemPedido);
            Assert.Equal(idPedido, itemPedido.IDPedido);
            Assert.Equal(idProduto, itemPedido.IDProduto);
            Assert.Equal(quantidade, itemPedido.Quantidade);
            Assert.Equal(precoUnitario, itemPedido.PrecoUnitario);
            Assert.Equal(urlImagem, itemPedido.URLImagem);
            Assert.Equal(descricaoProduto, itemPedido.DescricaoProduto);
        }
    }
}
