using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class AtualizarImagemJogoTests
    {
        [Fact]
        public void AtualizarImagemJogo_DeveSerCriadoComCamposCorretos()
        {
            // Arrange
            int idJogo = 1;
            string referenciaImagemJogo = "nova-imagem-jogo.jpg";

            // Act
            var atualizarImagemJogo = new AtualizarImagemJogo
            {
                IdJogo = idJogo,
                ReferenciaImagemJogo = referenciaImagemJogo
            };

            // Assert
            Assert.NotNull(atualizarImagemJogo);
            Assert.Equal(idJogo, atualizarImagemJogo.IdJogo);
            Assert.Equal(referenciaImagemJogo, atualizarImagemJogo.ReferenciaImagemJogo);
        }

        [Fact]
        public void AtualizarImagemJogo_ComReferenciaImagemJogoNula_DevePermitir()
        {
            // Arrange
            int idJogo = 1;

            // Act
            var atualizarImagemJogo = new AtualizarImagemJogo
            {
                IdJogo = idJogo,
                ReferenciaImagemJogo = null
            };

            // Assert
            Assert.NotNull(atualizarImagemJogo);
            Assert.Equal(idJogo, atualizarImagemJogo.IdJogo);
            Assert.Null(atualizarImagemJogo.ReferenciaImagemJogo);
        }

        [Fact]
        public void AtualizarImagemJogo_ComIdJogoNegativo_DeveLancarExcecao()
        {
            // Arrange
            int idJogo = -1;
            string referenciaImagemJogo = "nova-imagem-jogo.jpg";

            // Assert
            Assert.Throws<DomainExceptionValidation>(() => new AtualizarImagemJogo
            {
                IdJogo = idJogo,
                ReferenciaImagemJogo = referenciaImagemJogo
            });
        }
    }
}
