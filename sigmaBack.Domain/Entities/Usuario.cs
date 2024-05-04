using sigmaBack.Domain.Validation;

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
        public bool Ativo { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
        public ICollection<CarrinhoCompra>? CarrinhosCompras { get; set; }
        public ICollection<Avaliacao>? Avaliacoes { get; set; }
        public ICollection<Endereco>? Enderecos { get; set; }

        public Usuario() { }

        public Usuario(string email, string nome, string sobrenome, string senha, string genero, DateTime dataNascimento, string telefone, bool ativo)
        {
            ValidationDomain(email, nome, sobrenome, senha, genero, dataNascimento, telefone);
            Ativo = ativo;
        }

        public Usuario(int idUsuario, string email, string nome, string sobrenome, string senha, string genero, DateTime dataNascimento, string telefone, bool ativo)
        {
            IDUsuario = idUsuario;
            ValidationDomain(email, nome, sobrenome, senha, genero, dataNascimento, telefone);
            Ativo = ativo;
        }

        private void ValidationDomain(string email, string nome, string sobrenome, string senha, string genero, DateTime dataNascimento, string telefone)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "O email é obrigatório.");
            DomainExceptionValidation.When(!IsValidEmail(email), "O email fornecido não é válido.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(sobrenome), "O sobrenome é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(senha), "A senha é obrigatória.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(genero), "O gênero é obrigatório.");
            DomainExceptionValidation.When(dataNascimento == default, "A data de nascimento é obrigatória.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "O telefone é obrigatório.");

            Email = email;
            Nome = nome;
            Sobrenome = sobrenome;
            Senha = senha;
            Genero = genero;
            DataNascimento = dataNascimento;
            Telefone = telefone;
        }

        private bool IsValidEmail(string email)
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

        public void Update(int idUsuario, string email, string nome, string sobrenome, string senha, string genero, DateTime dataNascimento, string telefone, bool ativo)
        {
            ValidationDomain(email, nome, sobrenome, senha, genero, dataNascimento, telefone);
            IDUsuario = idUsuario;
            Ativo = ativo;
        }
    }
}
