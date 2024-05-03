using Xunit;
using sigmaBack.Domain.Entities;
using System;
using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Test
{
    public class AvaliacaoTests
    {
        [Fact]
        public void Avaliacao_ComParametrosValidos_DeveSerCriada()
        {
            // Arrange
            int idProduto = 1;
            int idUsuario = 1;
            string comentario = "Ótimo produto!";
            int classificacao = 5;
            DateTime dataAvaliacao = DateTime.Now;
            bool ativo = true;

            // Act
            var avaliacao = new Avaliacao(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo);

            // Assert
            Assert.NotNull(avaliacao);
            Assert.Equal(idProduto, avaliacao.IDProduto);
            Assert.Equal(idUsuario, avaliacao.IDUsuario);
            Assert.Equal(comentario, avaliacao.Comentario);
            Assert.Equal(classificacao, avaliacao.Classificacao);
            Assert.Equal(dataAvaliacao, avaliacao.DataAvaliacao);
            Assert.True(avaliacao.Ativo);
        }

        [Fact]
        public void Avaliacao_ComIDProdutoInvalido_DeveLancarExcecao()
        {
            // Arrange
            int idProduto = 0;
            int idUsuario = 1;
            string comentario = "Ótimo produto!";
            int classificacao = 5;
            DateTime dataAvaliacao = DateTime.Now;
            bool ativo = true;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Avaliacao(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo));
        }

        [Fact]
        public void Avaliacao_ComIDUsuarioInvalido_DeveLancarExcecao()
        {
            // Arrange
            int idProduto = 1;
            int idUsuario = 0;
            string comentario = "Ótimo produto!";
            int classificacao = 5;
            DateTime dataAvaliacao = DateTime.Now;
            bool ativo = true;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Avaliacao(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo));
        }

        [Fact]
        public void Avaliacao_ComComentarioVazio_DeveLancarExcecao()
        {
            // Arrange
            int idProduto = 1;
            int idUsuario = 1;
            string comentario = "";
            int classificacao = 5;
            DateTime dataAvaliacao = DateTime.Now;
            bool ativo = true;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Avaliacao(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo));
        }

        [Fact]
        public void Avaliacao_ComClassificacaoInvalida_DeveLancarExcecao()
        {
            // Arrange
            int idProduto = 1;
            int idUsuario = 1;
            string comentario = "Ótimo produto!";
            int classificacao = 6; // Classificação inválida
            DateTime dataAvaliacao = DateTime.Now;
            bool ativo = true;

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Avaliacao(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo));
        }

        [Fact]
        public void Avaliacao_ComDataAvaliacaoInvalida_DeveLancarExcecao()
        {
            // Arrange
            int idProduto = 1;
            int idUsuario = 1;
            string comentario = "Ótimo produto!";
            int classificacao = 5;
            DateTime dataAvaliacao = default;
            bool ativo = true;
        

            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Avaliacao(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo));
        }

        // Adicione mais testes conforme necessário para cobrir outros cenários
    }
}
//