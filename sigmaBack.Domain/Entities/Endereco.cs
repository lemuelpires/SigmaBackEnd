using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class Endereco
    {
        public int IDEndereco { get; set; }
        public int IDUsuario { get; set; }
        public string? Rua { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
        public string? Pais { get; set; }
        public bool Ativo { get; set; }

        public Endereco() { }

        public Endereco(int idUsuario, string rua, string cidade, string estado, string cep, string pais, bool ativo)
        {
            ValidationDomain(idUsuario, rua, cidade, estado, cep, pais);
            Ativo = ativo;
        }

        public Endereco(int idEndereco, int idUsuario, string rua, string cidade, string estado, string cep, string pais, bool ativo)
        {
            IDEndereco = idEndereco;
            ValidationDomain(idUsuario, rua, cidade, estado, cep, pais);
            Ativo = ativo;
        }

        private void ValidationDomain(int idUsuario, string rua, string cidade, string estado, string cep, string pais)
        {
            DomainExceptionValidation.When(idUsuario < 0, "O ID do usuário é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(rua), "O endereço é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cidade), "A cidade é obrigatória.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(estado), "O estado é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cep), "O CEP é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(pais), "O país é obrigatório.");

            IDUsuario = idUsuario;
            Rua = rua;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            Pais = pais;
        }

        public void Update(int idEndereco, int idUsuario, string rua, string cidade, string estado, string cep, string pais, bool ativo)
        {
            ValidationDomain(idUsuario, rua, cidade, estado, cep, pais);
            IDEndereco = idEndereco;
            Ativo = ativo;
        }
    }
}
