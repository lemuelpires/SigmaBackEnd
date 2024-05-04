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
            string nomeCategoria = "Eletrônicos";

            var categoria = new Categoria(nomeCategoria);

            Assert.Equal(nomeCategoria, categoria.NomeCategoria);
        }

        [Fact]
        public void Categoria_AtualizacaoComNovoNome_Valido()
        {
            string nomeCategoria = "Eletrônicos";
            string novoNomeCategoria = "Informática";
            var categoria = new Categoria(nomeCategoria);

            categoria.Update(novoNomeCategoria, true);

            Assert.Equal(novoNomeCategoria, categoria.NomeCategoria);
        }

        [Fact]
        public void Categoria_AtualizacaoComNovoNome_NuloOuVazio_DeveLancarExcecao()
        {
            string nomeCategoria = "Eletrônicos";
            string? novoNomeCategoria = null;

            var categoria = new Categoria(nomeCategoria);

            Assert.Throws<DomainExceptionValidation>(() => categoria.Update(novoNomeCategoria, true));
        }
    }
}
