using sigmaBack.Domain.Validation;
using System;

namespace sigmaBack.Domain.Entities
{
    public class CarrinhoCompra
    {
        public int IDCarrinho { get; private set; }
        public int IDUsuario { get; private set; }
        public DateTime DataHoraCriacaoCarrinho { get; private set; }
        public Usuario Usuario { get; set; }
        public ICollection<ItemCarrinho>? ItensCarrinho { get; set; }

        // Adicione um construtor vazio protegido para o Entity Framework Core
        public CarrinhoCompra() { }

        public CarrinhoCompra(int idUsuario, DateTime dataHoraCriacaoCarrinho)
        {
            ValidationDomain(idUsuario, dataHoraCriacaoCarrinho);
        }

        public CarrinhoCompra(int idCarrinho, int idUsuario, DateTime dataHoraCriacaoCarrinho)
            : this(idUsuario, dataHoraCriacaoCarrinho)
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

        public void Update(int idUsuario, DateTime dataHoraCriacaoCarrinho)
        {
            ValidationDomain(idUsuario, dataHoraCriacaoCarrinho);
        }
    }
}
