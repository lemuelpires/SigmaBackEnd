using Xunit;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Test
{
    public class UsuarioTests
    {
        [Fact]
        public void Usuario_ComCamposCorretos_DeveSerCriado()
        {
            // Arrange
            string email = "usuario@example.com";
            string nome = "João";
            string sobrenome = "Silva";
            string senha = "senha123";
            string genero = "Masculino";
            var dataNascimento = new System.DateTime(1990, 1, 1);
            string telefone = "123456789";
            bool ativo = true;

            // Act
            var usuario = new Usuario(email, nome, sobrenome, senha, genero, dataNascimento, telefone, ativo);

            // Assert
            Assert.NotNull(usuario);
            Assert.Equal(email, usuario.Email);
            Assert.Equal(nome, usuario.Nome);
            Assert.Equal(sobrenome, usuario.Sobrenome);
            Assert.Equal(senha, usuario.Senha);
            Assert.Equal(genero, usuario.Genero);
            Assert.Equal(dataNascimento, usuario.DataNascimento);
            Assert.Equal(telefone, usuario.Telefone);
            Assert.Equal(ativo, usuario.Ativo);
        }

        [Theory]
        [InlineData("", "João", "Silva", "senha123", "Masculino", "1990-01-01", "123456789", true)]
        // Adicione mais casos de teste com campos obrigatórios em branco
        public void Usuario_ComCampoObrigatorioEmBranco_DeveLancarExcecao(string email, string nome, string sobrenome, string senha, string genero, string dataNascimento, string telefone, bool ativo)
        {
            // Act & Assert
            Assert.Throws<DomainExceptionValidation>(() => new Usuario(email, nome, sobrenome, senha, genero, System.DateTime.Parse(dataNascimento), telefone, ativo));
        }

        // Adicione mais testes para outros cenários, como senha em branco, email inválido, etc.
    }
}
//
