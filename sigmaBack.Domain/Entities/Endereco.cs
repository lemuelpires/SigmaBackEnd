using sigmaBack.Domain.Validation;
using System;

namespace sigmaBack.Domain.Entities
{
    public class Endereco
    {
        public int IDEndereco { get; private set; }
        public int IDUsuario { get; private set; }
        public string Rua { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }
        public string Pais { get; private set; }

        public Endereco() { } // Construtor vazio protegido para o Entity Framework Core

        public Endereco(int idUsuario, string rua, string cidade, string estado, string cep, string pais)
        {
            ValidationDomain(idUsuario, rua, cidade, estado, cep, pais);
        }

        public Endereco(int idEndereco, int idUsuario, string rua, string cidade, string estado, string cep, string pais)
        {
            IDEndereco = idEndereco;
            ValidationDomain(idUsuario, rua, cidade, estado, cep, pais);
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

        public void Update(int idEndereco, int idUsuario, string rua, string cidade, string estado, string cep, string pais)
        {
            ValidationDomain(idUsuario, rua, cidade, estado, cep, pais);
            IDEndereco = idEndereco;
        }
    }
}
