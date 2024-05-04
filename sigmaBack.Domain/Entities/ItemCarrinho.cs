using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class ItemCarrinho
    {
        public int IDItemCarrinho { get; set; }
        public int IDCarrinho { get; set; }
        public int IDProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string? URLImagem { get; set; }
        public string? DescricaoProduto { get; set; }
        public bool Ativo { get; set; }

        public ItemCarrinho() { }

        public ItemCarrinho(int idCarrinho, int idProduto, int quantidade, decimal precoUnitario, string urlImagem, string descricaoProduto, bool ativo)
        {
            ValidationDomain(idCarrinho, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto);
            Ativo = ativo;
        }

        public ItemCarrinho(int idItemCarrinho, int idCarrinho, int idProduto, int quantidade, decimal precoUnitario, string urlImagem, string descricaoProduto, bool ativo)
        {
            IDItemCarrinho = idItemCarrinho;
            ValidationDomain(idCarrinho, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto);
            Ativo = ativo;
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

        public void Update(int idItemCarrinho, int idCarrinho, int idProduto, int quantidade, decimal precoUnitario, string urlImagem, string descricaoProduto, bool ativo)
        {
            ValidationDomain(idCarrinho, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto);
            IDItemCarrinho = idItemCarrinho;
            Ativo = ativo;
        }
    }
}
