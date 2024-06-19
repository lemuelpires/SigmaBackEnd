using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class AtualizarImagemAnuncio
    {
        private int _idAnuncio;
        private string? _referenciaImagem;

        public int IdAnuncio
        {
            get => _idAnuncio;
            set
            {
                DomainExceptionValidation.When(value < 0, "O ID do anúncio deve ser maior ou igual a zero.");
                _idAnuncio = value;
            }
        }

        public string? ReferenciaImagem
        {
            get => _referenciaImagem;
            set => _referenciaImagem = value;
        }
    }
}
