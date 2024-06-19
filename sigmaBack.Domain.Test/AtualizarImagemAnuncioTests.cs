using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class AtualizarImagemAnuncioTests
    {
        [Fact]
        public void AtualizarImagemAnuncio_DeveSerCriadoComCamposCorretos()
        {
            // Arrange
            int idAnuncio = 1;
            string referenciaImagem = "nova-imagem.jpg";

            // Act
            var atualizarImagemAnuncio = new AtualizarImagemAnuncio
            {
                IdAnuncio = idAnuncio,
                ReferenciaImagem = referenciaImagem
            };

            // Assert
            Assert.NotNull(atualizarImagemAnuncio);
            Assert.Equal(idAnuncio, atualizarImagemAnuncio.IdAnuncio);
            Assert.Equal(referenciaImagem, atualizarImagemAnuncio.ReferenciaImagem);
        }

        [Fact]
        public void AtualizarImagemAnuncio_ComReferenciaImagemNula_DevePermitir()
        {
            // Arrange
            int idAnuncio = 1;

            // Act
            var atualizarImagemAnuncio = new AtualizarImagemAnuncio
            {
                IdAnuncio = idAnuncio,
                ReferenciaImagem = null
            };

            // Assert
            Assert.NotNull(atualizarImagemAnuncio);
            Assert.Equal(idAnuncio, atualizarImagemAnuncio.IdAnuncio);
            Assert.Null(atualizarImagemAnuncio.ReferenciaImagem);
        }

        [Fact]
        public void AtualizarImagemAnuncio_ComIdAnuncioNegativo_DeveLancarExcecao()
        {
            // Arrange
            int idAnuncio = -1;
            string referenciaImagem = "nova-imagem.jpg";

            // Assert
            Assert.Throws<DomainExceptionValidation>(() => new AtualizarImagemAnuncio
            {
                IdAnuncio = idAnuncio,
                ReferenciaImagem = referenciaImagem
            });
        }
    }
}
