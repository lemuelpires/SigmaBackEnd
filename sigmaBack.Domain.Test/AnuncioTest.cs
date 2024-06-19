using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class AnuncioTests
    {
        [Fact]
        public void Anuncio_ComParametrosValidos_DeveSerCriado()
        {
            int idProduto = 1;
            string titulo = "Produto 1";
            string descricao = "Descrição do Produto 1";
            decimal preco = 10.99M;
            string referenciaImagem = "imagem1.png";
            DateTime data = DateTime.Now;
            bool ativo = true;

            var anuncio = new Anuncio(idProduto, titulo, descricao, preco, referenciaImagem, data, ativo);

            Assert.NotNull(anuncio);
            Assert.Equal(idProduto, anuncio.IDProduto);
            Assert.Equal(titulo, anuncio.Titulo);
            Assert.Equal(descricao, anuncio.Descricao);
            Assert.Equal(preco, anuncio.Preco);
            Assert.Equal(referenciaImagem, anuncio.ReferenciaImagem);
            Assert.Equal(data, anuncio.Data);
            Assert.True(anuncio.Ativo);
        }

        [Fact]
        public void Anuncio_ComIDProdutoInvalido_DeveLancarExcecao()
        {
            int idProduto = -1;
            string titulo = "Produto 1";
            string descricao = "Descrição do Produto 1";
            decimal preco = 10.99M;
            string referenciaImagem = "imagem1.png";
            DateTime data = DateTime.Now;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new Anuncio(idProduto, titulo, descricao, preco, referenciaImagem, data, ativo));
        }

        [Fact]
        public void Anuncio_ComTituloInvalido_DeveLancarExcecao()
        {
            int idProduto = 1;
            string titulo = "";
            string descricao = "Descrição do Produto 1";
            decimal preco = 10.99M;
            string referenciaImagem = "imagem1.png";
            DateTime data = DateTime.Now;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new Anuncio(idProduto, titulo, descricao, preco, referenciaImagem, data, ativo));
        }

        [Fact]
        public void Anuncio_ComDescricaoInvalida_DeveLancarExcecao()
        {
            int idProduto = 1;
            string titulo = "Produto 1";
            string descricao = "";
            decimal preco = 10.99M;
            string referenciaImagem = "imagem1.png";
            DateTime data = DateTime.Now;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new Anuncio(idProduto, titulo, descricao, preco, referenciaImagem, data, ativo));
        }

        [Fact]
        public void Anuncio_ComPrecoInvalido_DeveLancarExcecao()
        {
            int idProduto = 1;
            string titulo = "Produto 1";
            string descricao = "Descrição do Produto 1";
            decimal preco = -1M;
            string referenciaImagem = "imagem1.png";
            DateTime data = DateTime.Now;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new Anuncio(idProduto, titulo, descricao, preco, referenciaImagem, data, ativo));
        }

        [Fact]
        public void Anuncio_ComReferenciaImagemInvalida_DeveLancarExcecao()
        {
            int idProduto = 1;
            string titulo = "Produto 1";
            string descricao = "Descrição do Produto 1";
            decimal preco = 10.99M;
            string referenciaImagem = "";
            DateTime data = DateTime.Now;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new Anuncio(idProduto, titulo, descricao, preco, referenciaImagem, data, ativo));
        }

        [Fact]
        public void Anuncio_ComDataInvalida_DeveLancarExcecao()
        {
            int idProduto = 1;
            string titulo = "Produto 1";
            string descricao = "Descrição do Produto 1";
            decimal preco = 10.99M;
            string referenciaImagem = "imagem1.png";
            DateTime data = default;
            bool ativo = true;

            Assert.Throws<DomainExceptionValidation>(() => new Anuncio(idProduto, titulo, descricao, preco, referenciaImagem, data, ativo));
        }

        [Fact]
        public void Anuncio_Update_ComParametrosValidos_DeveAtualizar()
        {
            var anuncio = new Anuncio(1, "Produto 1", "Descrição do Produto 1", 10.99M, "imagem1.png", DateTime.Now, true);

            int idAnuncio = 2;
            int idProduto = 2;
            string titulo = "Produto 2";
            string descricao = "Descrição do Produto 2";
            decimal preco = 20.99M;
            string referenciaImagem = "imagem2.png";
            DateTime data = DateTime.Now.AddDays(1);
            bool ativo = false;

            anuncio.Update(idAnuncio, idProduto, titulo, descricao, preco, referenciaImagem, data, ativo);

            Assert.Equal(idAnuncio, anuncio.IDAnuncio);
            Assert.Equal(idProduto, anuncio.IDProduto);
            Assert.Equal(titulo, anuncio.Titulo);
            Assert.Equal(descricao, anuncio.Descricao);
            Assert.Equal(preco, anuncio.Preco);
            Assert.Equal(referenciaImagem, anuncio.ReferenciaImagem);
            Assert.Equal(data, anuncio.Data);
            Assert.False(anuncio.Ativo);
        }

        [Fact]
        public void Anuncio_Update_ComIDProdutoInvalido_DeveLancarExcecao()
        {
            var anuncio = new Anuncio(1, "Produto 1", "Descrição do Produto 1", 10.99M, "imagem1.png", DateTime.Now, true);

            int idAnuncio = 2;
            int idProduto = -1;
            string titulo = "Produto 2";
            string descricao = "Descrição do Produto 2";
            decimal preco = 20.99M;
            string referenciaImagem = "imagem2.png";
            DateTime data = DateTime.Now.AddDays(1);
            bool ativo = false;

            Assert.Throws<DomainExceptionValidation>(() => anuncio.Update(idAnuncio, idProduto, titulo, descricao, preco, referenciaImagem, data, ativo));
        }
    }
}
