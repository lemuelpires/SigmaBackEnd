using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class FavoritoTests
    {
        [Fact]
        public void Favorito_DeveSerCriadoComCamposCorretos()
        {
            // Arrange
            int idUsuario = 1;
            int idProduto = 2;
            string imagemProduto = "imagem-produto.jpg";
            bool ativo = true;

            // Act
            var favorito = new Favorito(idUsuario, idProduto, imagemProduto, ativo);

            // Assert
            Assert.NotNull(favorito);
            Assert.Equal(idUsuario, favorito.IDUsuario);
            Assert.Equal(idProduto, favorito.IDProduto);
            Assert.Equal(imagemProduto, favorito.ImagemProduto);
            Assert.True(favorito.Ativo);
        }

        [Theory]
        [InlineData(-1, 2, "imagem-produto.jpg", true)]
        [InlineData(1, -2, "imagem-produto.jpg", true)]
        [InlineData(1, 2, "", true)]
        public void Favorito_ComCampoObrigatorioEmBrancoOuInvalido_DeveLancarExcecao(int idUsuario, int idProduto, string imagemProduto, bool ativo)
        {
            // Assert
            Assert.Throws<DomainExceptionValidation>(() => new Favorito(idUsuario, idProduto, imagemProduto, ativo));
        }

        [Fact]
        public void Favorito_Update_ComParametrosValidos_DeveAtualizar()
        {
            // Arrange
            var favorito = new Favorito(1, 2, "imagem-produto.jpg", true);

            int idFavorito = 10;
            int idUsuario = 3;
            int idProduto = 4;
            string imagemProduto = "nova-imagem-produto.jpg";
            bool ativo = false;

            // Act
            favorito.Update(idFavorito, idUsuario, idProduto, imagemProduto, ativo);

            // Assert
            Assert.Equal(idFavorito, favorito.IDFavorito);
            Assert.Equal(idUsuario, favorito.IDUsuario);
            Assert.Equal(idProduto, favorito.IDProduto);
            Assert.Equal(imagemProduto, favorito.ImagemProduto);
            Assert.False(favorito.Ativo);
        }
    }
}
