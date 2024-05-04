using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class EnderecoTests
    {
        [Fact]
        public void Endereco_ComCamposCorretos_DeveSerCriado()
        {
            int idUsuario = 1;
            string rua = "Rua A";
            string cidade = "Cidade A";
            string estado = "Estado A";
            string cep = "12345678";
            string pais = "País A";

            var endereco = new Endereco(idUsuario, rua, cidade, estado, cep, pais, true);

            Assert.NotNull(endereco);
            Assert.Equal(idUsuario, endereco.IDUsuario);
            Assert.Equal(rua, endereco.Rua);
            Assert.Equal(cidade, endereco.Cidade);
            Assert.Equal(estado, endereco.Estado);
            Assert.Equal(cep, endereco.CEP);
            Assert.Equal(pais, endereco.Pais);
            Assert.True(endereco.Ativo);
        }

        [Theory]
        [InlineData(-1, "Rua A", "Cidade A", "Estado A", "12345678", "País A")]
        [InlineData(1, "", "Cidade A", "Estado A", "12345678", "País A")]
        [InlineData(1, "Rua A", "", "Estado A", "12345678", "País A")]
        [InlineData(1, "Rua A", "Cidade A", "", "12345678", "País A")]
        [InlineData(1, "Rua A", "Cidade A", "Estado A", "", "País A")]
        [InlineData(1, "Rua A", "Cidade A", "Estado A", "12345678", "")]
        public void Endereco_ComCampoObrigatorioEmBrancoOuInvalido_DeveLancarExcecao(int idUsuario, string rua, string cidade, string estado, string cep, string pais)
        {
            Assert.Throws<DomainExceptionValidation>(() => new Endereco(idUsuario, rua, cidade, estado, cep, pais, true));
        }
    }
}
