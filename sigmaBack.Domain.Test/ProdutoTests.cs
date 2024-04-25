using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sigmaBack.Domain;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Test
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_ComCamposCorretos_DeveSerCriado()
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

            // Act
            var produto = new Produto(nomeProduto, descricaoProduto, preco, quantidadeEstoque, categoria, marca, imagemProduto, fichaTecnica);

            // Assert
            Assert.NotNull(produto);
        }

        [Theory]
        [InlineData("", "Descrição do Produto A", 100.00, 10, "Categoria A", "Marca A", "imagem-produto.jpg", "Ficha Técnica do Produto A")]
        public void Produto_ComCampoObrigatorioEmBranco_DeveLancarExcecao(string nomeProduto, string descricaoProduto, decimal preco, int quantidadeEstoque, string categoria, string marca, string imagemProduto, string fichaTecnica)
        {
            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Produto(nomeProduto, descricaoProduto, preco, quantidadeEstoque, categoria, marca, imagemProduto, fichaTecnica));
        }

        [Fact]
        public void Produto_ComPrecoNegativo_DeveLancarExcecao()
        {
            // Arrange
            string nomeProduto = "Produto A";
            string descricaoProduto = "Descrição do Produto A";
            decimal preco = -100.00m; // Preço negativo
            int quantidadeEstoque = 10;
            string categoria = "Categoria A";
            string marca = "Marca A";
            string imagemProduto = "imagem-produto.jpg";
            string fichaTecnica = "Ficha Técnica do Produto A";

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Produto(nomeProduto, descricaoProduto, preco, quantidadeEstoque, categoria, marca, imagemProduto, fichaTecnica));
        }
    }
}
//