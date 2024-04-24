using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class ItemCarrinho
    {
        public int IDItemCarrinho { get; private set; }
        public int IDCarrinho { get; private set; }
        public int IDProduto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public string URLImagem { get; private set; }
        public string DescricaoProduto { get; private set; }

        public ItemCarrinho() { } // Construtor vazio protegido para o Entity Framework Core

        public ItemCarrinho(int idCarrinho, int idProduto, int quantidade, decimal precoUnitario, string urlImagem, string descricaoProduto)
        {
            ValidationDomain(idCarrinho, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto);
        }

        public ItemCarrinho(int idItemCarrinho, int idCarrinho, int idProduto, int quantidade, decimal precoUnitario, string urlImagem, string descricaoProduto)
        {
            IDItemCarrinho = idItemCarrinho;
            ValidationDomain(idCarrinho, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto);
        }

        private void ValidationDomain(int idCarrinho, int idProduto, int quantidade, decimal precoUnitario, string urlImagem, string descricaoProduto)
        {
            DomainExceptionValidation.When(idCarrinho < 0, "O ID do carrinho é obrigatório.");
            DomainExceptionValidation.When(idProduto < 0, "O ID do produto é obrigatório.");
            DomainExceptionValidation.When(quantidade <= 0, "A quantidade deve ser maior que zero.");
            DomainExceptionValidation.When(precoUnitario < 0, "O preço unitário deve ser maior ou igual a zero.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(urlImagem), "A URL da imagem é obrigatória.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricaoProduto), "A descrição do produto é obrigatória.");

            IDCarrinho = idCarrinho;
            IDProduto = idProduto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            URLImagem = urlImagem;
            DescricaoProduto = descricaoProduto;
        }

        public void Update(int idItemCarrinho, int idCarrinho, int idProduto, int quantidade, decimal precoUnitario, string urlImagem, string descricaoProduto)
        {
            ValidationDomain(idCarrinho, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto);
            IDItemCarrinho = idItemCarrinho;
        }
    }
}
