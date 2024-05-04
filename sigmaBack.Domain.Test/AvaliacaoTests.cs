using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class AvaliacaoTests
    {
        [Fact]
        public void Avaliacao_ComParametrosValidos_DeveSerCriada()
        {
            int idProduto = 1;
            int idUsuario = 1;
            string comentario = "Ótimo produto!";
            int classificacao = 5;
            DateTime dataAvaliacao = DateTime.Now;
            bool ativo = true;

            var avaliacao = new Avaliacao(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo);

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
            int idProduto = 0;
            int idUsuario = 1;
            string comentario = "Ótimo produto!";
            int classificacao = 5;
            DateTime dataAvaliacao = DateTime.Now;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new Avaliacao(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo));
        }

        [Fact]
        public void Avaliacao_ComIDUsuarioInvalido_DeveLancarExcecao()
        {
            int idProduto = 1;
            int idUsuario = 0;
            string comentario = "Ótimo produto!";
            int classificacao = 5;
            DateTime dataAvaliacao = DateTime.Now;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new Avaliacao(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo));
        }

        [Fact]
        public void Avaliacao_ComComentarioVazio_DeveLancarExcecao()
        {
            int idProduto = 1;
            int idUsuario = 1;
            string comentario = "";
            int classificacao = 5;
            DateTime dataAvaliacao = DateTime.Now;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new Avaliacao(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo));
        }

        [Fact]
        public void Avaliacao_ComClassificacaoInvalida_DeveLancarExcecao()
        {
            int idProduto = 1;
            int idUsuario = 1;
            string comentario = "Ótimo produto!";
            int classificacao = 6;
            DateTime dataAvaliacao = DateTime.Now;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new Avaliacao(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo));
        }

        [Fact]
        public void Avaliacao_ComDataAvaliacaoInvalida_DeveLancarExcecao()
        {
            int idProduto = 1;
            int idUsuario = 1;
            string comentario = "Ótimo produto!";
            int classificacao = 5;
            DateTime dataAvaliacao = default;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new Avaliacao(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo));
        }
    }
}
