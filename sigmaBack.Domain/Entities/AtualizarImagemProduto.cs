using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class AtualizarImagemProduto
    {
        private int _idProduto;
        private string? _imagemProduto;

        public int IdProduto
        {
            get => _idProduto;
            set
            {
                DomainExceptionValidation.When(value < 0, "O ID do produto deve ser maior ou igual a zero.");
                _idProduto = value;
            }
        }

        public string? ImagemProduto
        {
            get => _imagemProduto;
            set => _imagemProduto = value;
        }
    }
}
