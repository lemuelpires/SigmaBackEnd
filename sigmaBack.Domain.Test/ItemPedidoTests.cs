using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class ItemPedido
    {
        public int IDItemPedido { get; set; }
        public int IDPedido { get; set; }
        public int IDProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string? URLImagem { get; set; }
        public string? DescricaoProduto { get; set; }
        public bool Ativo { get; set; }

        public ItemPedido() { }

        public ItemPedido(int idPedido, int idProduto, int quantidade, decimal precoUnitario, bool ativo)
        {
            ValidationDomain(idPedido, idProduto, quantidade, precoUnitario);
            PrecoUnitario = precoUnitario;
            IDPedido = idPedido;
            IDProduto = idProduto;
            Quantidade = quantidade;
            Ativo = ativo;
        }

        public ItemPedido(int idItemPedido, int idPedido, int idProduto, int quantidade, decimal precoUnitario, string urlImagem, string descricaoProduto, bool ativo)
        {
            ValidationDomain(idPedido, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto);
            PrecoUnitario = precoUnitario;
            IDItemPedido = idItemPedido;
            IDPedido = idPedido;
            IDProduto = idProduto;
            Quantidade = quantidade;
            URLImagem = urlImagem;
            DescricaoProduto = descricaoProduto;
            Ativo = ativo;
        }

        private void ValidationDomain(int idPedido, int idProduto, int quantidade, decimal precoUnitario, string urlImagem = "", string descricaoProduto = "")
        {
            DomainExceptionValidation.When(idPedido < 0, "O ID do pedido é obrigatório.");
            DomainExceptionValidation.When(idProduto < 0, "O ID do produto é obrigatório.");
            DomainExceptionValidation.When(quantidade <= 0, "A quantidade deve ser maior que zero.");
            DomainExceptionValidation.When(precoUnitario < 0, "O preço unitário deve ser maior ou igual a zero.");

            if (!string.IsNullOrEmpty(urlImagem))
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(urlImagem), "A URL da imagem é obrigatória.");
            }

            DomainExceptionValidation.When(string.IsNullOrEmpty(descricaoProduto), "A descrição do produto é obrigatória.");
        }

        public void Update(int idItemPedido, int idPedido, int idProduto, int quantidade, decimal precoUnitario, string urlImagem, string descricaoProduto, bool ativo)
        {
            ValidationDomain(idPedido, idProduto, quantidade, precoUnitario, urlImagem, descricaoProduto);
            PrecoUnitario = precoUnitario;
            IDItemPedido = idItemPedido;
            IDPedido = idPedido;
            IDProduto = idProduto;
            Quantidade = quantidade;
            URLImagem = urlImagem;
            DescricaoProduto = descricaoProduto;
            Ativo = ativo;
        }
    }
}
