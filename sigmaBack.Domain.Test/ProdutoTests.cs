using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_ComCamposCorretos_DeveSerCriado()
        {
            string nomeProduto = "Produto A";
            string descricaoProduto = "Descrição do Produto A";
            decimal preco = 100.00m;
            int quantidadeEstoque = 10;
            string categoria = "Categoria A";
            string marca = "Marca A";
            string imagemProduto = "imagem-produto.jpg";
            string fichaTecnica = "Ficha Técnica do Produto A";
            bool ativo = true;

            var produto = new Produto(nomeProduto, descricaoProduto, preco, quantidadeEstoque, categoria, marca, imagemProduto, fichaTecnica, ativo);

            Assert.NotNull(produto);
            Assert.Equal(nomeProduto, produto.NomeProduto);
            Assert.Equal(descricaoProduto, produto.DescricaoProduto);
            Assert.Equal(preco, produto.Preco);
            Assert.Equal(quantidadeEstoque, produto.QuantidadeEstoque);
            Assert.Equal(categoria, produto.Categoria);
            Assert.Equal(marca, produto.Marca);
            Assert.Equal(imagemProduto, produto.ImagemProduto);
            Assert.Equal(fichaTecnica, produto.FichaTecnica);
            Assert.Equal(ativo, produto.Ativo);
        }

        [Theory]
        [InlineData("", "Descrição do Produto A", 100.00, 10, "Categoria A", "Marca A", "imagem-produto.jpg", "Ficha Técnica do Produto A", true)]
        public void Produto_ComCampoObrigatorioEmBranco_DeveLancarExcecao(string nomeProduto, string descricaoProduto, decimal preco, int quantidadeEstoque, string categoria, string marca, string imagemProduto, string fichaTecnica, bool ativo)
        {
            Assert.Throws<DomainExceptionValidation>(() => new Produto(nomeProduto, descricaoProduto, preco, quantidadeEstoque, categoria, marca, imagemProduto, fichaTecnica, ativo));
        }

        [Fact]
        public void Produto_ComPrecoNegativo_DeveLancarExcecao()
        {
            string nomeProduto = "Produto A";
            string descricaoProduto = "Descrição do Produto A";
            decimal preco = -100.00m;
            int quantidadeEstoque = 10;
            string categoria = "Categoria A";
            string marca = "Marca A";
            string imagemProduto = "imagem-produto.jpg";
            string fichaTecnica = "Ficha Técnica do Produto A";
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new Produto(nomeProduto, descricaoProduto, preco, quantidadeEstoque, categoria, marca, imagemProduto, fichaTecnica, ativo));
        }
    }
}
