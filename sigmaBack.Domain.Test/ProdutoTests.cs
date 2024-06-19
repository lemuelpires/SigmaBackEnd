using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using System;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_DeveSerCriadoComCamposCorretos()
        {
            // Arrange
            string nomeProduto = "Produto A";
            string descricaoProduto = "Descrição do Produto A";
            decimal preco = 100.00m;
            int quantidadeEstoque = 10;
            string categoria = "Categoria A";
            string marca = "Marca A";
            string imagemProduto = "imagem-produto.jpg";
            string fichaTecnica = "Ficha Técnica do Produto A";
            DateTime data = DateTime.Now;
            bool ativo = true;

            // Act
            var produto = new Produto(nomeProduto, descricaoProduto, preco, quantidadeEstoque, categoria, marca, imagemProduto, fichaTecnica, data, ativo);

            // Assert
            Assert.NotNull(produto);
            Assert.Equal(nomeProduto, produto.NomeProduto);
            Assert.Equal(descricaoProduto, produto.DescricaoProduto);
            Assert.Equal(preco, produto.Preco);
            Assert.Equal(quantidadeEstoque, produto.QuantidadeEstoque);
            Assert.Equal(categoria, produto.Categoria);
            Assert.Equal(marca, produto.Marca);
            Assert.Equal(imagemProduto, produto.ImagemProduto);
            Assert.Equal(fichaTecnica, produto.FichaTecnica);
            Assert.Equal(data, produto.Data);
            Assert.Equal(ativo, produto.Ativo);
        }

        [Theory]
        [InlineData("", "Descrição do Produto A", 100.00, 10, "Categoria A", "Marca A", "imagem-produto.jpg", "Ficha Técnica do Produto A", "2023-01-01", true)]
        [InlineData("Produto A", "", 100.00, 10, "Categoria A", "Marca A", "imagem-produto.jpg", "Ficha Técnica do Produto A", "2023-01-01", true)]
        [InlineData("Produto A", "Descrição do Produto A", -100.00, 10, "Categoria A", "Marca A", "imagem-produto.jpg", "Ficha Técnica do Produto A", "2023-01-01", true)]
        // Adicione mais casos de teste conforme necessário para cobrir todas as validações da classe Produto
        public void Produto_ComCampoObrigatorioEmBrancoOuInvalido_DeveLancarExcecao(string nomeProduto, string descricaoProduto, decimal preco, int quantidadeEstoque, string categoria, string marca, string imagemProduto, string fichaTecnica, DateTime data, bool ativo)
        {
            // Assert
            Assert.Throws<DomainExceptionValidation>(() => new Produto(nomeProduto, descricaoProduto, preco, quantidadeEstoque, categoria, marca, imagemProduto, fichaTecnica, data, ativo));
        }

        [Fact]
        public void Produto_ComPrecoNegativo_DeveLancarExcecao()
        {
            // Arrange
            string nomeProduto = "Produto A";
            string descricaoProduto = "Descrição do Produto A";
            decimal preco = -100.00m;
            int quantidadeEstoque = 10;
            string categoria = "Categoria A";
            string marca = "Marca A";
            string imagemProduto = "imagem-produto.jpg";
            string fichaTecnica = "Ficha Técnica do Produto A";
            DateTime data = DateTime.Now;
            bool ativo = true;

            // Assert
            Assert.Throws<DomainExceptionValidation>(() => new Produto(nomeProduto, descricaoProduto, preco, quantidadeEstoque, categoria, marca, imagemProduto, fichaTecnica, data, ativo));
        }
    }
}
