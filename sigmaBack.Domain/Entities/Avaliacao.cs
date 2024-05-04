using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class Avaliacao
    {
        public int IDAvaliacao { get; set; }
        public int IDProduto { get; set; }
        public int IDUsuario { get; set; }
        public string? Comentario { get; set; }
        public int Classificacao { get; set; }
        public DateTime DataAvaliacao { get; set; }
        public bool Ativo { get; set; }

        public Avaliacao() { }

        public Avaliacao(int idProduto, int idUsuario, string comentario, int classificacao, DateTime dataAvaliacao, bool ativo)
        {
            ValidationDomain(idProduto, idUsuario, comentario, classificacao, dataAvaliacao);
            Ativo = ativo;
        }

        public Avaliacao(int idAvaliacao, int idProduto, int idUsuario, string comentario, int classificacao, DateTime dataAvaliacao, bool ativo)
            : this(idProduto, idUsuario, comentario, classificacao, dataAvaliacao, ativo)
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

        public void Update(int idProduto, int idUsuario, string comentario, int classificacao, DateTime dataAvaliacao, bool ativo)
        {
            ValidationDomain(idProduto, idUsuario, comentario, classificacao, dataAvaliacao);
            Ativo = ativo;
        }
    }
}
