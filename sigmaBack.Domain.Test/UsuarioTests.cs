using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using System;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class UsuarioTests
    {
        [Fact]
        public void Usuario_ComCamposCorretos_DeveSerCriado()
        {
            string email = "usuario@example.com";
            string nome = "João";
            string sobrenome = "Silva";
            string senha = "senha123";
            string genero = "Masculino";
            var dataNascimento = new DateTime(1990, 1, 1);
            string telefone = "123456789";
            string cpf = "12345678901";
            var data = DateTime.Now;
            bool ativo = true;
            UserRole role = UserRole.Comum; // Definindo o papel como Comum

            var usuario = new Usuario(email, nome, sobrenome, senha, genero, dataNascimento, telefone, cpf, data, ativo, role);

            Assert.NotNull(usuario);
            Assert.Equal(email, usuario.Email);
            Assert.Equal(nome, usuario.Nome);
            Assert.Equal(sobrenome, usuario.Sobrenome);
            Assert.Equal(senha, usuario.Senha);
            Assert.Equal(genero, usuario.Genero);
            Assert.Equal(dataNascimento, usuario.DataNascimento);
            Assert.Equal(telefone, usuario.Telefone);
            Assert.Equal(cpf, usuario.CPF);
            Assert.Equal(data, usuario.Data);
            Assert.Equal(ativo, usuario.Ativo);
            Assert.Equal(role, usuario.Role); // Verifica se o papel do usuário foi definido corretamente
        }

        [Theory]
        [InlineData("", "João", "Silva", "senha123", "Masculino", "1990-01-01", "123456789", "12345678901", "2023-01-01", true)]
        [InlineData("usuario@example.com", "", "Silva", "senha123", "Masculino", "1990-01-01", "123456789", "12345678901", "2023-01-01", true)]
        [InlineData("usuario@example.com", "João", "", "senha123", "Masculino", "1990-01-01", "123456789", "12345678901", "2023-01-01", true)]
        [InlineData("usuario@example.com", "João", "Silva", "", "Masculino", "1990-01-01", "123456789", "12345678901", "2023-01-01", true)]
        [InlineData("usuario@example.com", "João", "Silva", "senha123", "", "1990-01-01", "123456789", "12345678901", "2023-01-01", true)]
        [InlineData("usuario@example.com", "João", "Silva", "senha123", "Masculino", "0001-01-01", "123456789", "12345678901", "2023-01-01", true)]
        [InlineData("usuario@example.com", "João", "Silva", "senha123", "Masculino", "1990-01-01", "", "12345678901", "2023-01-01", true)]
        [InlineData("usuario@example.com", "João", "Silva", "senha123", "Masculino", "1990-01-01", "123456789", "", "2023-01-01", true)]
        [InlineData("usuario@example.com", "João", "Silva", "senha123", "Masculino", "1990-01-01", "123456789", "12345678901", "0001-01-01", true)]
        public void Usuario_ComCampoObrigatorioEmBranco_DeveLancarExcecao(string email, string nome, string sobrenome, string senha, string genero, string dataNascimento, string telefone, string cpf, string data, bool ativo)
        {
            Assert.Throws<DomainExceptionValidation>(() => new Usuario(email, nome, sobrenome, senha, genero, DateTime.Parse(dataNascimento), telefone, cpf, DateTime.Parse(data), ativo, UserRole.Comum));
        }
    }
}
