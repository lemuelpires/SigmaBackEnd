using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using System;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class UsuarioJogoTests
    {
        [Fact]
        public void UsuarioJogo_DeveSerCriadoComCamposCorretos()
        {
            // Arrange
            int idUsuario = 1;
            int idJogo = 2;
            string referenciaImagemJogo = "imagem-jogo.jpg";
            bool ativo = true;

            // Act
            var usuarioJogo = new UsuarioJogo(idUsuario, idJogo, referenciaImagemJogo, ativo);

            // Assert
            Assert.NotNull(usuarioJogo);
            Assert.Equal(idUsuario, usuarioJogo.IDUsuario);
            Assert.Equal(idJogo, usuarioJogo.IDJogo);
            Assert.Equal(referenciaImagemJogo, usuarioJogo.ReferenciaImagemJogo);
            Assert.True(usuarioJogo.Ativo);
        }

        [Theory]
        [InlineData(0, 1, "imagem-jogo.jpg", true)]
        [InlineData(1, 0, "imagem-jogo.jpg", true)]
        [InlineData(1, 1, "", true)]
        public void UsuarioJogo_ComCampoObrigatorioEmBrancoOuInvalido_DeveLancarExcecao(int idUsuario, int idJogo, string referenciaImagemJogo, bool ativo)
        {
            // Assert
            Assert.Throws<DomainExceptionValidation>(() => new UsuarioJogo(idUsuario, idJogo, referenciaImagemJogo, ativo));
        }

        [Fact]
        public void UsuarioJogo_Update_ComParametrosValidos_DeveAtualizar()
        {
            // Arrange
            var usuarioJogo = new UsuarioJogo(1, 2, "imagem-jogo.jpg", true);

            int idUsuario = 3;
            int idJogo = 4;
            string referenciaImagemJogo = "nova-imagem-jogo.jpg";
            bool ativo = false;

            // Act
            usuarioJogo.Update(idUsuario, idJogo, referenciaImagemJogo, ativo);

            // Assert
            Assert.Equal(idUsuario, usuarioJogo.IDUsuario);
            Assert.Equal(idJogo, usuarioJogo.IDJogo);
            Assert.Equal(referenciaImagemJogo, usuarioJogo.ReferenciaImagemJogo);
            Assert.False(usuarioJogo.Ativo);
        }
    }
}
