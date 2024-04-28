using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using Xunit;

namespace sigmaBack.Tests
{
    public class CategoriaTests
    {
        [Fact]
        public void Categoria_CriacaoComNome_Valido()
        {
            // Arrange
            string nomeCategoria = "Eletrônicos";

            // Act
            var categoria = new Categoria(nomeCategoria);

            // Assert
            Assert.Equal(nomeCategoria, categoria.NomeCategoria);
        }

        [Fact]
        public void Categoria_AtualizacaoComNovoNome_Valido()
        {
            // Arrange
            string nomeCategoria = "Eletrônicos";
            string novoNomeCategoria = "Informática";
            var categoria = new Categoria(nomeCategoria);

            // Act
            categoria.Update(novoNomeCategoria);

            // Assert
            Assert.Equal(novoNomeCategoria, categoria.NomeCategoria);
        }

        [Fact]
        public void Categoria_AtualizacaoComNovoNome_NuloOuVazio_DeveLancarExcecao()
        {
            // Arrange
            string nomeCategoria = "Eletrônicos";
            string? novoNomeCategoria = null; // Declarado como anulável

            var categoria = new Categoria(nomeCategoria);

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => categoria.Update(novoNomeCategoria));
        }
    }
}
