using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class ItemCarrinhoTests
    {
        [Fact]
        public void ItemCarrinho_ComCamposCorretos_DeveSerCriado()
        {
            int idCarrinho = 1;
            int idProduto = 1;
            int quantidade = 2;
            decimal precoUnitario = 50.00m;
            string urlImagem = "imagem-produto.jpg";
            string descricaoProduto = "Descrição do Produto";

            var itemCarrinho = new ItemCarrinho(idCarrinho, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto, true);

            Assert.NotNull(itemCarrinho);
            Assert.Equal(idCarrinho, itemCarrinho.IDCarrinho);
            Assert.Equal(idProduto, itemCarrinho.IDProduto);
            Assert.Equal(quantidade, itemCarrinho.Quantidade);
            Assert.Equal(precoUnitario, itemCarrinho.PrecoUnitario);
            Assert.Equal(urlImagem, itemCarrinho.URLImagem);
            Assert.Equal(descricaoProduto, itemCarrinho.DescricaoProduto);
            Assert.True(itemCarrinho.Ativo);
        }

        [Theory]
        [InlineData(-1, 1, 2, 50.00, "imagem-produto.jpg", "Descrição do Produto")]
        public void ItemCarrinho_ComCampoObrigatorioEmBrancoOuInvalido_DeveLancarExcecao(int idCarrinho, int idProduto, int quantidade, decimal precoUnitario, string urlImagem, string descricaoProduto)
        {
            Assert.Throws<DomainExceptionValidation>(() => new ItemCarrinho(idCarrinho, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto, true));
        }
    }
}
