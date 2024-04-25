using Xunit;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Test
{
    public class EnderecoTests
    {
        [Fact]
        public void Endereco_ComCamposCorretos_DeveSerCriado()
        {
            // Arrange
            int idUsuario = 1;
            string rua = "Rua A";
            string cidade = "Cidade A";
            string estado = "Estado A";
            string cep = "12345678";
            string pais = "País A";

            // Act
            var endereco = new Endereco(idUsuario, rua, cidade, estado, cep, pais);

            // Assert
            Assert.NotNull(endereco);
            Assert.Equal(idUsuario, endereco.IDUsuario);
            Assert.Equal(rua, endereco.Rua);
            Assert.Equal(cidade, endereco.Cidade);
            Assert.Equal(estado, endereco.Estado);
            Assert.Equal(cep, endereco.CEP);
            Assert.Equal(pais, endereco.Pais);
        }

        [Theory]
        [InlineData(-1, "Rua A", "Cidade A", "Estado A", "12345678", "País A")]
        // Adicione mais casos de teste com campos obrigatórios em branco ou inválidos
        public void Endereco_ComCampoObrigatorioEmBrancoOuInvalido_DeveLancarExcecao(int idUsuario, string rua, string cidade, string estado, string cep, string pais)
        {
            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Endereco(idUsuario, rua, cidade, estado, cep, pais));
        }

        // Adicione mais testes para outros cenários, como CEP inválido, etc.
    }
}
//
