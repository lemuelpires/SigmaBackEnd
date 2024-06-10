using sigmaBack.Domain.Validation;
using System;
using System.Collections.Generic;

namespace sigmaBack.Domain.Entities
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public string? Email { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Senha { get; set; }
        public string? Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public string? CPF { get; set; }
        public DateTime Data { get; set; }
        public bool Ativo { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Pedido>? Pedidos { get; private set; }
        public ICollection<CarrinhoCompra>? CarrinhosCompras { get;private set; }
        public ICollection<Avaliacao>? Avaliacoes { get; private set; }
        public ICollection<Endereco>? Enderecos { get; private set; }

        public Usuario() { }

        public Usuario(string email, string nome, string sobrenome, string senha, string genero, DateTime dataNascimento, string telefone, string cpf, DateTime data, bool ativo, UserRole role)
        {
            ValidationDomain(email, nome, sobrenome, senha, genero, dataNascimento, telefone, cpf, data);
            Ativo = ativo;
            Role = role;
        }

        public Usuario(int idUsuario, string email, string nome, string sobrenome, string senha, string genero, DateTime dataNascimento, string telefone, string cpf, DateTime data, bool ativo, UserRole role)
        {
            IDUsuario = idUsuario;
            ValidationDomain(email, nome, sobrenome, senha, genero, dataNascimento, telefone, cpf, data);
            Ativo = ativo;
            Role = role;
        }

        private void ValidationDomain(string email, string nome, string sobrenome, string senha, string genero, DateTime dataNascimento, string telefone, string cpf, DateTime data)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "O email é obrigatório.");
            DomainExceptionValidation.When(!IsValidEmail(email), "O email fornecido não é válido.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(sobrenome), "O sobrenome é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(senha), "A senha é obrigatória.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(genero), "O gênero é obrigatório.");
            DomainExceptionValidation.When(dataNascimento == default, "A data de nascimento é obrigatória.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "O telefone é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "O CPF é obrigatório.");
            DomainExceptionValidation.When(!IsValidCPF(cpf), "O CPF fornecido não é válido.");
            DomainExceptionValidation.When(data == default, "A data é obrigatória.");

            Email = email;
            Nome = nome;
            Sobrenome = sobrenome;
            Senha = senha;
            Genero = genero;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            CPF = cpf;
            Data = data;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsValidCPF(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            foreach (char c in cpf)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        public void Update(int idUsuario, string email, string nome, string sobrenome, string senha, string genero, DateTime dataNascimento, string telefone, string cpf, DateTime data, bool ativo)
        {
            ValidationDomain(email, nome, sobrenome, senha, genero, dataNascimento, telefone, cpf, data);
            IDUsuario = idUsuario;
            Ativo = ativo;
        }
    }

    // Enum para definir o papel do usuário
    public enum UserRole
    {
        Comum,
        Administrador
    }
}
