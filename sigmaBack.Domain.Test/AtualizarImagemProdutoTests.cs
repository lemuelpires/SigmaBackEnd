using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class AtualizarImagemProdutoTests
    {
        [Fact]
        public void AtualizarImagemProduto_DeveSerCriadoComCamposCorretos()
        {
            // Arrange
            int idProduto = 1;
            string imagemProduto = "nova-imagem-produto.jpg";

            // Act
            var atualizarImagemProduto = new AtualizarImagemProduto
            {
                IdProduto = idProduto,
                ImagemProduto = imagemProduto
            };

            // Assert
            Assert.NotNull(atualizarImagemProduto);
            Assert.Equal(idProduto, atualizarImagemProduto.IdProduto);
            Assert.Equal(imagemProduto, atualizarImagemProduto.ImagemProduto);
        }

        [Fact]
        public void AtualizarImagemProduto_ComImagemProdutoNula_DevePermitir()
        {
            // Arrange
            int idProduto = 1;

            // Act
            var atualizarImagemProduto = new AtualizarImagemProduto
            {
                IdProduto = idProduto,
                ImagemProduto = null
            };

            // Assert
            Assert.NotNull(atualizarImagemProduto);
            Assert.Equal(idProduto, atualizarImagemProduto.IdProduto);
            Assert.Null(atualizarImagemProduto.ImagemProduto);
        }

        [Fact]
        public void AtualizarImagemProduto_ComIdProdutoNegativo_DeveLancarExcecao()
        {
            // Arrange
            int idProduto = -1;
            string imagemProduto = "nova-imagem-produto.jpg";

            // Assert & Act
            Assert.Throws<DomainExceptionValidation>(() => new AtualizarImagemProduto
            {
                IdProduto = idProduto,
                ImagemProduto = imagemProduto
            });
        }
    }
}
