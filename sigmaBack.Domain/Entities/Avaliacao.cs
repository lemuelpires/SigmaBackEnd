using sigmaBack.Domain.Validation;
using System;

namespace sigmaBack.Domain.Entities
{
    public class Avaliacao
    {
        public int IDAvaliacao { get; set; }
        public int IDProduto { get; private set; }
        public int IDUsuario { get; private set; }
        public string Comentario { get; private set; }
        public int Classificacao { get; private set; }
        public DateTime DataAvaliacao { get; private set; }

        // Adicione um construtor vazio protegido para o Entity Framework Core
        public Avaliacao() { }

        public Avaliacao(int idProduto, int idUsuario, string comentario, int classificacao, DateTime dataAvaliacao)
        {
            ValidationDomain(idProduto, idUsuario, comentario, classificacao, dataAvaliacao);
        }

        public Avaliacao(int idAvaliacao, int idProduto, int idUsuario, string comentario, int classificacao, DateTime dataAvaliacao)
            : this(idProduto, idUsuario, comentario, classificacao, dataAvaliacao)
        {
            IDAvaliacao = idAvaliacao;
        }


        private void ValidationDomain(int idProduto, int idUsuario, string comentario, int classificacao, DateTime dataAvaliacao)
        {
            DomainExceptionValidation.When(idProduto <= 0, "O ID do produto é obrigatório.");
            DomainExceptionValidation.When(idUsuario <= 0, "O ID do usuário é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(comentario), "O comentário é obrigatório.");
            DomainExceptionValidation.When(classificacao < 1 || classificacao > 5, "A classificação deve estar entre 1 e 5.");
            DomainExceptionValidation.When(dataAvaliacao == default, "A data da avaliação é obrigatória.");

            IDProduto = idProduto;
            IDUsuario = idUsuario;
            Comentario = comentario;
            Classificacao = classificacao;
            DataAvaliacao = dataAvaliacao;
        }

        public void Update(int idProduto, int idUsuario, string comentario, int classificacao, DateTime dataAvaliacao)
        {
            ValidationDomain(idProduto, idUsuario, comentario, classificacao, dataAvaliacao);
        }
    }
}
