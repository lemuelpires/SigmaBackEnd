using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class CarrinhoCompra
    {
        public int IDCarrinho { get; set; }
        public int IDUsuario { get; set; }
        public DateTime DataHoraCriacaoCarrinho { get; set; }
        public bool Ativo { get; set; }

        public Usuario? Usuario { get; set; }
        public ICollection<ItemCarrinho>? ItensCarrinho { get; set; }

        public CarrinhoCompra() { }

        public CarrinhoCompra(int idUsuario, DateTime dataHoraCriacaoCarrinho, bool ativo)
        {
            ValidationDomain(idUsuario, dataHoraCriacaoCarrinho);
            Ativo = ativo;
        }

        public CarrinhoCompra(int idCarrinho, int idUsuario, DateTime dataHoraCriacaoCarrinho, bool ativo)
            : this(idUsuario, dataHoraCriacaoCarrinho, ativo)
        {
            IDCarrinho = idCarrinho;
        }

        private void ValidationDomain(int idUsuario, DateTime dataHoraCriacaoCarrinho)
        {
            DomainExceptionValidation.When(idUsuario <= 0, "O ID do usuário é obrigatório.");
            DomainExceptionValidation.When(dataHoraCriacaoCarrinho == default, "A data e hora de criação do carrinho são obrigatórias.");

            IDUsuario = idUsuario;
            DataHoraCriacaoCarrinho = dataHoraCriacaoCarrinho;
        }

        public void Update(int idUsuario, DateTime dataHoraCriacaoCarrinho, bool ativo)
        {
            ValidationDomain(idUsuario, dataHoraCriacaoCarrinho);
            Ativo = ativo;
        }
    }
}
