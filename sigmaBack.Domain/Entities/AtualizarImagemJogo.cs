using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class AtualizarImagemJogo
    {
        private int _idJogo;
        private string? _referenciaImagemJogo;

        public int IdJogo
        {
            get => _idJogo;
            set
            {
                DomainExceptionValidation.When(value < 0, "O ID do jogo deve ser maior ou igual a zero.");
                _idJogo = value;
            }
        }

        public string? ReferenciaImagemJogo
        {
            get => _referenciaImagemJogo;
            set => _referenciaImagemJogo = value;
        }
    }
}
